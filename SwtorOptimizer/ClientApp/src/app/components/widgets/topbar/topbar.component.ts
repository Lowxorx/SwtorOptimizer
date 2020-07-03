import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-topbar',
  templateUrl: './topbar.component.html',
  styleUrls: ['./topbar.component.scss']
})
export class TopbarComponent {
  @Input() IsSideMenuOpen: boolean;
  @Output() PrincipalButtonClick = new EventEmitter<void>();

  constructor() { }

  public toggleMenu(): void {
    this.PrincipalButtonClick.emit();
  }
}
