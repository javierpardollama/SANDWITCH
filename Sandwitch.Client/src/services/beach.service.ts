import { AddBeach } from '../viewmodels/additions/addbeach';

import { UpdateBeach } from '../viewmodels/updates/updatebeach';

import { ViewPage } from '../viewmodels/views/viewpage';

import { ViewBeach } from '../viewmodels/views/viewbeach';

import { HttpClient } from '@angular/common/http';

import { MatSnackBar } from '@angular/material/snack-bar';

import { Injectable, inject } from '@angular/core';

import { catchError } from 'rxjs/operators';

import { BaseService } from './base.service';

import { FilterPage } from 'src/viewmodels/filters/filterpage';

import { firstValueFrom } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';


@Injectable({
    providedIn: 'root',
})

export class BeachService extends BaseService {
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

    public UpdateBeach(viewModel: UpdateBeach): Promise<ViewBeach> {
        return firstValueFrom(this.httpClient.put<ViewBeach>(`${environment.Api.Service}api/v1/beach/update`, viewModel)
            .pipe(catchError(this.HandleError<ViewBeach>('UpdateBeach', undefined))));
    }

    public FindPaginatedBeach(viewModel: FilterPage): Promise<ViewPage<ViewBeach>> {
        return firstValueFrom(this.httpClient.post<ViewPage<ViewBeach>>(`${environment.Api.Service}api/v1/beach/page`, viewModel)
            .pipe(catchError(this.HandleError<ViewPage<ViewBeach>>('FindPaginatedBeach', undefined))));
    }

    public AddBeach(viewModel: AddBeach): Promise<ViewBeach> {
        return firstValueFrom(this.httpClient.post<ViewBeach>(`${environment.Api.Service}api/v1/beach/create`, viewModel)
            .pipe(catchError(this.HandleError<ViewBeach>('AddBeach', undefined))));
    }

    public RemoveBeachById(id: number): Promise<any> {
        return firstValueFrom(this.httpClient.delete<any>(`${environment.Api.Service}api/v1/beach/remove/${id}`)
            .pipe(catchError(this.HandleError<any>('RemoveBeachById', undefined))));
    }
}
