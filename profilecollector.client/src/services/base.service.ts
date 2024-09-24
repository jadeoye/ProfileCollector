import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BaseService {

  constructor() { }

  protected handleError(error: HttpErrorResponse) {
    let message: string = ''

    if (error.error instanceof Event)
      message = error.message;
    else
      message = error.error.errorMessage;

    return throwError(() => new Error(message));
  }
}
