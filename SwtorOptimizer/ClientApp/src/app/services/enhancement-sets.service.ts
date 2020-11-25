import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { IEnhancementSet } from '../models/IEnhancementSet';

@Injectable({ providedIn: 'root' })
export class EnhancementSetsService {
  private apiEndpoint = `/api/EnhancementSets`;

  constructor(private readonly http: HttpClient) {}

  public getEnhancementSetsByTaskId(taskId: number): Observable<IEnhancementSet[]> {
    return this.http.get<IEnhancementSet[]>(`${this.apiEndpoint}/GetEnhancementSetsByTaskId?taskId=${taskId}`);
  }
}
