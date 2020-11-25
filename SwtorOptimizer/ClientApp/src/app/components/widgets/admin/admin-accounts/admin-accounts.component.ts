import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { IAppUser } from 'src/app/models/IAppUser';
import { ILoginData } from 'src/app/models/ILoginData';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-admin-accounts',
  templateUrl: './admin-accounts.component.html',
  styleUrls: ['./admin-accounts.component.scss'],
})
export class AdminAccountsComponent implements OnInit {
  public passwordFormGroup: FormGroup;
  public currentPassword: string;
  public newPassword: string;
  public newPasswordConfirmation: string;

  public usernameFormGroup: FormGroup;
  public user: IAppUser = { username: '', originalUserName: '' };

  constructor(private authService: AuthService, private snackBar: MatSnackBar, private formBuilder: FormBuilder) {}

  public ngOnInit(): void {
    this.createForm();
    this.refreshCurrentUser();
  }

  public isValidateButtonDisabled(): boolean {
    return !this.passwordFormGroup.valid;
  }

  public onSubmitPassword(): void {
    const loginData: ILoginData = { username: this.user.username, password: this.passwordFormGroup.get('password').value };
    this.authService.checkPassword(loginData).subscribe({
      next: (data) => {
        if (data.status === 200) {
          this.updatePassword();
        }
      },
      error: (error) => {
        this.snackBar.open(`Le mot de passe est incorrect !`, null, { duration: 5000, verticalPosition: 'top' });
      },
    });
  }

  public onSubmitUsername(): void {
    const loginData: ILoginData = { username: this.user.username, password: this.usernameFormGroup.get('password').value };
    this.authService.checkPassword(loginData).subscribe({
      next: (data) => {
        if (data.status === 200) {
          this.updateUsername();
        }
      },
      error: (error) => {
        this.snackBar.open(`Le mot de passe est incorrect !`, null, { duration: 5000, verticalPosition: 'top' });
      },
    });
  }

  private updateUsername(): void {
    this.user.username = this.usernameFormGroup.get('username').value;
    this.authService.updateUsername(this.user).subscribe({
      next: (data) => {
        this.usernameFormGroup.reset();
        this.snackBar.open("Le nom d'utilisateur a bien été modifié. Merci de vous reconnecter.", null, { duration: 5000 });
        this.authService.logout();
      },
      error: (error) => {
        this.usernameFormGroup.reset();
        this.refreshCurrentUser();
        console.error(error);
        this.snackBar.open(`Il y a eu un problème pendant la mise à jour du nom d'utilisateur`, null, { duration: 5000 });
      },
    });
  }

  private updatePassword(): void {
    const userData: ILoginData = { username: this.user.username, password: this.passwordFormGroup.get('newPassword').value };
    this.authService.updatePassword(userData).subscribe({
      next: (data) => {
        this.passwordFormGroup.reset();
        this.snackBar.open('Le mot de passe a bien été modifié.', null, { duration: 5000 });
      },
      error: (error) => {
        this.passwordFormGroup.reset();
        console.error(error);
        this.snackBar.open(`Il y a eu un problème pendant la mise à jour du mot de passe`, null, { duration: 5000 });
      },
    });
  }

  private refreshCurrentUser(): void {
    this.authService.getCurrentUser().subscribe({
      next: (e) => {
        this.user = e;
        this.usernameFormGroup.get('originalUserName').setValue(e.originalUserName);
      },
    });
  }

  private createForm() {
    this.passwordFormGroup = this.formBuilder.group(
      {
        password: [this.currentPassword, [Validators.required]],
        newPassword: [this.newPassword, [Validators.required, Validators.minLength(8)]],
        newPasswordConfirm: [this.newPasswordConfirmation, [Validators.required, Validators.minLength(8)]],
      },
      { validators: this.passwordMatch }
    );

    this.usernameFormGroup = this.formBuilder.group({
      password: [this.currentPassword, [Validators.required]],
      originalUserName: [{ value: this.user.originalUserName, disabled: true }, [Validators.required]],
      username: [this.user.username, [Validators.required, Validators.minLength(3), Validators.pattern(/^[\w\s]+$/)]],
    });
  }

  private passwordMatch(control: AbstractControl): { invalid: boolean } {
    if (control.get('newPassword').value !== control.get('newPasswordConfirm').value) {
      control.get('newPasswordConfirm').setErrors({ MatchPassword: true });
      return { invalid: true };
    }
  }
}
