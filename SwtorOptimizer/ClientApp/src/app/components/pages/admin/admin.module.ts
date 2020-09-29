import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminComponent } from './admin.component';
import { Routes, RouterModule } from '@angular/router';
import { AdminTasksModule } from '../../widgets/admin/admin-tasks/admin-tasks.module';
import { AdminAccountsModule } from '../../widgets/admin/admin-accounts/admin-accounts.module';

export const routes: Routes = [{ path: '', component: AdminComponent }];

@NgModule({
  declarations: [AdminComponent],
  imports: [RouterModule.forChild(routes), CommonModule, AdminTasksModule, AdminAccountsModule],
  exports: [AdminComponent],
})
export class AdminModule {}
