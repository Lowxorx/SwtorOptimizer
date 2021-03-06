import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { Routes, RouterModule } from '@angular/router';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { CalculationTasksComponent } from './calculation-tasks.component';

export const routes: Routes = [{ path: '', component: CalculationTasksComponent }];

@NgModule({
  declarations: [CalculationTasksComponent],
  imports: [RouterModule.forChild(routes), CommonModule, MatTableModule, MatSortModule, MatButtonModule, MatInputModule, MatSnackBarModule, MatFormFieldModule, MatIconModule],
  exports: [CalculationTasksComponent],
})
export class CalculationTasksModule {}
