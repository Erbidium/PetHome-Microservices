import { AuthGuard } from '@nestjs/passport';
import { JWTAccess } from 'src/strategies';

export class AccessGuard extends AuthGuard(JWTAccess) {}
