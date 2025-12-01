import {Component} from '@angular/core';
import {Meta} from '@angular/platform-browser';
import {environment} from 'src/environments/environment';

import {NavMenuComponent} from './nav-menu/nav-menu.component';
import {RouterModule} from '@angular/router';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss'],
    imports: [
        NavMenuComponent,
        RouterModule
    ]
})

export class AppComponent {
    
    constructor(private meta: Meta) {
        this.ApplyContenSecurityPolicy();
    }

    ApplyContenSecurityPolicy(): void {
        let content = `default-src 'self'; style-src 'self' 'unsafe-inline'; script-src 'self'; img-src 'self' data:; connect-src 'self' ${environment.Api.Service} ${environment.Otel.Exporter}`;

        this.meta.addTag({ 'http-equiv': 'Content-Security-Policy', content });
    }
}
