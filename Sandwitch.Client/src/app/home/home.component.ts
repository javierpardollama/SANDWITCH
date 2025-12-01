import { Component } from '@angular/core';
import { SearchComponent } from '../search/search.component';


@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    imports: [
        SearchComponent
    ]
})
export class HomeComponent {
}
