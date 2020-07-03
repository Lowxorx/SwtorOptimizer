import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavMenuComponent } from './nav-menu.component';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatSidenavModule } from '@angular/material/sidenav';
import { RouterModule } from '@angular/router';
import { ThemeToggleModule } from '../theme-toggle/theme-toggle.module';
import { TopbarModule } from '../topbar/topbar.module';

@NgModule({
  declarations: [NavMenuComponent],
  imports: [
    CommonModule,
    ThemeToggleModule,
    TopbarModule,
    MatSidenavModule,
    MatListModule,
    MatIconModule,
    RouterModule
  ],
  exports: [NavMenuComponent],
})
export class NavMenuModule { }
