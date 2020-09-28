import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { ICalculationTask } from '../models/ICalculationTask';

@Injectable({ providedIn: 'root' })
export class CalculationTasksService {
  private apiEndpoint = `/api/CalculationTasks`;

  constructor(private readonly http: HttpClient) {}

  public getTaskForThreshold(threshold: number): Observable<HttpResponse<ICalculationTask>> {
    return this.http.get<ICalculationTask>(`${this.apiEndpoint}/GetTaskForThreshold?threshold=${threshold}`, { observe: 'response' });
  }

  public getTaskById(id: number): Observable<HttpResponse<ICalculationTask>> {
    return this.http.get<ICalculationTask>(`${this.apiEndpoint}/GetTaskById?id=${id}`, { observe: 'response' });
  }

  public getAllTasks(): Observable<ICalculationTask[]> {
    return this.http.get<ICalculationTask[]>(`${this.apiEndpoint}/GetAllTasks`);
  }
}
