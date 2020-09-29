import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { IAppUser } from 'src/app/models/IAppUser';
import { ILoginData } from 'src/app/models/ILoginData';
import { AccountService } from 'src/app/services/account.service';

@Component({
  selector: 'app-admin-accounts',
  templateUrl: './admin-accounts.component.html',
  styleUrls: ['./admin-accounts.component.scss'],
})
export class AdminAccountsComponent implements OnInit {
  public formGroup: FormGroup;
  public passwordErrorText = '';
  public currentPassword: string;
  public newPassword: string;
  public newPasswordConfirmation: string;
  private appUser: IAppUser;

  constructor(private accountService: AccountService, private snackBar: MatSnackBar, private formBuilder: FormBuilder) {}

  public ngOnInit(): void {
    this.createForm();
    this.accountService.getCurrentUser().subscribe({ next: (e) => (this.appUser = e) });
  }

  public isValidateButtonDisabled(): boolean {
    return !this.formGroup.valid;
  }

  public onSubmit(): void {
    const loginData: ILoginData = { username: this.appUser.username, password: this.formGroup.get('password').value };
    this.accountService.checkPassword(loginData).subscribe({
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

  public shouldDisplayError(): boolean {
    if (this.formGroup.invalid) {
      this.passwordErrorText = 'Tout les champs sont requis';
    }
    if (this.formGroup.get('newPasswordConfirm').hasError('MatchPassword')) {
      this.passwordErrorText = 'Les mots de passe ne correspondent pas';
    }
    return this.formGroup.get('password').touched && this.formGroup.get('newPassword').touched && this.formGroup.get('newPasswordConfirm').touched && this.formGroup.invalid;
  }

  private updatePassword(): void {
    const userData: ILoginData = { username: this.appUser.username, password: this.formGroup.get('newPassword').value };
    this.accountService.updatePassword(userData).subscribe({
      next: (data) => {
        this.formGroup.reset();
        this.snackBar.open('Le mot de passe a bien été modifié.', null, { duration: 5000 });
      },
      error: (error) => {
        this.formGroup.reset();
        console.error(error);
        this.snackBar.open(`Il y a eu un problème pendant la mise à jour du mot de passe`, null, { duration: 5000 });
      },
    });
  }

  private createForm() {
    this.formGroup = this.formBuilder.group(
      {
        password: [this.currentPassword, [Validators.required]],
        newPassword: [this.newPassword, [Validators.required]],
        newPasswordConfirm: [this.newPasswordConfirmation, [Validators.required]],
      },
      { validators: this.passwordMatch }
    );
  }

  private passwordMatch(control: AbstractControl): { invalid: boolean } {
    if (control.get('newPassword').value !== control.get('newPasswordConfirm').value) {
      control.get('newPasswordConfirm').setErrors({ MatchPassword: true });
      return { invalid: true };
    }
  }
}
