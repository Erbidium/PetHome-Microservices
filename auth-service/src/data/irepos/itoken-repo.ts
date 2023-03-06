import { AccountRecord } from 'src/auth/dto';

export interface ITokenRepo {
  getByEmail(email: string): Promise<AccountRecord | null>;
  getByUserId(userId: string): Promise<AccountRecord | null>;
  removeTokenByUserId(userId: string): Promise<AccountRecord | null>;
  create(record: AccountRecord): Promise<AccountRecord | null>;
  update(token: string, userId: string): Promise<AccountRecord | null>;
}
