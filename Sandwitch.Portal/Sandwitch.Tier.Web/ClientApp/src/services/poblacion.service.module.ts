import { AddPoblacion } from './../viewmodels/additions/addpoblacion';
import { UpdatePoblacion } from './../viewmodels/updates/updatepoblacion';
import { ViewPoblacion } from './../viewmodels/views/viewpoblacion';
import { HttpClient } from '@angular/common/http';
import { MatSnackBar } from '@angular/material';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { BaseService } from './base.service.module';

@Injectable({
    providedIn: 'root',
})

export class PoblacionService extends BaseService {

    public constructor(
        protected httpClient: HttpClient,
        protected matSnackBar: MatSnackBar) {
        super(httpClient, matSnackBar);
    }

    public UpdatePoblacion(viewModel: UpdatePoblacion): Observable<ViewPoblacion> {
        return this.httpClient.put<ViewPoblacion>('api/poblacion/updatepoblacion', viewModel)
            .pipe(catchError(this.HandleError<ViewPoblacion>('UpdatePoblacion', undefined)));
    }

    public FindAllPoblacion(): Observable<ViewPoblacion[]> {
        return this.httpClient.get<ViewPoblacion[]>('api/poblacion/findallpoblacion')
            .pipe(catchError(this.HandleError<ViewPoblacion[]>('FindAllPoblacion', [])));
    }

    public FindAllPoblacionByProvinciaId(id: number): Observable<ViewPoblacion[]> {
        return this.httpClient.get<ViewPoblacion[]>('api/poblacion/findallpoblacionbyprovinciaid/' + id)
            .pipe(catchError(this.HandleError<ViewPoblacion[]>('FindAllPoblacionByProvinciaId', [])));
    }

    public AddPoblacion(viewModel: AddPoblacion): Observable<ViewPoblacion> {
        return this.httpClient.post<ViewPoblacion>('api/poblacion/addpoblacion', viewModel)
            .pipe(catchError(this.HandleError<ViewPoblacion>('AddPoblacion', undefined)));
    }

    public RemovePoblacionById(id: number) {
        return this.httpClient.delete<any>('api/poblacion/removepoblacionbyid/' + id)
            .pipe(catchError(this.HandleError<any>('RemovePoblacionById', undefined)));
    }
}
