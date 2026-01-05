import { AddState } from '../viewmodels/additions/addstate';

import { UpdateState } from '../viewmodels/updates/updatestate';

import { ViewPage } from '../viewmodels/views/viewpage';

import { ViewState } from '../viewmodels/views/viewstate';

import { Injectable } from '@angular/core';

import { catchError, shareReplay } from 'rxjs/operators';

import { BaseService } from './base.service';

import { FilterPage } from 'src/viewmodels/filters/filterpage';

import { firstValueFrom } from 'rxjs';

import { environment } from 'src/environments/environment';
import { ViewCatalog } from 'src/viewmodels/views/viewcatalog';

@Injectable({
    providedIn: 'root',
})

export class StateService extends BaseService {

    public constructor() {
        super();
    }

    public UpdateState(viewModel: UpdateState): Promise<ViewState> {
        return firstValueFrom(this.httpClient.put<ViewState>(`${environment.Api.Service}api/v1/state/update`, viewModel)
            .pipe(catchError(this.HandleError<ViewState>('UpdateState', undefined))));
    }

    public FindAllState(): Promise<ViewCatalog[]> {
        return firstValueFrom(this.httpClient.get<ViewCatalog[]>(`${environment.Api.Service}api/v1/state/all`)
            .pipe(
                // Cache the latest emission
                shareReplay({ bufferSize: 1, refCount: true }),
                catchError(this.HandleError<ViewCatalog[]>('FindAllState', []))));
    }

    public FindPaginatedState(viewModel: FilterPage): Promise<ViewPage<ViewState>> {
        return firstValueFrom(this.httpClient.post<ViewPage<ViewState>>(`${environment.Api.Service}api/v1/state/page`, viewModel)
            .pipe(catchError(this.HandleError<ViewPage<ViewState>>('FindPaginatedState', undefined))));
    }

    public AddState(viewModel: AddState): Promise<ViewState> {
        return firstValueFrom(this.httpClient.post<ViewState>(`${environment.Api.Service}api/v1/state/create`, viewModel)
            .pipe(catchError(this.HandleError<ViewState>('AddState', undefined))));
    }

    public RemoveStateById(id: number): Promise<any> {
        return firstValueFrom(this.httpClient.delete<void>(`${environment.Api.Service}api/v1/state/remove/${id}`)
            .pipe(catchError(this.HandleError<any>('RemoveStateById', undefined))));
    }
}
