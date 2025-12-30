import { HttpInterceptorFn } from '@angular/common/http';
import { environment } from 'src/environments/environment';

export const AuthInterceptor: HttpInterceptorFn = (request, next) => {
    request = request.clone({
        setHeaders: {
            Authorization: `Basic ${window.btoa(environment.Api.Lock + ':' + environment.Api.Key)}`
        },
    });

    return next(request);
};