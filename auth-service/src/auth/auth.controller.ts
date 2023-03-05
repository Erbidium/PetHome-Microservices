import {
  BadRequestException,
  Body,
  Controller,
  Inject,
  Patch,
  Post,
} from '@nestjs/common';
import { ApiResponse } from '@nestjs/swagger';
import { AuthTokensDto, CredentialsDto } from './dto';
import { AUTH_SERVICE, IAuthService } from './iauth.service';

@Controller('auth')
export class AuthController {
  constructor(
    @Inject(AUTH_SERVICE)
    private authService: IAuthService,
  ) {}

  @Post('signup')
  @ApiResponse({
    status: 200,
    description: 'The auth tokens',
    type: AuthTokensDto,
  })
  async signUp(@Body() credentials: CredentialsDto): Promise<AuthTokensDto> {
    return this.authService.signUp(credentials);
  }

  @Post('signin')
  @ApiResponse({
    status: 200,
    description: 'The auth tokens',
    type: AuthTokensDto,
  })
  async signIn(@Body() credentials: CredentialsDto): Promise<AuthTokensDto> {
    return this.authService.signIn(credentials);
  }

  @Patch('refresh')
  @ApiResponse({
    status: 200,
    description: 'The auth tokens',
    type: AuthTokensDto,
  })
  async refresh(): Promise<AuthTokensDto> {
    throw new BadRequestException();
  }

  @Post('logout')
  @ApiResponse({
    status: 200,
    description: 'The user logged out',
  })
  async logout(): Promise<void> {
    throw new BadRequestException();
  }
}
