import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminTasksComponent } from './admin-tasks.component';
import { MatCardModule } from '@angular/material/card';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';

@NgModule({
  declarations: [AdminTasksComponent],
  imports: [CommonModule, MatCardModule, MatTableModule, MatPaginatorModule, MatIconModule, MatButtonModule],
  exports: [AdminTasksComponent],
})
export class AdminTasksModule {}
