import { AddViento } from '../viewmodels/additions/addviento';

import { UpdateViento } from '../viewmodels/updates/updateviento';

import { ViewPage } from '../viewmodels/views/viewpage';

import { ViewViento } from '../viewmodels/views/viewviento';

import { HttpClient } from '@angular/common/http';

import { MatSnackBar } from '@angular/material/snack-bar';

import { Injectable } from '@angular/core';

import { catchError } from 'rxjs/operators';

import { BaseService } from './base.service';

import { FilterPage } from 'src/viewmodels/filters/filterpage';

import { firstValueFrom } from 'rxjs';

import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';
import { ViewCatalog } from 'src/viewmodels/views/viewcatalog';

@Injectable({
    providedIn: 'root',
})

export class VientoService extends BaseService {

    public constructor(
        protected override httpClient: HttpClient,
        protected override matSnackBar: MatSnackBar,
        protected override router: Router) {
        super(httpClient, matSnackBar, router);
    }

    public UpdateViento(viewModel: UpdateViento): Promise<ViewViento> {
        return firstValueFrom(this.httpClient.put<ViewViento>(`${environment.Api.Service}api/v2/viento/update`, viewModel)
            .pipe(catchError(this.HandleError<ViewViento>('UpdateViento', undefined))));
    }

    public FindAllViento(): Promise<ViewCatalog[]> {
        return firstValueFrom(this.httpClient.get<ViewCatalog[]>(`${environment.Api.Service}api/v2/viento/all`)
            .pipe(catchError(this.HandleError<ViewCatalog[]>('FindAllViento', []))));
    }

    public FindPaginatedViento(viewModel: FilterPage): Promise<ViewPage<ViewViento>> {
        return firstValueFrom(this.httpClient.post<ViewPage<ViewViento>>(`${environment.Api.Service}api/v2/viento/page`, viewModel)
            .pipe(catchError(this.HandleError<ViewPage<ViewViento>>('FindPaginatedViento', undefined))));
    }

    public AddViento(viewModel: AddViento): Promise<ViewViento> {
        return firstValueFrom(this.httpClient.post<ViewViento>(`${environment.Api.Service}api/v2/viento/create`, viewModel)
            .pipe(catchError(this.HandleError<ViewViento>('AddViento', undefined))));
    }

    public RemoveVientoById(id: number): Promise<any> {
        return firstValueFrom(this.httpClient.delete<any>(`${environment.Api.Service}api/v2/viento/remove/${id}`)
            .pipe(catchError(this.HandleError<any>('RemoveVientoById', undefined))));
    }
}
