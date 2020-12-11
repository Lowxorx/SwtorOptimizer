import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavMenuComponent } from './nav-menu.component';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatSidenavModule } from '@angular/material/sidenav';
import { RouterModule } from '@angular/router';
import { TopbarModule } from '../topbar/topbar.module';
import { MatButtonModule } from '@angular/material/button';

@NgModule({
  declarations: [NavMenuComponent],
  imports: [
    CommonModule,
    TopbarModule,
    MatSidenavModule,
    MatListModule,
    MatIconModule,
    RouterModule,
    MatButtonModule
  ],
  exports: [NavMenuComponent],
})
export class NavMenuModule { }
