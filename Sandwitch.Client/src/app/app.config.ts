import { ApplicationConfig, provideZoneChangeDetection } from "@angular/core";
import { provideRouter, withAutoCleanupInjectors } from "@angular/router";
import {
  provideHttpClient,
  withInterceptors,
  withXhr,
} from "@angular/common/http";

import { routes } from "./app.routes";
import { provideServiceWorker } from "@angular/service-worker";
import { environment } from "../environments/environment";
import { AuthInterceptor } from "../interceptors/auth.interceptor";

export const AppConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: false }),
    provideRouter(routes, withAutoCleanupInjectors()),
    provideHttpClient(withXhr(), withInterceptors([AuthInterceptor])),
    provideServiceWorker("ngsw-worker.js", {
      enabled: environment.ServiceWorker.Enabled,
      registrationStrategy: `registerWhenStable:${environment.ServiceWorker.TimeOut}`,
    }),
  ],
};
