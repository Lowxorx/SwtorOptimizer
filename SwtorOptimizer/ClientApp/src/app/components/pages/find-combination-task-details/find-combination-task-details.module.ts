import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { FindCombinationTaskDetailsComponent } from './find-combination-task-details.component';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatButtonModule } from '@angular/material/button';
import { SetsTableModule } from '../../widgets/sets-table/sets-table.module';

export const routes: Routes = [{ path: '', component: FindCombinationTaskDetailsComponent }];

@NgModule({
  declarations: [FindCombinationTaskDetailsComponent],
  imports: [RouterModule.forChild(routes), CommonModule, MatProgressSpinnerModule, MatButtonModule, SetsTableModule],
  exports: [FindCombinationTaskDetailsComponent],
})
export class FindCombinationTaskDetailsModule {}
