import { Component } from '@angular/core';
import { NavigationService } from '../../services/navigation.service';
import { ViewLink } from '../../viewmodels/views/viewlink';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatChipsModule } from '@angular/material/chips';
import { MatDialogModule } from '@angular/material/dialog';
import { MatDividerModule } from '@angular/material/divider';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSelectModule } from '@angular/material/select';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { MatToolbarModule } from '@angular/material/toolbar';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MatSidenavModule }from "@angular/material/sidenav";

@Component({
    selector: 'app-nav-menu',
    templateUrl: './nav-menu.component.html',
    styleUrls: ['./nav-menu.component.scss'],
    imports: [
        MatToolbarModule,
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
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule,
        MatSidenavModule,
    ]
})
export class NavMenuComponent {

  NavigationLinks: ViewLink[];

  // Constructor
  constructor(
    private navigationService: NavigationService) {
    this.NavigationLinks = this.navigationService.GetManagementNavigationLinks();
  }
}
