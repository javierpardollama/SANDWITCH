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

@Injectable({
    providedIn: 'root',
})

export class ProvinciaService extends BaseService {

    public constructor(
        protected httpClient: HttpClient,
        protected matSnackBar: MatSnackBar) {
        super(httpClient, matSnackBar);
    }

    public UpdateProvincia(viewModel: UpdateProvincia): Promise<ViewProvincia> {
        return this.httpClient.put<ViewProvincia>('api/provincia/updateprovincia', viewModel)
            .pipe(catchError(this.HandleError<ViewProvincia>('UpdateProvincia', undefined))).toPromise();
    }

    public FindAllProvincia(): Promise<ViewProvincia[]> {
        return this.httpClient.get<ViewProvincia[]>('api/provincia/findallprovincia')
            .pipe(catchError(this.HandleError<ViewProvincia[]>('FindAllProvincia', []))).toPromise();
    }

    public FindPaginatedProvincia(viewModel: FilterPage): Promise<ViewPage<ViewProvincia>> {
        return this.httpClient.post<ViewPage<ViewProvincia>>('api/provincia/findpaginatedprovincia', viewModel)
            .pipe(catchError(this.HandleError<ViewPage<ViewProvincia>>('FindPaginatedProvincia', undefined))).toPromise();
    }

    public AddProvincia(viewModel: AddProvincia): Promise<ViewProvincia> {
        return this.httpClient.post<ViewProvincia>('api/provincia/addprovincia', viewModel)
            .pipe(catchError(this.HandleError<ViewProvincia>('AddProvincia', undefined))).toPromise();
    }

    public RemoveProvinciaById(id: number) {
        return this.httpClient.delete<any>('api/provincia/removeprovinciabyid/' + id)
            .pipe(catchError(this.HandleError<any>('RemoveProvinciaById', undefined)));
    }
}
