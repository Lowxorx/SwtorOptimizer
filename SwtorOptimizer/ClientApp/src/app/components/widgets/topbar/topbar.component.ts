import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-topbar',
  templateUrl: './topbar.component.html',
  styleUrls: ['./topbar.component.scss']
})
export class TopbarComponent {
  @Input() IsSideMenuOpen: boolean;
  @Output() PrincipalButtonClick = new EventEmitter<void>();
  @Output() OnToggleTheme = new EventEmitter<string>();

  constructor() { }

  public toggleMenu(): void {
    this.PrincipalButtonClick.emit();
  }

  public onToggleTheme(event: string): void {
    this.OnToggleTheme.emit(event);
  }
}
