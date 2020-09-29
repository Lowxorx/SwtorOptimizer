import { BrowserModule } from '@angular/platform-browser';
import { APP_INITIALIZER, NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { NavMenuModule } from './components/widgets/nav-menu/nav-menu.module';
import { NoCacheHeadersInterceptor } from './interceptors/cache.interceptor';
import { JwtInterceptor } from './interceptors/jwt.interceptor';
import { UnauthorizedInterceptor } from './interceptors/unauthorized.interceptor';
import { appInitializer } from './services/app-initializer.service';
import { AuthService } from './services/auth.service';

@NgModule({
  declarations: [AppComponent],
  imports: [AppRoutingModule, BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }), HttpClientModule, BrowserAnimationsModule, NavMenuModule],
  providers: [
    { provide: APP_INITIALIZER, useFactory: appInitializer, multi: true, deps: [AuthService] },
    { provide: HTTP_INTERCEPTORS, useClass: NoCacheHeadersInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: UnauthorizedInterceptor, multi: true },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
