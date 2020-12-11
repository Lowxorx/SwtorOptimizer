import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {CalculationTasksService} from "../../../services/calculation-tasks.service";
import {Subscription} from "rxjs";
import {ICalculationTask} from "../../../models/ICalculationTask";
import {ISetData} from "../../../models/ISetData";

@Component({
  selector: 'app-set-calculator',
  templateUrl: './set-calculator.component.html',
  styleUrls: ['./set-calculator.component.scss']
})
export class SetCalculatorComponent implements OnInit {
  public formGroup: FormGroup;
  public thresholds: ICalculationTask[] = [];
  private dataSourceSubscription: Subscription;
  private setData: ISetData = {accuracyThresholdId: 0, alacrityThresholdId: 0, alacrityAugments: 0, accuracyAugments: 0}

  constructor(private service: CalculationTasksService, private formBuilder: FormBuilder) {
  }

  public ngOnInit(): void {
    this.createForm();
    this.dataSourceSubscription = this.service.getAllCompletedTasks().subscribe((tasks) => {
      this.thresholds = [...tasks];
      console.log(this.thresholds)
    });
  }

  public calculateMySet(): void {
    const data = this.formGroup.value as ISetData;
    console.log(data);
  }

  private createForm() {
    this.formGroup = this.formBuilder.group({
      accuracyThresholdControl: [this.setData.accuracyThresholdId, [Validators.required]],
      alacrityThresholdControl: [this.setData.alacrityThresholdId, [Validators.required]],
      alacrityAugments: [this.setData.alacrityAugments, [Validators.required, Validators.min(0), Validators.max(13)]],
      accuracyAugments: [this.setData.accuracyAugments, [Validators.required, Validators.min(0), Validators.max(13)]],
    });
  }

}
