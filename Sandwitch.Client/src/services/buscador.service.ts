import { ViewArenal } from '../viewmodels/views/viewarenal';

import { HttpClient } from '@angular/common/http';

import { MatSnackBar } from '@angular/material/snack-bar';

import { Injectable, inject } from '@angular/core';

import { catchError } from 'rxjs/operators';

import { BaseService } from './base.service';

import { firstValueFrom } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';

import { ViewBuscador } from "../viewmodels/views/viewbuscador";
import { FinderArenal } from "../viewmodels/finders/finderarenal";


@Injectable({
    providedIn: 'root',
})

export class BuscadorService extends BaseService {
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

    public FindAllBuscador(): Promise<ViewBuscador[]> {
        return firstValueFrom(this.httpClient.get<ViewBuscador[]>(`${environment.Api.Service}api/v2/buscador/all`)
            .pipe(catchError(this.HandleError<ViewBuscador[]>('FindAllBuscador', []))));
    }

    public FindAllArenalByBuscadorId(viewModel: FinderArenal): Promise<ViewArenal[]> {
        return firstValueFrom(this.httpClient.post<ViewArenal[]>(`${environment.Api.Service}api/v2/buscador/all/arenal`, viewModel)
            .pipe(catchError(this.HandleError<ViewArenal[]>('FindAllArenalByBuscadorId', []))));
    }
}
