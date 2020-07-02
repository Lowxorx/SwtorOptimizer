import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { IFindCombinationTask } from '../../../models/IFindCombinationTask';
import { FindCombinationsTasksService } from '../../../services/find-combinations-tasks.service';
import { Subscription, interval, BehaviorSubject } from 'rxjs';
import { EnhancementSetsService } from '../../../services/enhancement-sets.service';

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


  constructor(private route: ActivatedRoute, private router: Router, private service: FindCombinationsTasksService, private enhancementsService: EnhancementSetsService) {
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
    if (duration < 60000) {
      return "Moins d'une minute";
    }

    if (duration > 60000 && duration < 3600000) {
      return `${duration / 60000}  minutes`
    }

    return "Plus d'une heure";
  }

  private startTimer(): void {
    if (this.task.isRunning || !this.task.isStarted) {
      this.timerSub = interval(3000).subscribe(() => {
        this.refreshTaskStatus();
        if (this.task.isEnded || this.task.isFaulted) {
          this.timerSub.unsubscribe();
        }
      });
    }
  }

  private refreshTaskStatus() {
    this.service.getTaskById(this.task.id).subscribe(response => {
      if (response.status === 200) {
        this.task = response.body;
        this.duration$.next(this.getDuration());
        this.status$.next(this.getTaskStatus());
      }
    });
  }
}
