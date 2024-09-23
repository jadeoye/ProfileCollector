import { AddressModel } from "./address.model";

export class SaveProfileRequestModel {
  firstName!: string;
  lastName!: string;
  middleName?: string;
  address: AddressModel | undefined;
}
