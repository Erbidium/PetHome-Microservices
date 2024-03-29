import { Module } from '@nestjs/common';
import { DataService } from './data-service/data-service';
import { IDataService } from './data-service/idata-service';
import { PrismaModule } from './prisma/prisma.module';

@Module({
  imports: [PrismaModule],
  exports: [IDataService],
  providers: [{ provide: IDataService, useClass: DataService }],
})
export class DataModule {}
