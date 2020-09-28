import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './guards/auth.guard';

const routes: Routes = [
  { path: 'home', loadChildren: () => import('src/app/components/pages/home/home.module').then((mod) => mod.HomeModule) },
  {
    path: 'login',
    loadChildren: () => import('src/app/components/pages/login/login.module').then((mod) => mod.LoginModule),
  },
  {
    path: 'tasks',
    loadChildren: () => import('src/app/components/pages/find-combination-tasks/find-combination-tasks.module').then((mod) => mod.FindCombinationTasksModule),
  },
  {
    path: 'task/:value',
    loadChildren: () => import('src/app/components/pages/find-combination-task-details/find-combination-task-details.module').then((mod) => mod.FindCombinationTaskDetailsModule),
  },
  {
    path: 'admin',
    loadChildren: () => import('src/app/components/pages/admin/admin.module').then((mod) => mod.AdminModule),
    canActivate: [AuthGuard],
  },
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: '**', redirectTo: '/home', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
