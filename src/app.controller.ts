import { Controller, Get, Post } from '@nestjs/common';
import { AppService } from './app.service';
import { LOGIN_RESPONSE, LoginResponse } from './mock/login.mock';
import { AssessmentResponse, CONFIRM_RESPONSE } from './mock/confirm.mock';

@Controller()
export class AppController {
  constructor(private readonly appService: AppService) {}

  @Get()
  getHello(): string {
    return this.appService.getHello();
  }

  @Post('Auth/login')
  login(): LoginResponse {
    return LOGIN_RESPONSE;
  }

  @Get('Assessment/Confirm')
  getAssessment(): AssessmentResponse {
    return CONFIRM_RESPONSE;
  }
}
