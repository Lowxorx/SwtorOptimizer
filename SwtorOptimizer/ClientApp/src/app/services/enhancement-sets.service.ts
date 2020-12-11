import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { IGearPieceSet } from '../models/IGearPieceSet';

@Injectable({ providedIn: 'root' })
export class EnhancementSetsService {
  private apiEndpoint = `/api/EnhancementSets`;

  constructor(private readonly http: HttpClient) {}

  public getEnhancementSetsByTaskId(taskId: number): Observable<IGearPieceSet[]> {
    return this.http.get<IGearPieceSet[]>(`${this.apiEndpoint}/GetEnhancementSetsByTaskId?taskId=${taskId}`);
  }
}
