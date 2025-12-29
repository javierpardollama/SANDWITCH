import { AddHistoric } from '../viewmodels/additions/addhistoric';

import { ViewHistoric } from '../viewmodels/views/viewhistoric';

import { HttpClient } from '@angular/common/http';

import { MatSnackBar } from '@angular/material/snack-bar';

import { Injectable, inject } from '@angular/core';

import { catchError } from 'rxjs/operators';

import { BaseService } from './base.service';

import { firstValueFrom } from 'rxjs';

import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';

@Injectable({
    providedIn: 'root',
})

export class HistoricService extends BaseService {
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

    public AddHistoric(viewModel: AddHistoric): Promise<ViewHistoric> {
        return firstValueFrom(this.httpClient.post<ViewHistoric>(`${environment.Api.Service}api/v2/historic/create`, viewModel)
            .pipe(catchError(this.HandleError<ViewHistoric>('AddHistoric', undefined))));
    }
}
