import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SetDetailsComponent } from './set-details.component';
import { MatCardModule } from '@angular/material/card';
import { MatListModule } from '@angular/material/list';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatSortModule } from '@angular/material/sort';

@NgModule({
  declarations: [SetDetailsComponent],
  imports: [CommonModule, MatCardModule, MatListModule, MatTableModule, MatSortModule, MatIconModule, MatButtonModule, MatButtonToggleModule],
  exports: [SetDetailsComponent],
})
export class SetDetailsModule {}
