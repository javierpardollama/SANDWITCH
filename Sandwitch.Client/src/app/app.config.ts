import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';
import { provideHttpClient, withInterceptors } from '@angular/common/http';

import { routes } from './app.routes';
import { provideServiceWorker } from '@angular/service-worker';
import { environment } from '../environments/environment';
import { AuthInterceptor } from 'src/interceptors/auth.interceptor';

export const AppConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),   
    provideHttpClient(withInterceptors([AuthInterceptor])),
    provideServiceWorker('ngsw-worker.js',
        {
            enabled: environment.ServiceWorker.Enabled,
            registrationStrategy: `registerWhenStable:${environment.ServiceWorker.TimeOut}`
        }),
  ]
};
