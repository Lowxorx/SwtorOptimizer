import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { IResultObject } from '../models/IResultObject';

@Injectable({ providedIn: 'root' })
export class AdminService {
  private apiEndpoint = `/api/Admin`;

  constructor(private readonly http: HttpClient) {}

  public deleteTask(taskId: number): Observable<IResultObject> {
    return this.http.post<IResultObject>(`${this.apiEndpoint}/DeleteTask`, taskId);
  }

  public stopTask(taskId: number): Observable<IResultObject> {
    return this.http.post<IResultObject>(`${this.apiEndpoint}/StopTask`, taskId);
  }
}
