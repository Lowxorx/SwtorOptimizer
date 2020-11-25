import { HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
@Injectable()
export class NoCacheHeadersInterceptor implements HttpInterceptor {
  intercept(request: HttpRequest<any>, next: HttpHandler) {
    const isTaskUrl = request.url.includes('/api/CalculationTasks');
    if (isTaskUrl) {
      request = request.clone({
        setHeaders: {
          'Cache-Control': 'no-cache',
          Pragma: 'no-cache',
        },
      });
    }
    return next.handle(request);
  }
}
