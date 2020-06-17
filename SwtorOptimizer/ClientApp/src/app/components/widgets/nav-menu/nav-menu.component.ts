import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.scss'],
})
export class NavMenuComponent {
  public IsSideMenuOpen: boolean;
  @Output() ToggleTheme = new EventEmitter<string>();

  public OnPrincipalButtonClick(): void {
    this.IsSideMenuOpen = !this.IsSideMenuOpen;
  }

  public OnClose(): void {
    this.IsSideMenuOpen = false;
  }

  public OnToggleTheme(event: string): void {
    this.ToggleTheme.emit(event);
  }
}
