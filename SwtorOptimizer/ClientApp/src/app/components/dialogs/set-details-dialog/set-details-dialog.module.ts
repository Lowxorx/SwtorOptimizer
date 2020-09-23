import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SetDetailsDialogComponent } from './set-details-dialog.component';
import { MatButtonModule, MatButtonToggleModule, MatIconModule, MatListModule } from '@angular/material';

@NgModule({
  declarations: [SetDetailsDialogComponent],
  imports: [CommonModule, MatButtonModule, MatListModule, MatIconModule, MatButtonToggleModule],
  exports: [SetDetailsDialogComponent],
})
export class SetDetailsDialogModule {}
