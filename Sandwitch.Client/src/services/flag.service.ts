import { AddFlag } from '../viewmodels/additions/addflag';

import { UpdateFlag } from '../viewmodels/updates/updateflag';

import { ViewPage } from '../viewmodels/views/viewpage';

import { ViewFlag } from '../viewmodels/views/viewflag';

import { Injectable } from '@angular/core';

import { catchError, shareReplay } from 'rxjs/operators';

import { BaseService } from './base.service';

import { FilterPage } from '../viewmodels/filters/filterpage';

import { firstValueFrom } from 'rxjs';

import { environment } from 'src/environments/environment';
import { ViewCatalog } from 'src/viewmodels/views/viewcatalog';

@Injectable({
    providedIn: 'root',
})

export class FlagService extends BaseService {

    public constructor() {
        super();
    }

    public UpdateFlag(viewModel: UpdateFlag): Promise<ViewFlag> {
        return firstValueFrom(this.httpClient.put<ViewFlag>(`${environment.Api.Service}api/v1/flag/update`, viewModel)
            .pipe(catchError(this.HandleError<ViewFlag>('UpdateFlag', undefined))));
    }

    public FindAllFlag(): Promise<ViewCatalog[]> {
        return firstValueFrom(this.httpClient.get<ViewCatalog[]>(`${environment.Api.Service}api/v1/flag/all`)
            .pipe(
                  // Cache the latest emission
                shareReplay({ bufferSize: 1, refCount: true }),
                catchError(this.HandleError<ViewCatalog[]>('FindAllFlag', []))));
    }

    public FindPaginatedFlag(viewModel: FilterPage): Promise<ViewPage<ViewFlag>> {
        return firstValueFrom(this.httpClient.post<ViewPage<ViewFlag>>(`${environment.Api.Service}api/v1/flag/page`, viewModel)
            .pipe(catchError(this.HandleError<ViewPage<ViewFlag>>('FindPaginatedFlag', undefined))));
    }

    public AddFlag(viewModel: AddFlag): Promise<ViewFlag> {
        return firstValueFrom(this.httpClient.post<ViewFlag>(`${environment.Api.Service}api/v1/flag/create`, viewModel)
            .pipe(catchError(this.HandleError<ViewFlag>('AddFlag', undefined))));
    }

    public RemoveFlagById(id: number): Promise<any> {
        return firstValueFrom(this.httpClient.delete<any>(`${environment.Api.Service}api/v1/flag/remove/${id}`)
            .pipe(catchError(this.HandleError<any>('RemoveFlagById', undefined))));
    }
}
