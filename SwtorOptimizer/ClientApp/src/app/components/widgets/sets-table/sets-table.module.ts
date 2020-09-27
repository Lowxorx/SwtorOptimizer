import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { SetsTableComponent } from './sets-table.component';
import { MatPaginatorModule } from '@angular/material/paginator';
import { SetDetailsModule } from '../set-details/set-details.module';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';

@NgModule({
  declarations: [SetsTableComponent],
  imports: [CommonModule, MatTableModule, MatSortModule, MatButtonModule, MatPaginatorModule, SetDetailsModule, MatIconModule],
  exports: [SetsTableComponent],
})
export class SetsTableModule {}
