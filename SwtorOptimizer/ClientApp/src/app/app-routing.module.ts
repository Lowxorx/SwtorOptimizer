import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: 'home', loadChildren: () => import('src/app/components/pages/home/home.module').then((mod) => mod.HomeModule) },
  {
    path: 'sets',
    loadChildren: () =>
      import('src/app/components/pages/enhancement-sets/enhancement-sets.module').then((mod) => mod.EnhancementSetsModule),
  },
  {
    path: 'tasks',
    loadChildren: () =>
      import('src/app/components/pages/find-combination-tasks/find-combination-tasks.module').then((mod) => mod.FindCombinationTasksModule),
  },
  {
    path: 'task/:value',
    loadChildren: () =>
      import('src/app/components/pages/find-combination-task-details/find-combination-task-details.module').then((mod) => mod.FindCombinationTaskDetailsModule),
  },
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: '**', redirectTo: '/home', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
