import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { IFindCombinationTask } from '../models/IFindCombinationTask';

@Injectable({ providedIn: 'root' })
export class FindCombinationsTasksService {
  private apiEndpoint = `/api/FindCombinationsTasks`;

  constructor(private readonly http: HttpClient) { }

  public getTaskForThreshold(threshold: number): Observable<HttpResponse<IFindCombinationTask>> {
    return this.http.get<IFindCombinationTask>(`${this.apiEndpoint}/GetTaskForThreshold?threshold=${threshold}`, { observe: 'response' });
  }

  public getTaskById(id: number): Observable<HttpResponse<IFindCombinationTask>> {
    return this.http.get<IFindCombinationTask>(`${this.apiEndpoint}/GetTaskById?id=${id}`, { observe: 'response' });
  }

  public getAllTasks(): Observable<IFindCombinationTask[]> {
    return this.http.get<IFindCombinationTask[]>(`${this.apiEndpoint}/GetAllTasks`);
  }
}
