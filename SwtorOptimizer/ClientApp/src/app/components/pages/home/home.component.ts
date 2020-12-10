import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IThresholdData } from '../../../models/IThresholdData';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { CalculationTasksService } from 'src/app/services/calculation-tasks.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  public formGroup: FormGroup;

  public minThreshold = 389;
  public maxThreshold = 3017 + 13 * 108;

  public isCalculating = false;

  public thresholdData: IThresholdData = { rawThreshold: 389, useAccuracyStim: false, augments: 0 };

  constructor(private calculationTaskService: CalculationTasksService, private formBuilder: FormBuilder, private snackBar: MatSnackBar, private router: Router) {}

  public ngOnInit() {
    this.createForm();
  }

  public calculateMySets(): void {
    this.isCalculating = true;
    const realThreshold = this.getRealThreshold();
    this.calculationTaskService.calculateGearSets(realThreshold).subscribe((e) => {
      switch (e.statusCode) {
        case 200:
          this.snackBar.open('Le résultat pour ce cap a déjà été calculé, redirection vers les résultats dans 3 secondes...', null, { duration: 3000 });
          this.router.navigate(['/task', e.data]);
          break;
        case 202:
          this.snackBar.open("Le résultat pour ce cap n'a pas encore été calculé. Une tâche a été créée, redirection vers les détails...", null, { duration: 5000 });
          this.router.navigate(['/task', e.data]);
          break;
        default:
      }
      this.isCalculating = false;
    });
  }

  public isValidateButtonDisabled(): boolean {
    return !this.formGroup.valid || this.getRealThreshold() < this.minThreshold || this.isCalculating;
  }

  public getError(formControlName: string): string {
    return this.formGroup.get(formControlName).hasError('required')
      ? 'Ce champ est obligatoire.'
      : this.formGroup.get(formControlName).hasError('min') || this.formGroup.get(formControlName).hasError('max')
      ? `La valeur doit être comprise entre ${this.minThreshold} et ${this.maxThreshold}`
      : 'Le formulaire est invalide.';
  }

  public displayRealThreshold(): string {
    return `Cap réel à atteindre : ${this.getRealThreshold()}`;
  }

  public getFormError(): string {
    if (this.formGroup.valid) {
      if (this.getRealThreshold() < this.minThreshold) {
        return `La configuration actuelle est invalide : le cap réel à calculer ne peut pas descendre en dessous de la valeur minimale (${this.minThreshold}).`;
      }
    }
    return '';
  }

  private getRealThreshold(): number {
    const thresholdDataForm = this.formGroup.value as IThresholdData;

    let realThreshold = thresholdDataForm.rawThreshold;

    if (thresholdDataForm.useAccuracyStim) {
      realThreshold -= 264;
    }

    if (thresholdDataForm.augments > 0) {
      realThreshold -= thresholdDataForm.augments * 108;
    }
    return realThreshold;
  }

  private createForm() {
    this.formGroup = this.formBuilder.group({
      rawThreshold: [this.thresholdData.rawThreshold, [Validators.required, Validators.min(this.minThreshold), Validators.max(this.maxThreshold)]],
      useAccuracyStim: [this.thresholdData.useAccuracyStim],
      augments: [this.thresholdData.augments, [Validators.required, Validators.min(0), Validators.max(13)]],
    });
  }
}
