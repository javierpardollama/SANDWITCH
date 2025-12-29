import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { Meta } from '@angular/platform-browser';
import { environment } from 'src/environments/environment';

import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { RouterModule } from '@angular/router';

@Component({
    changeDetection: ChangeDetectionStrategy.OnPush,
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss'],
    imports: [
        NavMenuComponent,
        RouterModule
    ]
})

export class AppComponent {
    // DI
    private meta = inject(Meta);

    constructor() {
        this.ApplyContenSecurityPolicy();
    }

    ApplyContenSecurityPolicy(): void {
        const content = [
            "default-src 'self'",
            "style-src 'self' 'unsafe-inline'",
            "script-src 'self'",
            "img-src 'self' data:",
            `connect-src 'self' ${environment.Api.Service} ${environment.Otel.Exporter}`
        ].join("; ");

        this.meta.addTag({ 'http-equiv': 'Content-Security-Policy', content });
    }
}
