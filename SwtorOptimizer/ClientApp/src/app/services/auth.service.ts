import { Injectable, OnDestroy } from '@angular/core';
import { BehaviorSubject, Observable, of, Subscription } from 'rxjs';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { ILoginData } from '../models/ILoginData';
import { IAppUser } from '../models/IAppUser';
import { ILoginResult } from '../models/ILoginResult';
import { Router } from '@angular/router';
import { map, finalize, delay, tap } from 'rxjs/operators';

@Injectable({ providedIn: 'root' })
export class AuthService implements OnDestroy {
  private apiEndpoint = `/api/Account`;
  private timer: Subscription;
  private user = new BehaviorSubject<IAppUser>(null);
  user$: Observable<IAppUser> = this.user.asObservable();

  private storageEventListener(event: StorageEvent) {
    if (event.storageArea === localStorage) {
      if (event.key === 'logout-event') {
        this.stopTokenTimer();
        this.user.next(null);
      }
      if (event.key === 'login-event') {
        this.stopTokenTimer();
        this.http.get<ILoginResult>(`${this.apiEndpoint}/User`).subscribe((x) => {
          this.user.next({
            username: x.username,
            originalUserName: x.originalUserName,
          });
        });
      }
    }
  }

  constructor(private router: Router, private http: HttpClient) {
    window.addEventListener('storage', this.storageEventListener.bind(this));
  }

  public ngOnDestroy(): void {
    window.removeEventListener('storage', this.storageEventListener.bind(this));
  }

  public checkPassword(loginData: ILoginData): Observable<HttpResponse<string>> {
    return this.http.post<string>(`${this.apiEndpoint}/CheckPassword`, loginData, { observe: 'response' });
  }

  public getCurrentUser(): Observable<IAppUser> {
    return this.http.get<IAppUser>(`${this.apiEndpoint}/GetCurrentUser`);
  }

  public updatePassword(loginData: ILoginData): Observable<string> {
    return this.http.post<string>(`${this.apiEndpoint}/UpdatePassword`, loginData);
  }

  public updateUsername(user: IAppUser): Observable<string> {
    return this.http.post<string>(`${this.apiEndpoint}/UpdateUsername`, user);
  }

  public login(loginData: ILoginData): Observable<ILoginResult> {
    return this.http.post<ILoginResult>(`${this.apiEndpoint}/Login`, loginData).pipe(
      map((x) => {
        this.user.next({
          username: x.username,
          originalUserName: x.originalUserName,
        });
        this.setLocalStorage(x);
        this.startTokenTimer();
        return x;
      })
    );
  }

  public logout(): void {
    this.http
      .get<unknown>(`${this.apiEndpoint}/Logout`, {})
      .pipe(
        finalize(() => {
          this.clearLocalStorage();
          this.user.next(null);
          this.stopTokenTimer();
          this.router.navigate(['/home']);
        })
      )
      .subscribe();
  }

  public refreshToken(): Observable<ILoginResult> {
    const refreshToken = localStorage.getItem('refresh_token');
    if (!refreshToken) {
      this.clearLocalStorage();
      return of(null);
    }

    return this.http
      .post<ILoginResult>(`${this.apiEndpoint}/RefreshToken`, { refreshToken })
      .pipe(
        map((x) => {
          this.user.next({
            username: x.username,
            originalUserName: x.originalUserName,
          });
          this.setLocalStorage(x);
          this.startTokenTimer();
          return x;
        })
      );
  }

  public setLocalStorage(x: ILoginResult): void {
    localStorage.setItem('access_token', x.accessToken);
    localStorage.setItem('refresh_token', x.refreshToken);
    localStorage.setItem('login-event', 'login' + Math.random());
  }

  public clearLocalStorage(): void {
    localStorage.removeItem('access_token');
    localStorage.removeItem('refresh_token');
    localStorage.setItem('logout-event', 'logout' + Math.random());
  }

  private getTokenRemainingTime(): number {
    const accessToken = localStorage.getItem('access_token');
    if (!accessToken) {
      return 0;
    }
    const jwtToken = JSON.parse(atob(accessToken.split('.')[1]));
    const expires = new Date(jwtToken.exp * 1000);
    return expires.getTime() - Date.now();
  }

  private startTokenTimer(): void {
    const timeout = this.getTokenRemainingTime();
    this.timer = of(true)
      .pipe(
        delay(timeout),
        tap(() => this.refreshToken().subscribe())
      )
      .subscribe();
  }

  private stopTokenTimer(): void {
    this.timer?.unsubscribe();
  }
}
