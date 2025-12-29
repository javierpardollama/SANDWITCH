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
                Id:'nav-states',
                Label: 'States',
                Link: './management/states',
                Index: 1,
                Class:'nav-menu-option-image land-image'
            }, {
                Id:'nav-towns',
                Label: 'Towns',
                Link: './management/towns',
                Index: 2,
                Class:'nav-menu-option-image town-image'
            },
            {
                Id:'nav-beaches',
                Label: 'Beaches',
                Link: './management/beaches',
                Index: 3,
                Class:'nav-menu-option-image sand-image'
            },
            {
                Id:'nav-flags',
                Label: 'Flags',
                Link: './management/flags',
                Index: 4,
                Class:'nav-menu-option-image flag-image'
            },
            {
                Id:'nav-winds',
                Label: 'Winds',
                Link: './management/winds',
                Index: 5,
                Class:'nav-menu-option-image compass-image'
            }
        ];
    }    
}
