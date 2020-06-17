import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-theme-toggle',
  templateUrl: './theme-toggle.component.html',
  styleUrls: ['./theme-toggle.component.scss'],
})
export class ThemeToggleComponent {
  @Output() ToggleTheme = new EventEmitter<string>();

  constructor() {}

  OnToggleTheme(event: any): void {
    if (event.target.checked === true) {
      this.ToggleTheme.emit('light-theme');
    } else {
      this.ToggleTheme.emit('dark-theme');
    }
  }
}
