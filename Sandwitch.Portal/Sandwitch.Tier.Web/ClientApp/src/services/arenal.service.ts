import { AddArenal } from './../viewmodels/additions/addarenal';
import { UpdateArenal } from './../viewmodels/updates/updatearenal';
import { ViewArenal } from './../viewmodels/views/viewarenal';
import { HttpClient } from '@angular/common/http';
import { MatSnackBar } from '@angular/material';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { BaseService } from './base.service';

@Injectable({
    providedIn: 'root',
})

export class ArenalService extends BaseService {

    public constructor(
        protected httpClient: HttpClient,
        protected matSnackBar: MatSnackBar) {
        super(httpClient, matSnackBar);
    }

    public UpdateArenal(viewModel: UpdateArenal): Observable<ViewArenal> {
        return this.httpClient.put<ViewArenal>('api/arenal/updatearenal', viewModel)
            .pipe(catchError(this.HandleError<ViewArenal>('UpdateArenal', undefined)));
    }

    public FindAllArenal(): Observable<ViewArenal[]> {
        return this.httpClient.get<ViewArenal[]>('api/arenal/findallarenal')
            .pipe(catchError(this.HandleError<ViewArenal[]>('FindAllArenal', [])));
    }

    public FindAllArenalByPoblacionId(id: number): Observable<ViewArenal[]> {
        return this.httpClient.get<ViewArenal[]>('api/arenal/findallarenalbypoblacionid/' + id)
            .pipe(catchError(this.HandleError<ViewArenal[]>('FindAllArenalByPoblacionId', [])));
    }

    public AddArenal(viewModel: AddArenal): Observable<ViewArenal> {
        return this.httpClient.post<ViewArenal>('api/arenal/addarenal', viewModel)
            .pipe(catchError(this.HandleError<ViewArenal>('AddArenal', undefined)));
    }

    public RemoveArenalById(id: number) {
        return this.httpClient.delete<any>('api/arenal/removearenalbyid/' + id)
            .pipe(catchError(this.HandleError<any>('RemoveArenalById', undefined)));
    }
}