import { Module } from '@nestjs/common';
import { JwtModule } from '@nestjs/jwt';
import { DataModule } from 'src/data/data.module';
import { AccessStrategy } from 'src/strategies';
import { AuthController } from './auth.controller';
import { AuthService } from './auth.service';
import { AUTH_SERVICE } from './iauth.service';

@Module({
  controllers: [AuthController],
  providers: [
    {
      provide: AUTH_SERVICE,
      useClass: AuthService,
    },
    AccessStrategy,
  ],
  imports: [DataModule, JwtModule.register({})],
})
export class AuthModule {}
