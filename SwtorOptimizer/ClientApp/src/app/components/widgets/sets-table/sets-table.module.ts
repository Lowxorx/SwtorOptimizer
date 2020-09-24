import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { SetsTableComponent } from './sets-table.component';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatCardModule } from '@angular/material/card';
import { MatDialogModule } from '@angular/material/dialog';
import { MatListModule } from '@angular/material/list';
import { MatPaginatorModule } from '@angular/material/paginator';

@NgModule({
  declarations: [SetsTableComponent],
  imports: [CommonModule, MatTableModule, MatSortModule, MatInputModule, MatIconModule, MatButtonModule, MatDialogModule, MatButtonToggleModule, MatCardModule, MatListModule, MatPaginatorModule],
  exports: [SetsTableComponent],
})
export class SetsTableModule {}
