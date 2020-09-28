import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminComponent } from './admin.component';
import { Routes, RouterModule } from '@angular/router';

export const routes: Routes = [{ path: '', component: AdminComponent }];

@NgModule({
  declarations: [AdminComponent],
  imports: [RouterModule.forChild(routes), CommonModule],
  exports: [AdminComponent],
})
export class AdminModule {}
