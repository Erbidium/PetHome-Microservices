import {
  Body,
  Controller,
  HttpCode,
  HttpStatus,
  Inject,
  Patch,
  Post,
  UseGuards,
} from '@nestjs/common';
import { ApiBearerAuth, ApiResponse } from '@nestjs/swagger';
import { UserId } from 'src/extensions/decorators';
import { AccessGuard } from 'src/extensions/guards';
import {
  AuthTokensDto,
  SignupCredentialsDto,
  SigninCredentialsDto,
  RefreshDto,
} from './dto';
import { AUTH_SERVICE, IAuthService } from './iauth.service';

@Controller('auth')
export class AuthController {
  constructor(
    @Inject(AUTH_SERVICE)
    private authService: IAuthService,
  ) {}

  @ApiResponse({
    status: 200,
    description: 'The auth tokens',
    type: AuthTokensDto,
  })
  @Post('signup')
  async signUp(
    @Body() credentials: SignupCredentialsDto,
  ): Promise<AuthTokensDto> {
    return this.authService.signUp(credentials);
  }

  @ApiResponse({
    status: 200,
    description: 'The auth tokens',
    type: AuthTokensDto,
  })
  @Post('signin')
  async signIn(
    @Body() credentials: SigninCredentialsDto,
  ): Promise<AuthTokensDto> {
    return this.authService.signIn(credentials);
  }

  @ApiResponse({
    status: 200,
    description: 'The auth tokens',
    type: AuthTokensDto,
  })
  @Patch('refresh')
  async refresh(@Body() refreshDto: RefreshDto): Promise<AuthTokensDto> {
    return await this.authService.refresh(refreshDto.token);
  }

  @ApiBearerAuth('access')
  @ApiResponse({
    status: 204,
    description: 'The user logged out',
  })
  @UseGuards(AccessGuard)
  @HttpCode(HttpStatus.NO_CONTENT)
  @Post('logout')
  async logout(@UserId() userId: string): Promise<void> {
    console.log(userId);
    await this.authService.logout(userId);
  }
}
