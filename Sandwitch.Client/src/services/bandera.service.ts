import { AddBandera } from '../viewmodels/additions/addbandera';

import { UpdateBandera } from '../viewmodels/updates/updatebandera';

import { ViewPage } from '../viewmodels/views/viewpage';

import { ViewBandera } from '../viewmodels/views/viewbandera';

import { HttpClient } from '@angular/common/http';

import { MatSnackBar } from '@angular/material/snack-bar';

import { Injectable, inject } from '@angular/core';

import { catchError } from 'rxjs/operators';

import { BaseService } from './base.service';

import { FilterPage } from '../viewmodels/filters/filterpage';

import { firstValueFrom } from 'rxjs';

import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';
import { ViewCatalog } from 'src/viewmodels/views/viewcatalog';

@Injectable({
    providedIn: 'root',
})

export class BanderaService extends BaseService {
    protected override httpClient: HttpClient;
    protected override matSnackBar: MatSnackBar;
    protected override router: Router;

    public constructor() {
        const httpClient = inject(HttpClient);
        const matSnackBar = inject(MatSnackBar);
        const router = inject(Router);

        super(httpClient, matSnackBar, router);
    
        this.httpClient = httpClient;
        this.matSnackBar = matSnackBar;
        this.router = router;
    }

    public UpdateBandera(viewModel: UpdateBandera): Promise<ViewBandera> {
        return firstValueFrom(this.httpClient.put<ViewBandera>(`${environment.Api.Service}api/v1/bandera/update`, viewModel)
            .pipe(catchError(this.HandleError<ViewBandera>('UpdateBandera', undefined))));
    }

    public FindAllBandera(): Promise<ViewCatalog[]> {
        return firstValueFrom(this.httpClient.get<ViewCatalog[]>(`${environment.Api.Service}api/v1/bandera/all`)
            .pipe(catchError(this.HandleError<ViewCatalog[]>('FindAllBandera', []))));
    }

    public FindPaginatedBandera(viewModel: FilterPage): Promise<ViewPage<ViewBandera>> {
        return firstValueFrom(this.httpClient.post<ViewPage<ViewBandera>>(`${environment.Api.Service}api/v1/bandera/page`, viewModel)
            .pipe(catchError(this.HandleError<ViewPage<ViewBandera>>('FindPaginatedBandera', undefined))));
    }

    public AddBandera(viewModel: AddBandera): Promise<ViewBandera> {
        return firstValueFrom(this.httpClient.post<ViewBandera>(`${environment.Api.Service}api/v1/bandera/create`, viewModel)
            .pipe(catchError(this.HandleError<ViewBandera>('AddBandera', undefined))));
    }

    public RemoveBanderaById(id: number): Promise<any> {
        return firstValueFrom(this.httpClient.delete<any>(`${environment.Api.Service}api/v1/bandera/remove/${id}`)
            .pipe(catchError(this.HandleError<any>('RemoveBanderaById', undefined))));
    }
}
