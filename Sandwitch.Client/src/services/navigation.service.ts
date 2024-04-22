import { ViewLink } from '../viewmodels/views/viewlink';

import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root',
})

export class NavigationService {

    public GetManagementNavigationLinks(): ViewLink[] {
        return [
            {
                Id:'nav-provincias',
                Label: 'Provincias',
                Link: './management/provincias',
                Index: 0,
                Class:'nav-menu-option-image nav-menu-land-image'
            }, {
                Id:'nav-poblaciones',
                Label: 'Poblaciones',
                Link: './management/poblaciones',
                Index: 1,
                Class:'nav-menu-option-image nav-menu-town-image'
            },
            {
                Id:'nav-arenales',
                Label: 'Arenales',
                Link: './management/arenales',
                Index: 2,
                Class:'nav-menu-option-image nav-menu-sand-image'
            },
            {
                Id:'nav-banderas',
                Label: 'Banderas',
                Link: './management/banderas',
                Index: 3,
                Class:'nav-menu-option-image nav-menu-flag-image'
            },
            {
                Id:'nav-vientos',
                Label: 'Vientos',
                Link: './management/vientos',
                Index: 4,
                Class:'nav-menu-option-image nav-menu-compass-image'
            }
        ];
    }    
}
