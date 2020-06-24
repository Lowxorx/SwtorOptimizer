import { Component, OnInit, ViewChild } from '@angular/core';
import { Subscription } from 'rxjs';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { IFindCombinationTask } from '../../../models/IFindCombinationTask';
import { FindCombinationsTasksService } from '../../../services/find-combinations-tasks.service';
import { Router } from '@angular/router';

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
  @ViewChild(MatPaginator, { static: false})
  public paginator: MatPaginator;

  constructor(private readonly service: FindCombinationsTasksService, public snackBar: MatSnackBar, private router: Router) { }

  public ngOnInit() {
    this.dataSourceSubscription = this.service.getAllTasks().subscribe(tasks => {
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
    if (task.isFaulted) {
      return "Erreur";
    }

    if (!task.isStarted) {
      return "En attente de lancement";
    }

    if (task.isEnded) {
      return "Terminée";
    }

    if (task.isRunning) {
      return "Calcul en cours";
    }

    return "Terminée";
  }

  public getTaskDuration(task: IFindCombinationTask): string {
    const startDate = new Date(task.startDate);
    const endDate = task.isRunning ? new Date() : new Date(task.endDate);
    const duration = endDate.valueOf() - startDate.valueOf();

    if (duration < 60000) {
      return "Moins d'une minute";
    }

    if (duration > 60000 && duration < 3600000) {
      return `${duration / 60000}  minutes`
    }

    return "Plus d'une heure";
  }

  public showSets(task: IFindCombinationTask): void {
    this.router.navigate(['/task', task.threshold]);
  }
}
