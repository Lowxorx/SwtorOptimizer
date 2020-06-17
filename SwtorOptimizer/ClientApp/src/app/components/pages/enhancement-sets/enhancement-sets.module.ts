import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EnhancementSetsComponent } from './enhancement-sets.component';
import { Routes, RouterModule } from '@angular/router';
import { SetsTableModule } from '../../widgets/sets-table/sets-table.module';

export const routes: Routes = [{ path: '', component: EnhancementSetsComponent }];

@NgModule({
  declarations: [EnhancementSetsComponent],
  imports: [RouterModule.forChild(routes), CommonModule, SetsTableModule],
  exports: [EnhancementSetsComponent],
})
export class EnhancementSetsModule { }
