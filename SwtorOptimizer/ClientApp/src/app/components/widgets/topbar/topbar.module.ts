import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatToolbarModule } from '@angular/material/toolbar';
import { RouterModule } from '@angular/router';
import { TopbarComponent } from './topbar.component';

@NgModule({
  declarations: [TopbarComponent],
  imports: [
    CommonModule,
    MatToolbarModule,
    RouterModule
  ],
  exports: [TopbarComponent],
})
export class TopbarModule { }
