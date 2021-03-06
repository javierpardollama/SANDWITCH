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


@Injectable({
    providedIn: 'root',
})

export class ArenalService extends BaseService {

    public constructor(
        protected httpClient: HttpClient,
        protected matSnackBar: MatSnackBar) {
        super(httpClient, matSnackBar);
    }

    public UpdateArenal(viewModel: UpdateArenal): Promise<ViewArenal> {
        return this.httpClient.put<ViewArenal>('api/arenal/updatearenal', viewModel)
            .pipe(catchError(this.HandleError<ViewArenal>('UpdateArenal', undefined))).toPromise();
    }

    public FindAllArenal(): Promise<ViewArenal[]> {
        return this.httpClient.get<ViewArenal[]>('api/arenal/findallarenal')
            .pipe(catchError(this.HandleError<ViewArenal[]>('FindAllArenal', []))).toPromise();
    }

    public FindPaginatedArenal(viewModel: FilterPage): Promise<ViewPage<ViewArenal>> {
        return this.httpClient.post<ViewPage<ViewArenal>>('api/arenal/findpaginatedarenal', viewModel)
            .pipe(catchError(this.HandleError<ViewPage<ViewArenal>>('FindPaginatedArenal', undefined))).toPromise();
    }

    public FindAllArenalByPoblacionId(id: number): Promise<ViewArenal[]> {
        return this.httpClient.get<ViewArenal[]>('api/arenal/findallarenalbypoblacionid/' + id)
            .pipe(catchError(this.HandleError<ViewArenal[]>('FindAllArenalByPoblacionId', []))).toPromise();
    }

    public AddArenal(viewModel: AddArenal): Promise<ViewArenal> {
        return this.httpClient.post<ViewArenal>('api/arenal/addarenal', viewModel)
            .pipe(catchError(this.HandleError<ViewArenal>('AddArenal', undefined))).toPromise();
    }

    public RemoveArenalById(id: number) {
        return this.httpClient.delete<any>('api/arenal/removearenalbyid/' + id)
            .pipe(catchError(this.HandleError<any>('RemoveArenalById', undefined)));
    }
}
