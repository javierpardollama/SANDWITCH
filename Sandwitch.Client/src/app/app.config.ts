import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';
import { HTTP_INTERCEPTORS, provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { provideAnimations } from '@angular/platform-browser/animations';

import { routes } from './app.routes';
import { AuthInterceptor } from '../interceptors/auth.interceptor';
import { provideServiceWorker } from '@angular/service-worker';
import { environment } from '../environments/environment';

export const AppConfig: ApplicationConfig = {
  providers: [
    provideAnimations(),
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
    provideHttpClient(withInterceptorsFromDi()),
    provideServiceWorker('ngsw-worker.js',
        {
            enabled: environment.serviceWorker,
            registrationStrategy: 'registerWhenStable:30000'
        }),
  ]
};
