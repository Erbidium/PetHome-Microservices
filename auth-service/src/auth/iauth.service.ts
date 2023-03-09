import {
  AuthTokensDto,
  SigninCredentialsDto,
  SignupCredentialsDto,
} from './dto';

export const AUTH_SERVICE = 'AUTH_SERVICE';

export interface IAuthService {
  signUp(credentials: SignupCredentialsDto): Promise<AuthTokensDto>;
  signIn(credentials: SigninCredentialsDto): Promise<AuthTokensDto>;
  logout(userId: string): Promise<void>;
  refresh(token: string): Promise<AuthTokensDto>;
}
