import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-theme-toggle',
  templateUrl: './theme-toggle.component.html',
  styleUrls: ['./theme-toggle.component.scss'],
})
export class ThemeToggleComponent {
  @Output() OnToggleTheme = new EventEmitter<string>();

  constructor() {}

  public onToggleTheme(event: any): void {
    if (event.target.checked === true) {
      this.OnToggleTheme.emit('light-theme');
    } else {
      this.OnToggleTheme.emit('dark-theme');
    }
  }
}
