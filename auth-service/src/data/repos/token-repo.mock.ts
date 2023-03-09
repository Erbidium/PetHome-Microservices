import { AccountRecord } from 'src/auth/dto';
import { ITokenRepo } from '../irepos';

export class MockTokenRepo implements ITokenRepo {
  private users: AccountRecord[] = [];

  async getByUserId(userId: string): Promise<AccountRecord> {
    return this.users.find((user) => user.id === userId);
  }

  async getByEmail(email: string): Promise<AccountRecord> {
    return this.users.find((user) => user.email === email);
  }

  async removeTokenByUserId(userId: string): Promise<AccountRecord> {
    const user = this.users.find((user) => user.id === userId);
    user.token = null;
    return user;
  }

  async create(record: AccountRecord): Promise<AccountRecord | null> {
    this.users.push(record);
    return record;
  }

  async update(token: string, userId: string): Promise<AccountRecord> {
    const user = this.users.find((user) => user.id === userId);
    user.token = token;
    return user;
  }
}
