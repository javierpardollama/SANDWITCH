import { enableProdMode } from '@angular/core';
import { bootstrapApplication } from '@angular/platform-browser';

import { AppComponent } from './app/app.component';
import { AppConfig } from './app/app.config';

import { environment } from './environments/environment';


import './instrument';

if (environment.production) {
  enableProdMode();
}


bootstrapApplication(AppComponent, AppConfig)
  .catch((err) => console.error(err));