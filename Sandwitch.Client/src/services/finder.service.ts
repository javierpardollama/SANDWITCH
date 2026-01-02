import { ViewBeach } from '../viewmodels/views/viewbeach';

import { Injectable } from '@angular/core';

import { catchError } from 'rxjs/operators';

import { BaseService } from './base.service';

import { firstValueFrom } from 'rxjs';
import { environment } from 'src/environments/environment';

import { ViewFinder } from "../viewmodels/views/viewfinder";
import { FinderBeach } from "../viewmodels/finders/finderbeach";


@Injectable({
    providedIn: 'root',
})

export class FinderService extends BaseService {

    public constructor() {
        super();
    }

    public FindAllFinder(): Promise<ViewFinder[]> {
        return firstValueFrom(this.httpClient.get<ViewFinder[]>(`${environment.Api.Service}api/v2/finder/all`)
            .pipe(catchError(this.HandleError<ViewFinder[]>('FindAllFinder', []))));
    }

    public FindAllBeachByFinderId(viewModel: FinderBeach): Promise<ViewBeach[]> {
        return firstValueFrom(this.httpClient.post<ViewBeach[]>(`${environment.Api.Service}api/v2/finder/all/beach`, viewModel)
            .pipe(catchError(this.HandleError<ViewBeach[]>('FindAllBeachByFinderId', []))));
    }
}
