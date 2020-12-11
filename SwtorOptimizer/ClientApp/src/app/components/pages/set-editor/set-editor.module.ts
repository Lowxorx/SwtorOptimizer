import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {SetEditorComponent} from './set-editor.component';
import {MatCardModule} from "@angular/material/card";
import {MatSelectModule} from "@angular/material/select";
import {ReactiveFormsModule} from "@angular/forms";
import {MatInputModule} from "@angular/material/input";
import {MatButtonModule} from "@angular/material/button";

@NgModule({
  declarations: [SetEditorComponent],
  imports: [CommonModule, MatCardModule, MatSelectModule, ReactiveFormsModule, MatInputModule, MatButtonModule],
  exports: [SetEditorComponent]
})
export class SetEditorModule {
}
