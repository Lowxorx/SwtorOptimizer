import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { ILoginData } from '../models/ILoginData';
import { IAppUser } from '../models/IAppUser';
import { ILoginResult } from '../models/ILoginResult';

@Injectable({ providedIn: 'root' })
export class AccountService {
  private apiEndpoint = `/api/Account`;

  constructor(private readonly http: HttpClient) {}

  public checkPassword(loginData: ILoginData): Observable<HttpResponse<string>> {
    return this.http.post<string>(`${this.apiEndpoint}/CheckPassword`, loginData, { observe: 'response' });
  }

  public getCurrentUser(): Observable<IAppUser> {
    return this.http.get<IAppUser>(`${this.apiEndpoint}/GetCurrentUser`);
  }

  public updatePassword(loginData: ILoginData): Observable<string> {
    return this.http.post<string>(`${this.apiEndpoint}/UpdatePassword`, loginData);
  }
}
