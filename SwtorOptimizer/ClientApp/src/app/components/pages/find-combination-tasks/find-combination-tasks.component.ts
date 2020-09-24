import { Component, OnInit, ViewChild } from '@angular/core';
import { Subscription } from 'rxjs';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { IFindCombinationTask } from '../../../models/IFindCombinationTask';
import { FindCombinationsTasksService } from '../../../services/find-combinations-tasks.service';
import { Router } from '@angular/router';
import { FindCombinationTaskStatus } from 'src/app/models/FindCombinationTaskStatus';

@Component({
  selector: 'app-find-combination-tasks',
  templateUrl: './find-combination-tasks.component.html',
  styleUrls: ['./find-combination-tasks.component.scss'],
})
export class FindCombinationTasksComponent implements OnInit {
  public displayedColumns: string[] = ['threshold', 'status', 'duration', 'setsFound', 'action'];
  public dataSource: MatTableDataSource<IFindCombinationTask> = new MatTableDataSource();
  private dataSourceSubscription: Subscription;

  @ViewChild(MatSort, { static: true })
  public sort: MatSort;
  @ViewChild(MatPaginator)
  public paginator: MatPaginator;

  constructor(private service: FindCombinationsTasksService, public snackBar: MatSnackBar, private router: Router) {}

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

  public getTaskStatus(task: IFindCombinationTask): string {
    const status = task.status as FindCombinationTaskStatus;
    switch (status) {
      case FindCombinationTaskStatus.Idle:
        return 'En attente de lancement';
      case FindCombinationTaskStatus.Ended:
        return 'Terminée';
      case FindCombinationTaskStatus.Started:
        return 'Calcul en cours';
      case FindCombinationTaskStatus.Faulted:
        return 'Erreur';
      default:
        return 'Statut inconnu';
    }
  }

  public getTaskDuration(task: IFindCombinationTask): string {
    const startDate = new Date(task.startDate);
    const endDate =
      (task.status as FindCombinationTaskStatus) === FindCombinationTaskStatus.Started ||
      (task.status as FindCombinationTaskStatus) === FindCombinationTaskStatus.Idle
        ? new Date()
        : new Date(task.endDate);
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

  public showSets(task: IFindCombinationTask): void {
    this.router.navigate(['/task', task.threshold]);
  }
}
