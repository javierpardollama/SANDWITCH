import { AddProvincia } from '../viewmodels/additions/addprovincia';

import { UpdateProvincia } from '../viewmodels/updates/updateprovincia';

import { ViewPage } from '../viewmodels/views/viewpage';

import { ViewProvincia } from '../viewmodels/views/viewprovincia';

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

export class ProvinciaService extends BaseService {
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

    public UpdateProvincia(viewModel: UpdateProvincia): Promise<ViewProvincia> {
        return firstValueFrom(this.httpClient.put<ViewProvincia>(`${environment.Api.Service}api/v1/provincia/update`, viewModel)
            .pipe(catchError(this.HandleError<ViewProvincia>('UpdateProvincia', undefined))));
    }

    public FindAllProvincia(): Promise<ViewCatalog[]> {
        return firstValueFrom(this.httpClient.get<ViewCatalog[]>(`${environment.Api.Service}api/v1/provincia/all`)
            .pipe(catchError(this.HandleError<ViewCatalog[]>('FindAllProvincia', []))));
    }

    public FindPaginatedProvincia(viewModel: FilterPage): Promise<ViewPage<ViewProvincia>> {
        return firstValueFrom(this.httpClient.post<ViewPage<ViewProvincia>>(`${environment.Api.Service}api/v1/provincia/page`, viewModel)
            .pipe(catchError(this.HandleError<ViewPage<ViewProvincia>>('FindPaginatedProvincia', undefined))));
    }

    public AddProvincia(viewModel: AddProvincia): Promise<ViewProvincia> {
        return firstValueFrom(this.httpClient.post<ViewProvincia>(`${environment.Api.Service}api/v1/provincia/create`, viewModel)
            .pipe(catchError(this.HandleError<ViewProvincia>('AddProvincia', undefined))));
    }

    public RemoveProvinciaById(id: number): Promise<any> {
        return firstValueFrom(this.httpClient.delete<void>(`${environment.Api.Service}api/v1/provincia/remove/${id}`)
            .pipe(catchError(this.HandleError<any>('RemoveProvinciaById', undefined))));
    }
}
