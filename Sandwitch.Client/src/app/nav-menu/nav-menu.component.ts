import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { NavigationService } from '../../services/navigation.service';
import { ViewLink } from '../../viewmodels/views/viewlink';
import { MatToolbarModule } from '@angular/material/toolbar';

import { MatSidenavModule } from "@angular/material/sidenav";
import { RouterModule } from '@angular/router';

@Component({
  changeDetection: ChangeDetectionStrategy.OnPush,
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
  // DI
  private navigationService = inject(NavigationService);

  NavigationLinks: ViewLink[];

  // Constructor
  constructor() {
    this.NavigationLinks = this.navigationService.GetManagementNavigationLinks();
  }
}
