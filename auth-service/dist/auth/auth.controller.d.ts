import { AuthTokensDto, CredentialsDto } from './dto';
import { IAuthService } from './iauth.service';
export declare class AuthController {
    private authService;
    constructor(authService: IAuthService);
    signUp(credentials: CredentialsDto): Promise<AuthTokensDto>;
    signIn(credentials: CredentialsDto): Promise<AuthTokensDto>;
    refresh(): Promise<AuthTokensDto>;
    logout(): Promise<void>;
}
