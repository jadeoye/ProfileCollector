import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AlertDialogComponent } from '../dialogs/alert-dialog/alert-dialog.component';
import { AlertDialogModel } from '../dialogs/models/alert-dialog.model';
import { NotificationType } from '../enums/notification-type.enum';

@Injectable({
  providedIn: 'root'
})
export class AlertService {

  constructor(private dialog: MatDialog) { }

  show(title: string, body: string, notificationType: NotificationType) {
    let alertModel: AlertDialogModel = {
      body: body,
      title: title,
      notificationType: notificationType
    };
    this.dialog.open(AlertDialogComponent, {
      data: alertModel,
      width: '600px'
    })
  }
}
