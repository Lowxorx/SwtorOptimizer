import { Component, OnInit, ViewChild } from '@angular/core';
import { Subscription } from 'rxjs';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { ICalculationTask } from '../../../models/ICalculationTask';
import { CalculationTasksService } from '../../../services/calculation-tasks.service';
import { Router } from '@angular/router';
import { CalculationTaskStatus } from 'src/app/enums/CalculationTaskStatus';
import CalculationTaskHelper from 'src/app/helpers/calculation-task.helper';

@Component({
  selector: 'app-calculation-tasks',
  templateUrl: './calculation-tasks.component.html',
  styleUrls: ['./calculation-tasks.component.scss'],
})
export class CalculationTasksComponent implements OnInit {
  public displayedColumns: string[] = ['threshold', 'status', 'setsFound', 'action'];
  public dataSource: MatTableDataSource<ICalculationTask> = new MatTableDataSource();
  private dataSourceSubscription: Subscription;

  @ViewChild(MatSort, { static: true })
  public sort: MatSort;
  @ViewChild(MatPaginator)
  public paginator: MatPaginator;

  constructor(private service: CalculationTasksService, public snackBar: MatSnackBar, private router: Router) {}

  public ngOnInit() {
    this.dataSourceSubscription = this.service.getAllTasks().subscribe((tasks) => {
      this.dataSource = new MatTableDataSource(tasks);
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;
    });
  }

  public applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  public getTaskStatus(task: ICalculationTask): string {
    return CalculationTaskHelper.getTaskStatus(task);
  }

  public showSets(task: ICalculationTask): void {
    this.router.navigate(['/task', task.id]);
  }
}
