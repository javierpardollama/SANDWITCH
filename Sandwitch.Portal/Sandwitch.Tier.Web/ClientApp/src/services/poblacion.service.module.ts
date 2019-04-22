import { AddPoblacion } from '../viewmodels/additions/addpoblacion';
import { UpdatePoblacion } from '../viewmodels/updates/updatepoblacion';
import { ViewPoblacion } from '../viewmodels/views/viewpoblacion';
import { HttpClient } from '@angular/common/http';
import { MatSnackBar } from '@angular/material';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
    providedIn: 'root',
})

export class PoblacionService {

    public constructor(
        private httpClient: HttpClient,
        private matSnackBar: MatSnackBar) {

    }

    public UpdatePoblacion(viewModel: UpdatePoblacion): Observable<ViewPoblacion> {
        return this.httpClient.put<ViewPoblacion>('api/poblacion/updatepoblacion', viewModel)
            .pipe(catchError(this.handleError<ViewPoblacion>('UpdatePoblacion', undefined)));
    }

    public FindAllPoblacion(): Observable<ViewPoblacion[]> {
        return this.httpClient.get<ViewPoblacion[]>('api/poblacion/findallpoblacion')
            .pipe(catchError(this.handleError<ViewPoblacion[]>('FindAllPoblacion', [])));
    }

    public FindAllPoblacionByProvinciaId(id: number): Observable<ViewPoblacion[]> {
        return this.httpClient.get<ViewPoblacion[]>('api/poblacion/findallpoblacionbyprovinciaid/' + id)
            .pipe(catchError(this.handleError<ViewPoblacion[]>('FindAllPoblacionByProvinciaId', [])));
    }

    public AddPoblacion(viewModel: AddPoblacion): Observable<ViewPoblacion> {
        return this.httpClient.post<ViewPoblacion>('api/poblacion/addpoblacion', viewModel)
            .pipe(catchError(this.handleError<ViewPoblacion>('AddPoblacion', undefined)));
    }

    public RemovePoblacionById(id: number) {
        return this.httpClient.delete<any>('api/poblacion/removepoblacionbyid/' + id)
            .pipe(catchError(this.handleError<any>('RemovePoblacionById', undefined)));
    }

    private handleError<T>(operation = 'Operation', result?: T) {
        return (error: any): Observable<T> => {

            this.matSnackBar.open(error.error, 'Ok');

            // Let the app keep running by returning an empty result.
            return of(result as T);
        };
    }
}
