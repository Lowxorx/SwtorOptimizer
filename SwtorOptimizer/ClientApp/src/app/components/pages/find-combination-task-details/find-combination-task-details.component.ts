import { Component, OnInit, OnDestroy, NgZone } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IFindCombinationTask } from '../../../models/IFindCombinationTask';
import { FindCombinationsTasksService } from '../../../services/find-combinations-tasks.service';
import { Subscription, interval, BehaviorSubject } from 'rxjs';

@Component({
  selector: 'app-find-combination-task-details',
  templateUrl: './find-combination-task-details.component.html',
  styleUrls: ['./find-combination-task-details.component.scss'],
})
export class FindCombinationTaskDetailsComponent implements OnInit, OnDestroy {
  public task: IFindCombinationTask;
  public duration$ = new BehaviorSubject<string>("");
  public status$ = new BehaviorSubject<string>("");
  public threshold: number;
  public isLoaded = false;
  public isDetailsVisible = true;
  private timerSub: Subscription;

  constructor(private route: ActivatedRoute, private ngZone: NgZone, private service: FindCombinationsTasksService) {
    this.threshold = Number(this.route.snapshot.paramMap.get('value'));
  }

  public ngOnInit() {
    this.service.getTaskForThreshold(this.threshold).subscribe(response => {
      if (response.status === 200) {
        this.task = response.body;
        this.duration$.next(this.getDuration());
        this.status$.next(this.getTaskStatus());
        if (!this.task.isEnded) {
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

  public getTaskStatus(): string {
    if (!this.task.isStarted) {
      return "En attente de lancement";
    }

    if (this.task.isEnded) {
      return "Terminée";
    }

    if (this.task.isFaulted) {
      return "Erreur";
    }

    if (this.task.isRunning) {
      return "Calcul en cours";
    }

    return "Terminée";
  }

  public getDuration(): string {
    const startDate = new Date(this.task.startDate);
    const endDate = this.task.isRunning ? new Date() : new Date(this.task.endDate);
    const duration = endDate.valueOf() - startDate.valueOf();
    return this.convertMilliseconds(duration);
  }

  private startTimer(): void {
    if (this.task.isRunning || !this.task.isStarted) {
      this.timerSub = interval(10000).subscribe(() => {
        this.ngZone.run(() => {
          this.refreshTaskStatus();
        });
        if (this.task.isEnded || this.task.isFaulted) {
          this.timerSub.unsubscribe();
        }
      });
    }
  }

  private convertMilliseconds(ms: number): string {
    const seconds = (ms / 1000).toFixed(1);
    const minutes = (ms / (1000 * 60)).toFixed(1);
    const hours = (ms / (1000 * 60 * 60)).toFixed(1);

    if (Number(seconds) < 60) {
      return "Moins d'une minute";
    } else if (Number(minutes) < 60) {
      return minutes + " minutes";
    } else if (Number(minutes) > 120 && Number(hours) < 12) {
      return hours + " heures";
    } else {
      return "Plus d'une journée !"
    }
  }

  private refreshTaskStatus() {
    this.service.getTaskById(this.task.id).subscribe(response => {
      if (response.status === 200) {
        this.task = { ...response.body };
        this.duration$.next(this.getDuration());
        this.status$.next(this.getTaskStatus());
      }
    });
  }
}
