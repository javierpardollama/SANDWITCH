import { ViewLink } from '../viewmodels/views/viewlink';

import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root',
})

export class NavigationService {

    public GetManagementNavigationLinks(): ViewLink[] {
        return [
            {
                Id:'nav-search',
                Label: 'Search',
                Link: './',
                Index: 0,
                Class:'nav-menu-option-image search-image'
            },
            {
                Id:'nav-provincias',
                Label: 'Provincias',
                Link: './management/provincias',
                Index: 1,
                Class:'nav-menu-option-image land-image'
            }, {
                Id:'nav-poblaciones',
                Label: 'Poblaciones',
                Link: './management/poblaciones',
                Index: 2,
                Class:'nav-menu-option-image town-image'
            },
            {
                Id:'nav-arenales',
                Label: 'Arenales',
                Link: './management/arenales',
                Index: 3,
                Class:'nav-menu-option-image sand-image'
            },
            {
                Id:'nav-banderas',
                Label: 'Banderas',
                Link: './management/banderas',
                Index: 4,
                Class:'nav-menu-option-image flag-image'
            },
            {
                Id:'nav-vientos',
                Label: 'Vientos',
                Link: './management/vientos',
                Index: 5,
                Class:'nav-menu-option-image compass-image'
            }
        ];
    }    
}
