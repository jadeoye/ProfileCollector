import { Component, OnInit } from '@angular/core';
import countries from '../constants/countries';
import { ApiResponse } from '../interfaces/api-response.interface';
import { ProfileModel } from '../models/profile.model';
import { ProfileSavedResponseModel } from '../models/profile-saved-response.model';
import { AlertService } from '../services/alert.service';
import { ProfileCollectorService } from '../services/profile-collector.service';
import { SaveProfileRequestModel } from '../models/save-profile-request.model';
import { MatDialog } from '@angular/material/dialog';
import { ProfileSavedDialogComponent } from '../dialogs/profile-saved-dialog/profile-saved-dialog.component';
import { DetailedUserProfileResponseModel } from '../models/detailed-user-profile-response.model';
import { NotificationType } from '../enums/notification-type.enum';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  profile: ProfileModel;
  countries: string[] = countries;
  addressRequired: boolean;
  loading: boolean = false;

  constructor(private profileCollectorService: ProfileCollectorService,
    private alertService: AlertService, private dialog: MatDialog) {
    this.profile = new ProfileModel();
    this.addressRequired = false;
    this.loading = false;
  }

  ngOnInit() {

  }

  submitProfile() {

    this.loading = true;

    let model: SaveProfileRequestModel = {
      firstName: this.profile.firstName,
      lastName: this.profile.lastName,
      middleName: this.profile.middleName,
      address: this.addressRequired ? this.profile.address : undefined
    };

    this.profileCollectorService.save(model).subscribe({
      next: (response: ApiResponse<ProfileSavedResponseModel>) => {

        // we can mock the data, since we have pretty much everything on the UI at this point
        // we can optionally implement a get request to validate persistence

        this.profileCollectorService.getById(response.result.userId).subscribe({
          next: (getUserResponse: ApiResponse<DetailedUserProfileResponseModel>) => {
            this.loading = false;
            this.dialog.open(ProfileSavedDialogComponent, {
              data: getUserResponse.result.user,
              width: '600px'
            })
          }
        });
      },
      error: (error: string) => {
        this.alertService.show("Error", error, NotificationType.Error);
        this.loading = false;
      }
    });
  }

  verifyIfAddressShouldBeRequired() {
    this.addressRequired = !!(this.profile.address &&
      (this.profile.address.street || this.profile.address.city ||
        this.profile.address.state || this.profile.address.zip || this.profile.address.country));
  }
}
