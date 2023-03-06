import { Module } from '@nestjs/common';
import { DataService } from './data-service/data-service';
import { IDataService } from './data-service/idata-service';

@Module({
  exports: [IDataService],
  providers: [{ provide: IDataService, useClass: DataService }],
})
export class DataModule {}
