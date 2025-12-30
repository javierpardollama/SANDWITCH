import { AddTown } from '../viewmodels/additions/addtown';

import { UpdateTown } from '../viewmodels/updates/updatetown';

import { ViewPage } from '../viewmodels/views/viewpage';

import { ViewTown } from '../viewmodels/views/viewtown';

import { HttpClient } from '@angular/common/http';

import { MatSnackBar } from '@angular/material/snack-bar';

import { Injectable, inject } from '@angular/core';

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

export class TownService extends BaseService {
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

    public UpdateTown(viewModel: UpdateTown): Promise<ViewTown> {
        return firstValueFrom(this.httpClient.put<ViewTown>(`${environment.Api.Service}api/v1/town/update`, viewModel)
            .pipe(catchError(this.HandleError<ViewTown>('UpdateTown', undefined))));
    }

    public FindAllTown(): Promise<ViewCatalog[]> {
        return firstValueFrom(this.httpClient.get<ViewCatalog[]>(`${environment.Api.Service}api/v1/town/all`)
            .pipe(catchError(this.HandleError<ViewCatalog[]>('FindAllTown', []))));
    }

    public FindPaginatedTown(viewModel: FilterPage): Promise<ViewPage<ViewTown>> {
        return firstValueFrom(this.httpClient.post<ViewPage<ViewTown>>(`${environment.Api.Service}api/v1/town/page`, viewModel)
            .pipe(catchError(this.HandleError<ViewPage<ViewTown>>('FindPaginatedTown', undefined))));
    }

    public AddTown(viewModel: AddTown): Promise<ViewTown> {
        return firstValueFrom(this.httpClient.post<ViewTown>(`${environment.Api.Service}api/v1/town/create`, viewModel)
            .pipe(catchError(this.HandleError<ViewTown>('AddTown', undefined))));
    }

    public RemoveTownById(id: number): Promise<any> {
        return firstValueFrom(this.httpClient.delete<any>(`${environment.Api.Service}api/v1/town/remove/${id}`)
            .pipe(catchError(this.HandleError<any>('RemoveTownById', undefined))));
    }
}
