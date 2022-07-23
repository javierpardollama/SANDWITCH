import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        console.log(environment);
        request = request.clone({
            setHeaders: {
                Authorization: `Basic ${window.btoa(environment.ApiLock + ':' + environment.ApiKey)}`
            }
        });
        
        return next.handle(request);
    }
}