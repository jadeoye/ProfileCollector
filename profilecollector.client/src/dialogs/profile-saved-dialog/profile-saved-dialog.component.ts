import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DetailedUserProfileModel } from '../../models/detailed-user-profile.model';

@Component({
  selector: 'app-profile-saved-dialog',
  templateUrl: './profile-saved-dialog.component.html',
  styleUrls: ['./profile-saved-dialog.component.css']
})
export class ProfileSavedDialogComponent {
  constructor(@Inject(MAT_DIALOG_DATA) public profile: DetailedUserProfileModel) { }

}
