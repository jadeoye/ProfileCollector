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

    if (error.error instanceof ErrorEvent)
      message = error.error.message;
    else
      message = error.message;

    return throwError(() => new Error(message));
  }
}
