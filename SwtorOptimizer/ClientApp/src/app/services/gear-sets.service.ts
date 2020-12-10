import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { IGearSet } from '../models/IGearSet';

@Injectable({ providedIn: 'root' })
export class GearSetsService {
  private apiEndpoint = `/api/GearSets`;

  constructor(private readonly http: HttpClient) {}

  public getGearSetsByTaskId(taskId: number): Observable<IGearSet[]> {
    return this.http.get<IGearSet[]>(`${this.apiEndpoint}/GetGearSetsByTaskId?taskId=${taskId}`);
  }
}
