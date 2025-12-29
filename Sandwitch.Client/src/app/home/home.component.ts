import { ChangeDetectionStrategy, Component } from '@angular/core';
import { SearchComponent } from '../search/search.component';


@Component({
    changeDetection: ChangeDetectionStrategy.OnPush,
    selector: 'app-home',
    templateUrl: './home.component.html',
    imports: [
        SearchComponent
    ]
})
export class HomeComponent {
}
