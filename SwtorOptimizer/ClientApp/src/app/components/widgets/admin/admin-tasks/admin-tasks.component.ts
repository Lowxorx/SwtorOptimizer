import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Subscription } from 'rxjs';
import { CalculationTaskStatus } from 'src/app/enums/CalculationTaskStatus';
import CalculationTaskHelper from 'src/app/helpers/calculation-task.helper';
import { ICalculationTask } from 'src/app/models/ICalculationTask';
import { AccountService } from 'src/app/services/account.service';
import { AdminService } from 'src/app/services/admin.service';
import { CalculationTasksService } from 'src/app/services/calculation-tasks.service';

@Component({
  selector: 'app-admin-tasks',
  templateUrl: './admin-tasks.component.html',
  styleUrls: ['./admin-tasks.component.scss'],
})
export class AdminTasksComponent implements OnInit {
  public displayedColumns: string[] = ['threshold', 'status', 'setsFound', 'action'];
  public dataSource: MatTableDataSource<ICalculationTask> = new MatTableDataSource();
  private dataSourceSubscription: Subscription;

  @ViewChild(MatSort, { static: true })
  public sort: MatSort;
  @ViewChild(MatPaginator)
  public paginator: MatPaginator;

  constructor(private accountService: AccountService, private snackBar: MatSnackBar, private adminService: AdminService, private taskService: CalculationTasksService) {}

  public ngOnInit(): void {
    this.refreshTasks();
  }

  public getTaskStatus(task: ICalculationTask): string {
    return CalculationTaskHelper.getTaskStatus(task);
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

  private refreshTasks(): void {
    this.dataSourceSubscription = this.taskService.getAllTasks().subscribe({
      next: (tasks) => {
        this.dataSource = new MatTableDataSource(tasks);
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
      },
    });
  }
}
