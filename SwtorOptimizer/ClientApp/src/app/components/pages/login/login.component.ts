import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { finalize } from 'rxjs/operators';
import { ILoginData } from 'src/app/models/ILoginData';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit, OnDestroy {
  private busy = false;
  public username = '';
  public password = '';
  public loginError = false;
  public formGroup: FormGroup;
  private subscription: Subscription;

  constructor(private route: ActivatedRoute, private router: Router, private authService: AuthService, private formBuilder: FormBuilder) {}

  public ngOnInit(): void {
    this.createForm();

    this.subscription = this.authService.user$.subscribe((x) => {
      const accessToken = localStorage.getItem('access_token');
      const refreshToken = localStorage.getItem('refresh_token');
      if (x && accessToken && refreshToken) {
        const returnUrl = this.route.snapshot.queryParams['returnUrl'] || '';
        this.router.navigate([returnUrl]);
      }
    });
  }

  public onSubmit() {
    if (!this.formGroup.valid) {
      return;
    }
    this.busy = true;
    const returnUrl = this.route.snapshot.queryParams['returnUrl'] || '';
    const loginData: ILoginData = this.formGroup.value as ILoginData;
    this.authService
      .login(loginData)
      .pipe(finalize(() => (this.busy = false)))
      .subscribe(
        () => {
          this.router.navigate([returnUrl]);
        },
        () => {
          this.loginError = true;
        }
      );
  }

  public ngOnDestroy(): void {
    this.subscription?.unsubscribe();
  }

  public isValidateButtonDisabled(): boolean {
    return !this.formGroup.valid;
  }

  private createForm() {
    this.formGroup = this.formBuilder.group({
      username: [this.username, [Validators.required]],
      password: [this.password, [Validators.required]],
    });
  }
}
