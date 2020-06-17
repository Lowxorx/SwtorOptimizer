import { NgModule } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';

const MAT_MODULES = [MatButtonModule, MatIconModule, MatCardModule, MatSidenavModule, MatListModule, MatToolbarModule];

@NgModule({
  imports: [...MAT_MODULES],
  exports: [...MAT_MODULES],
})
export class SharedModule {}
