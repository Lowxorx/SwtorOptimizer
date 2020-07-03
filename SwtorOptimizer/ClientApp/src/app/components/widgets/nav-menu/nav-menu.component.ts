import { Component, EventEmitter, Output, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.scss'],
})
export class NavMenuComponent {
  @ViewChild('drawer', {static: true}) drawer: MatSidenav;

  @Output() ToggleTheme = new EventEmitter<string>();

  public IsSideMenuOpen: boolean;

  public OnItemClick(): void {
    this.IsSideMenuOpen = !this.IsSideMenuOpen;
  }

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
