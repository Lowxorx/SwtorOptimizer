import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { CalculationTaskDetailsComponent } from './calculation-task-details.component';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatButtonModule } from '@angular/material/button';
import { SetsTableModule } from '../../widgets/sets-table/sets-table.module';

export const routes: Routes = [{ path: '', component: CalculationTaskDetailsComponent }];

@NgModule({
  declarations: [CalculationTaskDetailsComponent],
  imports: [RouterModule.forChild(routes), CommonModule, MatProgressSpinnerModule, MatButtonModule, SetsTableModule],
  exports: [CalculationTaskDetailsComponent],
})
export class CalculationTaskDetailsModule {}
