import {Component} from '@angular/core';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import {MatButtonModule} from '@angular/material/button';
import {MatCardModule} from '@angular/material/card';
import {MatChipsModule} from '@angular/material/chips';
import {MatDialogModule} from '@angular/material/dialog';
import {MatDividerModule} from '@angular/material/divider';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatSelectModule} from '@angular/material/select';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import {MatSortModule} from '@angular/material/sort';
import {MatTableModule} from '@angular/material/table';
import {Meta} from '@angular/platform-browser';
import {environment} from 'src/environments/environment';

import {NavMenuComponent} from './nav-menu/nav-menu.component';
import {RouterModule, RouterOutlet} from '@angular/router';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss'],
    imports: [
        MatDividerModule,
        MatSelectModule,
        MatInputModule,
        MatDialogModule,
        MatPaginatorModule,
        MatButtonModule,
        MatSnackBarModule,
        MatChipsModule,
        MatAutocompleteModule,
        MatCardModule,
        MatTableModule,
        MatSortModule,
        MatFormFieldModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule,
        NavMenuComponent,
        RouterOutlet
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
