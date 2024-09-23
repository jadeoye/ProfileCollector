import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { ApiResponse } from '../interfaces/api-response.interface';
import { ProfileSavedResponseModel } from '../models/profile-saved-response.model';
import { BaseService } from './base.service';
import { SaveProfileRequestModel } from '../models/save-profile-request.model';
import { DetailedUserProfileResponseModel } from '../models/detailed-user-profile-response.model';
import { environment } from '../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class ProfileCollectorService extends BaseService {

  constructor(private http: HttpClient) {
    super();
  }

  save(profile: SaveProfileRequestModel): Observable<ApiResponse<ProfileSavedResponseModel>> {
    return this.http.post<ApiResponse<ProfileSavedResponseModel>>(environment.baseApiUrl + environment.usersUrl, profile)
      .pipe(catchError(this.handleError.bind(this)));
  }

  getById(profileId: string): Observable<ApiResponse<DetailedUserProfileResponseModel>> {
    return this.http.get<ApiResponse<DetailedUserProfileResponseModel>>(`${environment.baseApiUrl + environment.usersUrl}/${profileId}`)
      .pipe(catchError(this.handleError.bind(this)));
  }
}
