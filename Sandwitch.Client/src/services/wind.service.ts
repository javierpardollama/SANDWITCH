import { AddWind } from '../viewmodels/additions/addwind';

import { UpdateWind } from '../viewmodels/updates/updatewind';

import { ViewPage } from '../viewmodels/views/viewpage';

import { ViewWind } from '../viewmodels/views/viewwind';

import { Injectable } from '@angular/core';

import { catchError } from 'rxjs/operators';

import { BaseService } from './base.service';

import { FilterPage } from 'src/viewmodels/filters/filterpage';

import { firstValueFrom } from 'rxjs';

import { environment } from 'src/environments/environment';
import { ViewCatalog } from 'src/viewmodels/views/viewcatalog';

@Injectable({
    providedIn: 'root',
})

export class WindService extends BaseService {

    public constructor() {
        super();
    }

    public UpdateWind(viewModel: UpdateWind): Promise<ViewWind> {
        return firstValueFrom(this.httpClient.put<ViewWind>(`${environment.Api.Service}api/v2/wind/update`, viewModel)
            .pipe(catchError(this.HandleError<ViewWind>('UpdateWind', undefined))));
    }

    public FindAllWind(): Promise<ViewCatalog[]> {
        return firstValueFrom(this.httpClient.get<ViewCatalog[]>(`${environment.Api.Service}api/v2/wind/all`)
            .pipe(catchError(this.HandleError<ViewCatalog[]>('FindAllWind', []))));
    }

    public FindPaginatedWind(viewModel: FilterPage): Promise<ViewPage<ViewWind>> {
        return firstValueFrom(this.httpClient.post<ViewPage<ViewWind>>(`${environment.Api.Service}api/v2/wind/page`, viewModel)
            .pipe(catchError(this.HandleError<ViewPage<ViewWind>>('FindPaginatedWind', undefined))));
    }

    public AddWind(viewModel: AddWind): Promise<ViewWind> {
        return firstValueFrom(this.httpClient.post<ViewWind>(`${environment.Api.Service}api/v2/wind/create`, viewModel)
            .pipe(catchError(this.HandleError<ViewWind>('AddWind', undefined))));
    }

    public RemoveWindById(id: number): Promise<any> {
        return firstValueFrom(this.httpClient.delete<any>(`${environment.Api.Service}api/v2/wind/remove/${id}`)
            .pipe(catchError(this.HandleError<any>('RemoveWindById', undefined))));
    }
}
