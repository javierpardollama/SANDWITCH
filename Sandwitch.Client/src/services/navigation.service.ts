import { ViewLink } from '../viewmodels/views/viewlink';

import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root',
})

export class NavigationService {

    public GetManagementNavigationLinks(): ViewLink[] {
        return [
            {
                Label: 'Provincias',
                Link: './management/provincias',
                Index: 0,
                Class:'nav-menu-option-image nav-menu-land-image'
            }, {
                Label: 'Poblaciones',
                Link: './management/poblaciones',
                Index: 1,
                Class:'nav-menu-option-image nav-menu-town-image'
            },
            {
                Label: 'Arenales',
                Link: './management/arenales',
                Index: 2,
                Class:'nav-menu-option-image nav-menu-sand-image'
            },
            {
                Label: 'Banderas',
                Link: './management/banderas',
                Index: 3,
                Class:'nav-menu-option-image nav-menu-flag-image'
            }
        ];
    }    
}
