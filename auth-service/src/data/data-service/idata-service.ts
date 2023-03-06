import { ITokenRepo } from '../irepos';

export abstract class IDataService {
  abstract tokenRepo: ITokenRepo;
}
