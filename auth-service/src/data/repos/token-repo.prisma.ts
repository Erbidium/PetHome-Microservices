import { AccountRecord } from 'src/auth/dto';
import { ITokenRepo } from '../irepos';
import { PrismaService } from '../prisma/prisma.service';

export class PrismaTokenRepo implements ITokenRepo {
  constructor(private prisma: PrismaService) {}

  async getByEmail(email: string): Promise<AccountRecord> {
    const record = await this.prisma.record.findFirst({
      where: {
        email: email,
      },
    });
    return record as AccountRecord;
  }

  async getByUserId(userId: string): Promise<AccountRecord> {
    const record = await this.prisma.record.findFirst({
      where: {
        id: userId,
      },
    });
    return record as AccountRecord;
  }

  async removeTokenByUserId(userId: string): Promise<AccountRecord> {
    const record = await this.prisma.record.delete({
      where: {
        id: userId,
      },
    });

    return record as AccountRecord;
  }

  async create(record: AccountRecord): Promise<AccountRecord> {
    const createdRecord = await this.prisma.record.create({
      data: {
        ...record,
      },
    });

    return createdRecord as AccountRecord;
  }

  async update(token: string, userId: string): Promise<AccountRecord> {
    const record = await this.prisma.record.update({
      where: {
        id: userId,
      },
      data: {
        token: token,
      },
    });

    return record as AccountRecord;
  }
}
