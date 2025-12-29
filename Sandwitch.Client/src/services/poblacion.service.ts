import { AddPoblacion } from '../viewmodels/additions/addpoblacion';

import { UpdatePoblacion } from '../viewmodels/updates/updatepoblacion';

import { ViewPage } from '../viewmodels/views/viewpage';

import { ViewPoblacion } from '../viewmodels/views/viewpoblacion';

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

export class PoblacionService extends BaseService {
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

    public UpdatePoblacion(viewModel: UpdatePoblacion): Promise<ViewPoblacion> {
        return firstValueFrom(this.httpClient.put<ViewPoblacion>(`${environment.Api.Service}api/v1/poblacion/update`, viewModel)
            .pipe(catchError(this.HandleError<ViewPoblacion>('UpdatePoblacion', undefined))));
    }

    public FindAllPoblacion(): Promise<ViewCatalog[]> {
        return firstValueFrom(this.httpClient.get<ViewCatalog[]>(`${environment.Api.Service}api/v1/poblacion/all`)
            .pipe(catchError(this.HandleError<ViewCatalog[]>('FindAllPoblacion', []))));
    }

    public FindPaginatedPoblacion(viewModel: FilterPage): Promise<ViewPage<ViewPoblacion>> {
        return firstValueFrom(this.httpClient.post<ViewPage<ViewPoblacion>>(`${environment.Api.Service}api/v1/poblacion/page`, viewModel)
            .pipe(catchError(this.HandleError<ViewPage<ViewPoblacion>>('FindPaginatedPoblacion', undefined))));
    }

    public AddPoblacion(viewModel: AddPoblacion): Promise<ViewPoblacion> {
        return firstValueFrom(this.httpClient.post<ViewPoblacion>(`${environment.Api.Service}api/v1/poblacion/create`, viewModel)
            .pipe(catchError(this.HandleError<ViewPoblacion>('AddPoblacion', undefined))));
    }

    public RemovePoblacionById(id: number): Promise<any> {
        return firstValueFrom(this.httpClient.delete<any>(`${environment.Api.Service}api/v1/poblacion/remove/${id}`)
            .pipe(catchError(this.HandleError<any>('RemovePoblacionById', undefined))));
    }
}
