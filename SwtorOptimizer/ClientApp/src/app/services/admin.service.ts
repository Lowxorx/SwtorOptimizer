import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { IEnhancementSet } from '../models/IEnhancementSet';
import { IAppUser } from '../models/IAppUser';

@Injectable({ providedIn: 'root' })
export class AdminService {
  private apiEndpoint = `/api/Admin`;

  constructor(private readonly http: HttpClient) {}

  public getCurrentUser(): Observable<string> {
    return this.http.get<string>(`${this.apiEndpoint}/GetCurrentUser`);
  }
}
