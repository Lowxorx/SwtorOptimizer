import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { NavMenuModule } from './components/widgets/nav-menu/nav-menu.module';
import { NoCacheHeadersInterceptor } from './http-interceptor';

@NgModule({
  declarations: [AppComponent],
  imports: [AppRoutingModule, BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }), HttpClientModule, BrowserAnimationsModule, NavMenuModule],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: NoCacheHeadersInterceptor,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
