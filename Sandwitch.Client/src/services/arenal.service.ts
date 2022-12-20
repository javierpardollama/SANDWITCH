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


@Injectable({
    providedIn: 'root',
})

export class ArenalService extends BaseService {

    public constructor(
        protected override httpClient: HttpClient,
        protected override matSnackBar: MatSnackBar) {
        super(httpClient, matSnackBar);
    }

    public UpdateArenal(viewModel: UpdateArenal): Promise<ViewArenal> {
        return firstValueFrom(this.httpClient.put<ViewArenal>(`${environment.Api.Service}api/arenal/updatearenal`, viewModel)
            .pipe(catchError(this.HandleError<ViewArenal>('UpdateArenal', undefined))));
    }

    public FindAllArenal(): Promise<ViewArenal[]> {
        return firstValueFrom(this.httpClient.get<ViewArenal[]>(`${environment.Api.Service}api/arenal/findallarenal`)
            .pipe(catchError(this.HandleError<ViewArenal[]>('FindAllArenal', []))));
    }

    public FindPaginatedArenal(viewModel: FilterPage): Promise<ViewPage<ViewArenal>> {
        return firstValueFrom(this.httpClient.post<ViewPage<ViewArenal>>(`${environment.Api.Service}api/arenal/findpaginatedarenal`, viewModel)
            .pipe(catchError(this.HandleError<ViewPage<ViewArenal>>('FindPaginatedArenal', undefined))));
    }

    public FindAllArenalByPoblacionId(id: number): Promise<ViewArenal[]> {
        return firstValueFrom(this.httpClient.get<ViewArenal[]>(`${environment.Api.Service}api/arenal/findallarenalbypoblacionid/` + id)
            .pipe(catchError(this.HandleError<ViewArenal[]>('FindAllArenalByPoblacionId', []))));
    }

    public AddArenal(viewModel: AddArenal): Promise<ViewArenal> {
        return firstValueFrom(this.httpClient.post<ViewArenal>(`${environment.Api.Service}api/arenal/addarenal`, viewModel)
            .pipe(catchError(this.HandleError<ViewArenal>('AddArenal', undefined))));
    }

    public RemoveArenalById(id: number): Promise<any> {
        return firstValueFrom(this.httpClient.delete<any>(`${environment.Api.Service}api/arenal/removearenalbyid/` + id)
            .pipe(catchError(this.HandleError<any>('RemoveArenalById', undefined))));
    }
}
