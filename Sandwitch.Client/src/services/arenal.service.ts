import { AddArenal } from './../viewmodels/additions/addarenal';

import { UpdateArenal } from './../viewmodels/updates/updatearenal';

import { ViewPage } from './../viewmodels/views/viewpage';

import { ViewArenal } from './../viewmodels/views/viewarenal';

import { HttpClient } from '@angular/common/http';

import { MatSnackBar } from '@angular/material/snack-bar';

import { Injectable } from '@angular/core';

import { catchError } from 'rxjs/operators';

import { BaseService } from './base.service';

import { FilterPage } from 'src/viewmodels/filters/filterpage';

import { firstValueFrom } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';


@Injectable({
    providedIn: 'root',
})

export class ArenalService extends BaseService {

    public constructor(
        protected override httpClient: HttpClient,
        protected override matSnackBar: MatSnackBar,
        protected override router: Router) {
        super(httpClient, matSnackBar, router);
    }

    public UpdateArenal(viewModel: UpdateArenal): Promise<ViewArenal> {
        return firstValueFrom(this.httpClient.put<ViewArenal>(`${environment.Api.Service}api/v1/arenal/update`, viewModel)
            .pipe(catchError(this.HandleError<ViewArenal>('UpdateArenal', undefined))));
    }

    public FindPaginatedArenal(viewModel: FilterPage): Promise<ViewPage<ViewArenal>> {
        return firstValueFrom(this.httpClient.post<ViewPage<ViewArenal>>(`${environment.Api.Service}api/v1/arenal/page`, viewModel)
            .pipe(catchError(this.HandleError<ViewPage<ViewArenal>>('FindPaginatedArenal', undefined))));
    }

    public AddArenal(viewModel: AddArenal): Promise<ViewArenal> {
        return firstValueFrom(this.httpClient.post<ViewArenal>(`${environment.Api.Service}api/v1/arenal/create`, viewModel)
            .pipe(catchError(this.HandleError<ViewArenal>('AddArenal', undefined))));
    }

    public RemoveArenalById(id: number): Promise<any> {
        return firstValueFrom(this.httpClient.delete<any>(`${environment.Api.Service}api/v1/arenal/remove/${id}`)
            .pipe(catchError(this.HandleError<any>('RemoveArenalById', undefined))));
    }
}
