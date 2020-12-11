import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { ICalculationTask } from '../models/ICalculationTask';
import { IResultObject } from '../models/IResultObject';

@Injectable({ providedIn: 'root' })
export class CalculationTasksService {
  private apiEndpoint = `/api/CalculationTasks`;

  constructor(private readonly http: HttpClient) {}

  public getTaskDetails(id: number): Observable<HttpResponse<ICalculationTask>> {
    return this.http.get<ICalculationTask>(`${this.apiEndpoint}/GetTaskDetails?id=${id}`, { observe: 'response' });
  }

  public getTaskById(id: number): Observable<HttpResponse<ICalculationTask>> {
    return this.http.get<ICalculationTask>(`${this.apiEndpoint}/GetTaskById?id=${id}`, { observe: 'response' });
  }

  public getAllTasks(): Observable<ICalculationTask[]> {
    return this.http.get<ICalculationTask[]>(`${this.apiEndpoint}/GetAllTasks`);
  }

  public calculateEnhancementSets(threshold: number): Observable<IResultObject> {
    return this.http.get<IResultObject>(`${this.apiEndpoint}/CalculateEnhancementSets?threshold=${threshold}`);
  }
}
