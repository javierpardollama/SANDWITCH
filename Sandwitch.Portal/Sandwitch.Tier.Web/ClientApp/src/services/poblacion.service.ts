import { AddPoblacion } from './../viewmodels/additions/addpoblacion';

import { UpdatePoblacion } from './../viewmodels/updates/updatepoblacion';

import { ViewPoblacion } from './../viewmodels/views/viewpoblacion';

import { HttpClient } from '@angular/common/http';

import { MatSnackBar } from '@angular/material/snack-bar';

import { Injectable } from '@angular/core';

import { catchError } from 'rxjs/operators';

import { BaseService } from './base.service';

import { PageBase } from 'src/viewmodels/pagination/pagebase';

@Injectable({
    providedIn: 'root',
})

export class PoblacionService extends BaseService {

    public constructor(
        protected httpClient: HttpClient,
        protected matSnackBar: MatSnackBar) {
        super(httpClient, matSnackBar);
    }

    public UpdatePoblacion(viewModel: UpdatePoblacion): Promise<ViewPoblacion> {
        return this.httpClient.put<ViewPoblacion>('api/poblacion/updatepoblacion', viewModel)
            .pipe(catchError(this.HandleError<ViewPoblacion>('UpdatePoblacion', undefined))).toPromise();
    }

    public FindAllPoblacion(): Promise<ViewPoblacion[]> {
        return this.httpClient.get<ViewPoblacion[]>('api/poblacion/findallpoblacion')
            .pipe(catchError(this.HandleError<ViewPoblacion[]>('FindAllPoblacion', []))).toPromise();
    }

    public FindPaginatedPoblacion(viewModel: PageBase): Promise<ViewPoblacion[]> {
        return this.httpClient.post<ViewPoblacion[]>('api/poblacion/findpaginatedpoblacion', viewModel)
            .pipe(catchError(this.HandleError<ViewPoblacion[]>('FindPaginatedPoblacion', []))).toPromise();
    }

    public FindAllPoblacionByProvinciaId(id: number): Promise<ViewPoblacion[]> {
        return this.httpClient.get<ViewPoblacion[]>('api/poblacion/findallpoblacionbyprovinciaid/' + id)
            .pipe(catchError(this.HandleError<ViewPoblacion[]>('FindAllPoblacionByProvinciaId', []))).toPromise();
    }

    public AddPoblacion(viewModel: AddPoblacion): Promise<ViewPoblacion> {
        return this.httpClient.post<ViewPoblacion>('api/poblacion/addpoblacion', viewModel)
            .pipe(catchError(this.HandleError<ViewPoblacion>('AddPoblacion', undefined))).toPromise();
    }

    public RemovePoblacionById(id: number) {
        return this.httpClient.delete<any>('api/poblacion/removepoblacionbyid/' + id)
            .pipe(catchError(this.HandleError<any>('RemovePoblacionById', undefined))).toPromise();
    }
}
