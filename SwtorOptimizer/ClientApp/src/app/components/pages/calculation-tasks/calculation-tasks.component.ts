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

@Component({
  selector: 'app-calculation-tasks',
  templateUrl: './calculation-tasks.component.html',
  styleUrls: ['./calculation-tasks.component.scss'],
})
export class CalculationTasksComponent implements OnInit {
  public displayedColumns: string[] = ['threshold', 'status', 'duration', 'setsFound', 'action'];
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
    const status = task.status as CalculationTaskStatus;
    switch (status) {
      case CalculationTaskStatus.Idle:
        return 'En attente de lancement';
      case CalculationTaskStatus.Ended:
        return 'Terminée';
      case CalculationTaskStatus.Started:
        return 'Calcul en cours';
      case CalculationTaskStatus.Faulted:
        return 'Erreur';
      default:
        return 'Statut inconnu';
    }
  }

  public getTaskDuration(task: ICalculationTask): string {
    const startDate = new Date(task.startDate);
    const endDate = (task.status as CalculationTaskStatus) === CalculationTaskStatus.Started || (task.status as CalculationTaskStatus) === CalculationTaskStatus.Idle ? new Date() : new Date(task.endDate);
    const duration = endDate.valueOf() - startDate.valueOf();
    const seconds = (duration / 1000).toFixed(1);
    const minutes = (duration / (1000 * 60)).toFixed(1);
    const hours = (duration / (1000 * 60 * 60)).toFixed(1);

    if (Number(seconds) < 60) {
      return "Moins d'une minute";
    } else if (Number(minutes) < 60) {
      return minutes + ' minutes';
    } else if (Number(minutes) > 120 && Number(hours) < 12) {
      return hours + ' heures';
    } else {
      return "Plus d'une journée !";
    }
  }

  public showSets(task: ICalculationTask): void {
    this.router.navigate(['/task', task.threshold]);
  }
}
