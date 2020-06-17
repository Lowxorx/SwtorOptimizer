import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatPaginatorModule } from '@angular/material/paginator';
import { SetsTableComponent } from './sets-table.component';
import { MatInputModule } from '@angular/material/input';


@NgModule({
  declarations: [SetsTableComponent],
  imports: [CommonModule, MatTableModule, MatSortModule, MatToolbarModule, MatPaginatorModule, MatInputModule],
  exports: [SetsTableComponent],
})
export class SetsTableModule { }
