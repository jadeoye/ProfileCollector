import { AddressModel } from "./address.model";

export class DetailedUserProfileModel {
  firstName!: string;
  lastName!: string;
  middleName?: string;
  fullName!: string;
  address!: AddressModel;
}
