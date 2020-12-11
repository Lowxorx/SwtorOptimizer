import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {SetCalculatorComponent} from './set-calculator.component';
import {RouterModule, Routes} from "@angular/router";
import {MatCardModule} from "@angular/material/card";
import {MatSelectModule} from "@angular/material/select";
import {ReactiveFormsModule} from "@angular/forms";
import {MatInputModule} from "@angular/material/input";
import {MatButtonModule} from "@angular/material/button";

export const routes: Routes = [{path: '', component: SetCalculatorComponent}];

@NgModule({
  declarations: [SetCalculatorComponent],
  imports: [RouterModule.forChild(routes), CommonModule, MatCardModule, MatSelectModule, ReactiveFormsModule, MatInputModule, MatButtonModule],
  exports: [SetCalculatorComponent]
})
export class SetCalculatorModule {
}
