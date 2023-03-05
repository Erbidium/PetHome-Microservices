import { AuthTokensDto, CredentialsDto } from './dto';

export const AUTH_SERVICE = 'AUTH_SERVICE';

export interface IAuthService {
  signUp(credentials: CredentialsDto): Promise<AuthTokensDto>;
  signIn(credentials: CredentialsDto): Promise<AuthTokensDto>;
  logout(userId: string): Promise<void>;
  refresh(userId: string, token: string): Promise<AuthTokensDto>;
}
