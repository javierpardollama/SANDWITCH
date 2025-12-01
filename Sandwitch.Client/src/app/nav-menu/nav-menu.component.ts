import { Component } from '@angular/core';
import { NavigationService } from '../../services/navigation.service';
import { ViewLink } from '../../viewmodels/views/viewlink';
import { MatToolbarModule } from '@angular/material/toolbar';

import { MatSidenavModule } from "@angular/material/sidenav";
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.scss'],
  imports: [
    MatToolbarModule,
    MatSidenavModule,
    RouterModule
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
