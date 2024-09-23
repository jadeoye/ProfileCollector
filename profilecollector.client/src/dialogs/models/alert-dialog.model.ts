import { NotificationType } from "../../enums/notification-type.enum";

export class AlertDialogModel {
  title!: string;
  body!: string;
  notificationType!: NotificationType;
}
