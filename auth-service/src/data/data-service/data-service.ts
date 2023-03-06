import { Injectable } from '@nestjs/common';
import { MockTokenRepo } from '../repos';
import { IDataService } from './idata-service';

@Injectable()
export class DataService implements IDataService {
  tokenRepo = new MockTokenRepo();
}
