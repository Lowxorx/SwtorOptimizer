import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { IEnhancementSet } from '../models/IEnhancementSet';
import { IResultObject } from '../models/IResultObject';

@Injectable({ providedIn: 'root' })
export class EnhancementSetsService {
  private apiEndpoint = `/api/EnhancementSets`;

  constructor(private readonly http: HttpClient) {}

  public getNewEnhancementSet(threshold: number): Observable<IResultObject> {
    return this.http.get<IResultObject>(`${this.apiEndpoint}/GetNewEnhancementSet?threshold=${threshold}`);
  }

  public getEnhancementSetsForThreshold(threshold: number): Observable<IEnhancementSet[]> {
    return this.http.get<IEnhancementSet[]>(`${this.apiEndpoint}/GetEnhancementSetsForThreshold?threshold=${threshold}`);
  }
}
