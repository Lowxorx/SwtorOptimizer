import { Component, OnInit, OnDestroy, NgZone } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IFindCombinationTask } from '../../../models/IFindCombinationTask';
import { FindCombinationsTasksService } from '../../../services/find-combinations-tasks.service';
import { Subscription, interval } from 'rxjs';
import { IFindCombinationTaskFront } from '../../../models/IFindCombinationTaskFront';
import { FindCombinationTaskStatus } from '../../../models/FindCombinationTaskStatus';

@Component({
  selector: 'app-find-combination-task-details',
  templateUrl: './find-combination-task-details.component.html',
  styleUrls: ['./find-combination-task-details.component.scss'],
})
export class FindCombinationTaskDetailsComponent implements OnInit, OnDestroy {
  public task: IFindCombinationTaskFront;

  public threshold: number;
  public isLoaded = false;
  public isDetailsVisible = true;
  private timerSub: Subscription;

  constructor(private route: ActivatedRoute, private ngZone: NgZone, private service: FindCombinationsTasksService) {
    this.threshold = Number(this.route.snapshot.paramMap.get('value'));
  }

  public ngOnInit() {
    this.service.getTaskForThreshold(this.threshold).subscribe((response) => {
      if (response.status === 200) {
        this.task = { ...response.body, duration: this.getDuration(response.body), statusDisplayName: this.getTaskStatus(response.body) };
        if (this.task.status !== FindCombinationTaskStatus.Ended) {
          this.startTimer();
        }
      }
      this.isLoaded = true;
    });
  }

  public ngOnDestroy(): void {
    try {
      if (this.timerSub != null) {
        this.timerSub.unsubscribe();
      }
    } catch (e) {
      console.error(e);
    }
  }

  public toggleDetails() {
    this.isDetailsVisible = !this.isDetailsVisible;
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

  public taskIsStarted(): boolean {
    const status = this.task.status as FindCombinationTaskStatus;
    return status === FindCombinationTaskStatus.Started;
  }

  public taskIsEnded(): boolean {
    const status = this.task.status as FindCombinationTaskStatus;
    return status === FindCombinationTaskStatus.Ended;
  }

  public taskIsFaulted(): boolean {
    const status = this.task.status as FindCombinationTaskStatus;
    return status === FindCombinationTaskStatus.Faulted;
  }

  public getDuration(task: IFindCombinationTask): string {
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

  private startTimer(): void {
    if ((this.task.status as FindCombinationTaskStatus) === FindCombinationTaskStatus.Started) {
      this.timerSub = interval(10000).subscribe(() => {
        this.ngZone.run(() => {
          this.refreshTaskStatus();
        });
        if (
          (this.task.status as FindCombinationTaskStatus) === FindCombinationTaskStatus.Ended ||
          (this.task.status as FindCombinationTaskStatus) === FindCombinationTaskStatus.Faulted
        ) {
          this.timerSub.unsubscribe();
        }
      });
    }
  }

  private refreshTaskStatus() {
    this.service.getTaskById(this.task.id).subscribe((response) => {
      if (response.status === 200) {
        this.ngZone.run(() => {
          this.task = { ...response.body, duration: this.getDuration(response.body), statusDisplayName: this.getTaskStatus(response.body) };
        });
      }
    });
  }
}
