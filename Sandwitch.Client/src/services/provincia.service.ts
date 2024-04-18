import { AddProvincia } from '../viewmodels/additions/addprovincia';

import { UpdateProvincia } from '../viewmodels/updates/updateprovincia';

import { ViewPage } from './../viewmodels/views/viewpage';

import { ViewProvincia } from '../viewmodels/views/viewprovincia';

import { HttpClient } from '@angular/common/http';

import { MatSnackBar } from '@angular/material/snack-bar';

import { Injectable } from '@angular/core';

import { catchError } from 'rxjs/operators';

import { BaseService } from './base.service';

import { FilterPage } from 'src/viewmodels/filters/filterpage';

import { firstValueFrom } from 'rxjs';

import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';

@Injectable({
    providedIn: 'root',
})

export class ProvinciaService extends BaseService {

    public constructor(
        protected override httpClient: HttpClient,
        protected override matSnackBar: MatSnackBar,
        protected override router: Router) {
        super(httpClient, matSnackBar, router);
    }

    public UpdateProvincia(viewModel: UpdateProvincia): Promise<ViewProvincia> {
        return firstValueFrom(this.httpClient.put<ViewProvincia>(`${environment.Api.Service}api/provincia/updateprovincia`, viewModel)
            .pipe(catchError(this.HandleError<ViewProvincia>('UpdateProvincia', undefined))));
    }

    public FindAllProvincia(): Promise<ViewProvincia[]> {
        return firstValueFrom(this.httpClient.get<ViewProvincia[]>(`${environment.Api.Service}api/provincia/findallprovincia`)
            .pipe(catchError(this.HandleError<ViewProvincia[]>('FindAllProvincia', []))));
    }

    public FindPaginatedProvincia(viewModel: FilterPage): Promise<ViewPage<ViewProvincia>> {
        return firstValueFrom(this.httpClient.post<ViewPage<ViewProvincia>>(`${environment.Api.Service}api/provincia/findpaginatedprovincia`, viewModel)
            .pipe(catchError(this.HandleError<ViewPage<ViewProvincia>>('FindPaginatedProvincia', undefined))));
    }

    public AddProvincia(viewModel: AddProvincia): Promise<ViewProvincia> {
        return firstValueFrom(this.httpClient.post<ViewProvincia>(`${environment.Api.Service}api/provincia/addprovincia`, viewModel)
            .pipe(catchError(this.HandleError<ViewProvincia>('AddProvincia', undefined))));
    }

    public RemoveProvinciaById(id: number): Promise<any> {
        return firstValueFrom(this.httpClient.delete<void>(`${environment.Api.Service}api/provincia/removeprovinciabyid/${id}`)
            .pipe(catchError(this.HandleError<any>('RemoveProvinciaById', undefined))));
    }
}
