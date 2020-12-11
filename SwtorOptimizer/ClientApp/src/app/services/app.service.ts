import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class AppService {
  private apiEndpoint = `/api/App`;

  constructor(private readonly http: HttpClient) {}

  public getComponentsVersion(): Observable<string[]> {
    return this.http.get<string[]>(`${this.apiEndpoint}/GetComponentsVersion`);
  }
}
