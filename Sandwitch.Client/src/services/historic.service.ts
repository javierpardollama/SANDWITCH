import { AddHistoric } from '../viewmodels/additions/addhistoric';

import { ViewHistoric } from '../viewmodels/views/viewhistoric';



import { Injectable } from '@angular/core';

import { catchError } from 'rxjs/operators';

import { BaseService } from './base.service';

import { firstValueFrom } from 'rxjs';

import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root',
})

export class HistoricService extends BaseService {

    public constructor() {
        super();
    }

    public AddHistoric(viewModel: AddHistoric): Promise<ViewHistoric> {
        return firstValueFrom(this.httpClient.post<ViewHistoric>(`${environment.Api.Service}api/v2/historic/create`, viewModel)
            .pipe(catchError(this.HandleError<ViewHistoric>('AddHistoric', undefined))));
    }
}
