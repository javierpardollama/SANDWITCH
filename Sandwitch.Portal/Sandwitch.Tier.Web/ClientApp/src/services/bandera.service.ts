import { AddBandera } from './../viewmodels/additions/addbandera';

import { UpdateBandera } from './../viewmodels/updates/updatebandera';

import { ViewPage } from './../viewmodels/views/viewpage';

import { ViewBandera } from './../viewmodels/views/viewbandera';

import { HttpClient } from '@angular/common/http';

import { MatSnackBar } from '@angular/material/snack-bar';

import { Injectable } from '@angular/core';

import { catchError } from 'rxjs/operators';

import { BaseService } from './base.service';

import { FilterPage } from 'src/viewmodels/filters/filterpage';

@Injectable({
    providedIn: 'root',
})

export class BanderaService extends BaseService {

    public constructor(
        protected httpClient: HttpClient,
        protected matSnackBar: MatSnackBar) {
        super(httpClient, matSnackBar);
    }

    public UpdateBandera(viewModel: UpdateBandera): Promise<ViewBandera> {
        return this.httpClient.put<ViewBandera>('api/bandera/updatebandera', viewModel)
            .pipe(catchError(this.HandleError<ViewBandera>('UpdateBandera', undefined))).toPromise();
    }

    public FindAllBandera(): Promise<ViewBandera[]> {
        return this.httpClient.get<ViewBandera[]>('api/bandera/findallbandera')
            .pipe(catchError(this.HandleError<ViewBandera[]>('FindAllBandera', []))).toPromise();
    }

    public FindPaginatedBandera(viewModel: FilterPage): Promise<ViewPage<ViewBandera>> {
        return this.httpClient.post<ViewPage<ViewBandera>>('api/bandera/findpaginatedbandera', viewModel)
            .pipe(catchError(this.HandleError<ViewPage<ViewBandera>>('FindPaginatedBandera', undefined))).toPromise();
    }

    public AddBandera(viewModel: AddBandera): Promise<ViewBandera> {
        return this.httpClient.post<ViewBandera>('api/bandera/addbandera', viewModel)
            .pipe(catchError(this.HandleError<ViewBandera>('AddBandera', undefined))).toPromise();
    }

    public RemoveBanderaById(id: number) {
        return this.httpClient.delete<any>('api/bandera/removebanderabyid/' + id)
            .pipe(catchError(this.HandleError<any>('RemoveBanderaById', undefined)));
    }
}
