import { AddProvincia } from '../viewmodels/additions/addprovincia';

import { UpdateProvincia } from '../viewmodels/updates/updateprovincia';

import { ViewProvincia } from '../viewmodels/views/viewprovincia';

import { HttpClient } from '@angular/common/http';

import { MatSnackBar } from '@angular/material';

import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';

import { catchError } from 'rxjs/operators';

import { BaseService } from './base.service';

@Injectable({
    providedIn: 'root',
})

export class ProvinciaService extends BaseService {

    public constructor(
        protected httpClient: HttpClient,
        protected matSnackBar: MatSnackBar) {
        super(httpClient, matSnackBar);
    }

    public UpdateProvincia(viewModel: UpdateProvincia): Observable<ViewProvincia> {
        return this.httpClient.put<ViewProvincia>('api/provincia/updateprovincia', viewModel)
            .pipe(catchError(this.HandleError<ViewProvincia>('UpdateProvincia', undefined)));
    }

    public FindAllProvincia(): Observable<ViewProvincia[]> {
        return this.httpClient.get<ViewProvincia[]>('api/provincia/findallprovincia')
            .pipe(catchError(this.HandleError<ViewProvincia[]>('FindAllProvincia', [])));
    }

    public AddProvincia(viewModel: AddProvincia): Observable<ViewProvincia> {
        return this.httpClient.post<ViewProvincia>('api/provincia/addprovincia', viewModel)
            .pipe(catchError(this.HandleError<ViewProvincia>('AddProvincia', undefined)));
    }

    public RemoveProvinciaById(id: number) {
        return this.httpClient.delete<any>('api/provincia/removeprovinciabyid/' + id)
            .pipe(catchError(this.HandleError<any>('RemoveProvinciaById', undefined)));
    }
}
