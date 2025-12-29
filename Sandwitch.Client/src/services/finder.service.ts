import { ViewBeach } from '../viewmodels/views/viewbeach';

import { HttpClient } from '@angular/common/http';

import { MatSnackBar } from '@angular/material/snack-bar';

import { Injectable, inject } from '@angular/core';

import { catchError } from 'rxjs/operators';

import { BaseService } from './base.service';

import { firstValueFrom } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';

import { ViewFinder } from "../viewmodels/views/viewfinder";
import { FinderBeach } from "../viewmodels/finders/finderbeach";


@Injectable({
    providedIn: 'root',
})

export class FinderService extends BaseService {
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

    public FindAllFinder(): Promise<ViewFinder[]> {
        return firstValueFrom(this.httpClient.get<ViewFinder[]>(`${environment.Api.Service}api/v2/finder/all`)
            .pipe(catchError(this.HandleError<ViewFinder[]>('FindAllFinder', []))));
    }

    public FindAllBeachByFinderId(viewModel: FinderBeach): Promise<ViewBeach[]> {
        return firstValueFrom(this.httpClient.post<ViewBeach[]>(`${environment.Api.Service}api/v2/finder/all/beach`, viewModel)
            .pipe(catchError(this.HandleError<ViewBeach[]>('FindAllBeachByFinderId', []))));
    }
}
