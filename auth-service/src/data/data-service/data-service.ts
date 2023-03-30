import { Injectable } from '@nestjs/common';
import { PrismaService } from '../prisma/prisma.service';
import { PrismaTokenRepo } from '../repos';
import { IDataService } from './idata-service';

@Injectable()
export class DataService implements IDataService {
  constructor(private prisma: PrismaService) {}

  tokenRepo = new PrismaTokenRepo(this.prisma);
}
