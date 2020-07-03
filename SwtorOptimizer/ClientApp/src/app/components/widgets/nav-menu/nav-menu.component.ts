import { Component, EventEmitter, Output, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { version } from '../../../../../package.json';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.scss'],
})
export class NavMenuComponent {
  @ViewChild('drawer', {static: true}) drawer: MatSidenav;

  @Output() ToggleTheme = new EventEmitter<string>();

  public isSideMenuOpen: boolean;
  public appVersion: string = version;

  public toggleMenu(): void {
    this.isSideMenuOpen = !this.isSideMenuOpen;
  }

  public onClose(): void {
    this.isSideMenuOpen = false;
  }

  public onToggleTheme(event: string): void {
    this.ToggleTheme.emit(event);
  }
}
