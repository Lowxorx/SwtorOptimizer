import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminAccountsComponent } from './admin-accounts.component';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { ReactiveFormsModule } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatInputModule } from '@angular/material/input';

@NgModule({
  declarations: [AdminAccountsComponent],
  imports: [CommonModule, MatCardModule, MatFormFieldModule, ReactiveFormsModule, MatInputModule, MatIconModule, MatButtonModule, MatSnackBarModule],
  exports: [AdminAccountsComponent],
})
export class AdminAccountsModule {}
