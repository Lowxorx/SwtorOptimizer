import { Component, ViewChild, EventEmitter, Output } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { version } from '../../../../../package.json';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.scss'],
})
export class NavMenuComponent {
  @ViewChild('drawer', {static: true}) drawer: MatSidenav;
  @Output() OnToggleTheme = new EventEmitter<string>();

  public isSideMenuOpen: boolean;
  public appVersion: string = version;

  public toggleMenu(): void {
    this.isSideMenuOpen = !this.isSideMenuOpen;
  }

  public onToggleTheme(event: string): void {
    this.OnToggleTheme.emit(event);
  }

  public onClose(): void {
    this.isSideMenuOpen = false;
  }
}
