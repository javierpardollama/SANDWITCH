import { AddFlag } from '../viewmodels/additions/addflag';

import { UpdateFlag } from '../viewmodels/updates/updateflag';

import { ViewPage } from '../viewmodels/views/viewpage';

import { ViewFlag } from '../viewmodels/views/viewflag';

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

export class FlagService extends BaseService {
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

    public UpdateFlag(viewModel: UpdateFlag): Promise<ViewFlag> {
        return firstValueFrom(this.httpClient.put<ViewFlag>(`${environment.Api.Service}api/v1/flag/update`, viewModel)
            .pipe(catchError(this.HandleError<ViewFlag>('UpdateFlag', undefined))));
    }

    public FindAllFlag(): Promise<ViewCatalog[]> {
        return firstValueFrom(this.httpClient.get<ViewCatalog[]>(`${environment.Api.Service}api/v1/flag/all`)
            .pipe(catchError(this.HandleError<ViewCatalog[]>('FindAllFlag', []))));
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
