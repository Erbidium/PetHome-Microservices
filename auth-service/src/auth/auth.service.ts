import {
  BadRequestException,
  ForbiddenException,
  Injectable,
} from '@nestjs/common';
import { JwtService } from '@nestjs/jwt';
import { IDataService } from 'src/data/data-service/idata-service';
import {
  AuthTokensDto,
  AccountRecord,
  SigninCredentialsDto,
  SignupCredentialsDto,
} from './dto';
import { IAuthService } from './iauth.service';
import { hash, compare } from 'bcrypt';
import { verify } from 'jsonwebtoken';

@Injectable()
export class AuthService implements IAuthService {
  constructor(
    private dataServices: IDataService,
    private jwtService: JwtService,
  ) {}

  async signUp(credentials: SignupCredentialsDto): Promise<AuthTokensDto> {
    const record = await this.dataServices.tokenRepo.getByEmail(
      credentials.email,
    );
    if (record) {
      throw new BadRequestException('This email is already in use');
    }

    const password = await this.getHashedString(credentials.password);
    const tokens = await this.getTokens(credentials.id, credentials.email);
    const hashedRt = await this.getHashedString(tokens.refresh);
    const newRecord: AccountRecord = {
      ...credentials,
      password: password,
      token: hashedRt,
    };

    await this.dataServices.tokenRepo.create(newRecord);
    return tokens;
  }

  async signIn(credentials: SigninCredentialsDto): Promise<AuthTokensDto> {
    const record = await this.dataServices.tokenRepo.getByEmail(
      credentials.email,
    );
    if (!record) {
      throw new ForbiddenException();
    }
    const doesPasswordMatch = await compare(
      credentials.password,
      record.password,
    );
    if (!doesPasswordMatch) {
      throw new ForbiddenException();
    }
    const tokens = await this.getTokens(record.id, credentials.email);
    const hashedRt = await this.getHashedString(tokens.refresh);
    await this.dataServices.tokenRepo.update(hashedRt, record.id);
    return tokens;
  }

  async logout(userId: string): Promise<void> {
    await this.dataServices.tokenRepo.removeTokenByUserId(userId);
  }

  async refresh(token: string): Promise<AuthTokensDto> {
    const decodedToken = verify(token, process.env.REFRESH_SALT) as {
      sub?: string;
    };
    if (!decodedToken || !decodedToken.sub) {
      throw new ForbiddenException('Incomplete token');
    }
    const record = await this.dataServices.tokenRepo.getByUserId(
      decodedToken.sub,
    );
    if (!record || !record.token) {
      throw new ForbiddenException('Not signed in');
    }
    const doesTokenMatch = await compare(token, record.token);
    if (!doesTokenMatch) {
      throw new ForbiddenException('Wrong token');
    }
    const tokens = await this.getTokens(decodedToken.sub, record.email);
    const hashedRt = await this.getHashedString(tokens.refresh);
    this.dataServices.tokenRepo.update(hashedRt, decodedToken.sub);
    return tokens;
  }

  async getTokens(userId: string, email: string): Promise<AuthTokensDto> {
    const jwtPayload = {
      sub: userId,
      email: email,
    };

    const [at, rt] = await Promise.all([
      this.jwtService.signAsync(jwtPayload, {
        secret: process.env.ACCESS_SALT,
        expiresIn: '15m',
      }),
      this.jwtService.signAsync(jwtPayload, {
        secret: process.env.REFRESH_SALT,
        expiresIn: '7d',
      }),
    ]);

    return { access: at, refresh: rt };
  }

  async getHashedString(token: string): Promise<string> {
    return await hash(token, parseInt(process.env.SALT));
  }
}
