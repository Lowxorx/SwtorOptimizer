import { Component, OnInit, ViewChild } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Subscription } from 'rxjs';
import { CalculationTaskStatus } from 'src/app/enums/CalculationTaskStatus';
import CalculationTaskHelper from 'src/app/helpers/calculation-task.helper';
import { IAppUser } from 'src/app/models/IAppUser';
import { ICalculationTask } from 'src/app/models/ICalculationTask';
import { ILoginData } from 'src/app/models/ILoginData';
import { AccountService } from 'src/app/services/account.service';
import { AdminService } from 'src/app/services/admin.service';
import { CalculationTasksService } from 'src/app/services/calculation-tasks.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss'],
})
export class AdminComponent implements OnInit {
  public passwordErrorText = '';
  public changePasswordResult = '';
  public formGroup: FormGroup;

  public currentPassword: string;
  public newPassword: string;
  public newPasswordConfirmation: string;

  private appUser: IAppUser;

  public displayedColumns: string[] = ['threshold', 'status', 'setsFound', 'action'];
  public dataSource: MatTableDataSource<ICalculationTask> = new MatTableDataSource();
  private dataSourceSubscription: Subscription;

  @ViewChild(MatSort, { static: true })
  public sort: MatSort;
  @ViewChild(MatPaginator)
  public paginator: MatPaginator;

  constructor(private accountService: AccountService, private snackBar: MatSnackBar, private adminService: AdminService, private taskService: CalculationTasksService, private formBuilder: FormBuilder) {}

  public ngOnInit(): void {
    this.createForm();
    this.accountService.getCurrentUser().subscribe({ next: (e) => (this.appUser = e) });
    this.refreshTasks();
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

  public isValidateButtonDisabled(): boolean {
    return !this.formGroup.valid;
  }

  public getTaskStatus(task: ICalculationTask): string {
    return CalculationTaskHelper.getTaskStatus(task);
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

  public deleteTask(element: ICalculationTask): void {
    this.adminService.deleteTask(element.id).subscribe({
      next: (data) => {
        this.snackBar.open(data.message, null, { duration: 5000 });
        this.refreshTasks();
      },
    });
  }

  public stopTask(element: ICalculationTask): void {
    this.adminService.stopTask(element.id).subscribe({
      next: (data) => {
        this.snackBar.open(data.message, null, { duration: 5000 });
        this.refreshTasks();
      },
    });
  }

  public canDeleteTask(status: number): boolean {
    const taskStatus = status as CalculationTaskStatus;
    return taskStatus !== CalculationTaskStatus.Started;
  }

  public canStopTask(status: number): boolean {
    const taskStatus = status as CalculationTaskStatus;
    return taskStatus === CalculationTaskStatus.Started;
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

  private refreshTasks(): void {
    this.dataSourceSubscription = this.taskService.getAllTasks().subscribe({
      next: (tasks) => {
        this.dataSource = new MatTableDataSource(tasks);
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
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
