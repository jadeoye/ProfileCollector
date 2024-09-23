import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NotificationType } from '../../enums/notification-type.enum';
import { AlertDialogModel } from '../models/alert-dialog.model';

@Component({
  selector: 'app-alert-dialog',
  templateUrl: './alert-dialog.component.html',
  styleUrls: ['./alert-dialog.component.css']
})
export class AlertDialogComponent {
  NotificationType = NotificationType;
  constructor(@Inject(MAT_DIALOG_DATA) public alert: AlertDialogModel) { }
}
