import { AddPoblacion } from '../viewmodels/additions/addpoblacion';
import { UpdatePoblacion } from '../viewmodels/updates/updatepoblacion';
import { Poblacion } from '../viewmodels/core/poblacion';
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

    public UpdatePoblacion(viewModel: UpdatePoblacion): Observable<Poblacion> {
        return this.httpClient.put<Poblacion>('api/poblacion/updatepoblacion', viewModel)
            .pipe(catchError(this.handleError<Poblacion>('UpdatePoblacion', undefined)));
    }

    public FindAllPoblacion(): Observable<Poblacion[]> {
        return this.httpClient.get<Poblacion[]>('api/poblacion/findallpoblacion')
            .pipe(catchError(this.handleError<Poblacion[]>('FindAllPoblacion', [])));
    }

    public FindAllPoblacionByProvinciaId(id: number): Observable<Poblacion[]> {
        return this.httpClient.get<Poblacion[]>('api/poblacion/findallpoblacionbyprovinciaid/' + id)
            .pipe(catchError(this.handleError<Poblacion[]>('FindAllPoblacionByProvinciaId', [])));
    }

    public AddPoblacion(viewModel: AddPoblacion): Observable<Poblacion> {
        return this.httpClient.post<Poblacion>('api/poblacion/addpoblacion', viewModel)
            .pipe(catchError(this.handleError<Poblacion>('AddPoblacion', undefined)));
    }

    public RemovePoblacionById(id: number) {

        return this.httpClient.delete<any>('api/poblacion/removepoblacionbyid/' + id)
            .pipe(catchError(this.handleError<any>('RemovePoblacionById', undefined)));
    }

    private handleError<T>(operation = 'operation', result?: T) {
        return (error: any): Observable<T> => {

            this.matSnackBar.open('Operation Error');

            // Let the app keep running by returning an empty result.
            return of(result as T);
        };
    }
}
