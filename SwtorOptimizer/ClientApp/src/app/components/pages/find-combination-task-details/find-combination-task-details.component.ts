import { Component, OnInit, OnDestroy, NgZone } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ICalculationTask } from '../../../models/ICalculationTask';
import { FindCombinationsTasksService } from '../../../services/find-combinations-tasks.service';
import { Subscription, interval } from 'rxjs';
import { ICalculationTaskFront } from '../../../models/ICalculationTaskFront';
import { CalculationTaskStatus } from '../../../enums/CalculationTaskStatus';

@Component({
  selector: 'app-find-combination-task-details',
  templateUrl: './find-combination-task-details.component.html',
  styleUrls: ['./find-combination-task-details.component.scss'],
})
export class FindCombinationTaskDetailsComponent implements OnInit, OnDestroy {
  public task: ICalculationTaskFront;

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
        if (this.task.status !== CalculationTaskStatus.Ended) {
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

  public taskIsStarted(): boolean {
    const status = this.task.status as CalculationTaskStatus;
    return status === CalculationTaskStatus.Started;
  }

  public taskIsEnded(): boolean {
    const status = this.task.status as CalculationTaskStatus;
    return status === CalculationTaskStatus.Ended;
  }

  public taskIsFaulted(): boolean {
    const status = this.task.status as CalculationTaskStatus;
    return status === CalculationTaskStatus.Faulted;
  }

  public getDuration(task: ICalculationTask): string {
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

  private startTimer(): void {
    if (this.task.status === CalculationTaskStatus.Started || this.task.status === CalculationTaskStatus.Idle) {
      this.timerSub = interval(10000).subscribe(() => {
        this.ngZone.run(() => {
          this.refreshTaskStatus();
        });
        if (this.task.status === CalculationTaskStatus.Ended || this.task.status === CalculationTaskStatus.Faulted) {
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
