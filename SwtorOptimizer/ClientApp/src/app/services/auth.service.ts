import { Injectable, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, of, Subscription } from 'rxjs';
import { map, tap, delay, finalize } from 'rxjs/operators';
import { ILoginResult } from '../models/ILoginResult';
import { IAppUser } from '../models/IAppUser';
import { ILoginData } from '../models/ILoginData';

@Injectable({
  providedIn: 'root',
})
export class AuthService implements OnDestroy {
  private readonly apiUrl = `/api/Account`;
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
        this.http.get<ILoginResult>(`${this.apiUrl}/User`).subscribe((x) => {
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

  ngOnDestroy(): void {
    window.removeEventListener('storage', this.storageEventListener.bind(this));
  }

  login(loginData: ILoginData) {
    return this.http.post<ILoginResult>(`${this.apiUrl}/Login`, loginData).pipe(
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

  logout() {
    this.http
      .post<unknown>(`${this.apiUrl}/Logout`, {})
      .pipe(
        finalize(() => {
          this.clearLocalStorage();
          this.user.next(null);
          this.stopTokenTimer();
          this.router.navigate(['login']);
        })
      )
      .subscribe();
  }

  refreshToken() {
    const refreshToken = localStorage.getItem('refresh_token');
    if (!refreshToken) {
      this.clearLocalStorage();
      return of(null);
    }

    return this.http
      .post<ILoginResult>(`${this.apiUrl}/RefreshToken`, { refreshToken })
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

  setLocalStorage(x: ILoginResult) {
    localStorage.setItem('access_token', x.accessToken);
    localStorage.setItem('refresh_token', x.refreshToken);
    localStorage.setItem('login-event', 'login' + Math.random());
  }

  clearLocalStorage() {
    localStorage.removeItem('access_token');
    localStorage.removeItem('refresh_token');
    localStorage.setItem('logout-event', 'logout' + Math.random());
  }

  private getTokenRemainingTime() {
    const accessToken = localStorage.getItem('access_token');
    if (!accessToken) {
      return 0;
    }
    const jwtToken = JSON.parse(atob(accessToken.split('.')[1]));
    const expires = new Date(jwtToken.exp * 1000);
    return expires.getTime() - Date.now();
  }

  private startTokenTimer() {
    const timeout = this.getTokenRemainingTime();
    this.timer = of(true)
      .pipe(
        delay(timeout),
        tap(() => this.refreshToken().subscribe())
      )
      .subscribe();
  }

  private stopTokenTimer() {
    this.timer?.unsubscribe();
  }
}
