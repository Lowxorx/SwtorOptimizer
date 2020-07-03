import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatToolbarModule } from '@angular/material/toolbar';
import { RouterModule } from '@angular/router';
import { TopbarComponent } from './topbar.component';
import { ThemeToggleModule } from '../theme-toggle/theme-toggle.module';

@NgModule({
  declarations: [TopbarComponent],
  imports: [
    CommonModule,
    MatToolbarModule,
    RouterModule,
    ThemeToggleModule
  ],
  exports: [TopbarComponent],
})
export class TopbarModule { }
