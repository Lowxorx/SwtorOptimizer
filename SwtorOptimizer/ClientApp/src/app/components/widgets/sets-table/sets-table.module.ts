import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { SetsTableComponent } from './sets-table.component';
import { MatPaginatorModule } from '@angular/material/paginator';
import { SetDetailsModule } from '../set-details/set-details.module';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatSliderModule } from '@angular/material/slider';
import { MatCardModule } from '@angular/material/card';
import {FormsModule} from "@angular/forms";

@NgModule({
  declarations: [SetsTableComponent],
  imports: [CommonModule, MatTableModule, MatSortModule, MatButtonModule, MatPaginatorModule, SetDetailsModule, MatIconModule, MatSliderModule, MatCardModule, FormsModule],
  exports: [SetsTableComponent],
})
export class SetsTableModule {}
