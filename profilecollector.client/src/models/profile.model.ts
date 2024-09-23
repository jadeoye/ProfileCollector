import { AddressModel } from "./address.model";

export class ProfileModel {
  firstName!: string;
  lastName!: string;
  middleName?: string;
  address: AddressModel;

  constructor() {
    this.address = new AddressModel();
  }
}
