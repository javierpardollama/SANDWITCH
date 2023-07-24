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

import { firstValueFrom } from 'rxjs';

import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root',
})

export class BanderaService extends BaseService {

    public constructor(
        protected override httpClient: HttpClient,
        protected override matSnackBar: MatSnackBar) {
        super(httpClient, matSnackBar);
    }

    public UpdateBandera(viewModel: UpdateBandera): Promise<ViewBandera> {
        return firstValueFrom(this.httpClient.put<ViewBandera>(`${environment.Api.Service}api/bandera/updatebandera`, viewModel)
            .pipe(catchError(this.HandleError<ViewBandera>('UpdateBandera', undefined))));
    }

    public FindAllBandera(): Promise<ViewBandera[]> {
        return firstValueFrom(this.httpClient.get<ViewBandera[]>(`${environment.Api.Service}api/bandera/findallbandera`)
            .pipe(catchError(this.HandleError<ViewBandera[]>('FindAllBandera', []))));
    }

    public FindPaginatedBandera(viewModel: FilterPage): Promise<ViewPage<ViewBandera>> {
        return firstValueFrom(this.httpClient.post<ViewPage<ViewBandera>>(`${environment.Api.Service}api/bandera/findpaginatedbandera`, viewModel)
            .pipe(catchError(this.HandleError<ViewPage<ViewBandera>>('FindPaginatedBandera', undefined))));
    }

    public AddBandera(viewModel: AddBandera): Promise<ViewBandera> {
        return firstValueFrom(this.httpClient.post<ViewBandera>(`${environment.Api.Service}api/bandera/addbandera`, viewModel)
            .pipe(catchError(this.HandleError<ViewBandera>('AddBandera', undefined))));
    }

    public RemoveBanderaById(id: number): Promise<any> {
        return firstValueFrom(this.httpClient.delete<any>(`${environment.Api.Service}api/bandera/removebanderabyid/${id}`)
            .pipe(catchError(this.HandleError<any>('RemoveBanderaById', undefined))));
    }
}
