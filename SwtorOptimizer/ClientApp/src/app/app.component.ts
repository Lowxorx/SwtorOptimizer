import { Component, HostBinding } from '@angular/core';
import { Router } from '@angular/router';
import { OverlayContainer } from '@angular/cdk/overlay';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
})
export class AppComponent {
  title = 'app';

  constructor(public overlayContainer: OverlayContainer, private router: Router) { }

  @HostBinding('class') componentCssClass;

  OnToggleTheme(theme: string) {
    this.overlayContainer.getContainerElement().classList.add(theme);
    this.componentCssClass = theme;
  }
}
