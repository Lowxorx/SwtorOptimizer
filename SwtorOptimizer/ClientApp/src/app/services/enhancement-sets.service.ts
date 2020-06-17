import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { IEnhancementSet } from '../models/IEnhancementSet';

@Injectable({ providedIn: 'root' })
export class EnhancementSetsService {
  private apiEndpoint = `${environment.apiEndpoint}/EnhancementSets`;

  constructor(private readonly http: HttpClient) { }

  public getNewEnhancementSet(threshold: number): Observable<HttpResponse<IEnhancementSet[]>> {
    return this.http.get<IEnhancementSet[]>(`${this.apiEndpoint}/GetNewEnhancementSet?threshold=${threshold}`, { observe: 'response' });
  }

  public getEnhancementSetsForThreshold(threshold: number): Observable<IEnhancementSet[]> {
    return this.http.get<IEnhancementSet[]>(`${this.apiEndpoint}/GetEnhancementSetsForThreshold?threshold=${threshold}`);
  }

  public getEnhancementSets(): Observable<IEnhancementSet[]> {
    return this.http.get<IEnhancementSet[]>(`${this.apiEndpoint}/GetEnhancementSets`);
  }
}
