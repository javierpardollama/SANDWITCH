import { AddBandera } from '../viewmodels/additions/addbandera';
import { UpdateBandera } from '../viewmodels/updates/updatebandera';
import { Bandera } from '../viewmodels/core/bandera';
import { HttpClient } from '@angular/common/http';
import { MatSnackBar } from '@angular/material';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
    providedIn: 'root',
})

export class BanderaService {

    public constructor(
        private httpClient: HttpClient,
        private matSnackBar: MatSnackBar) {

    }

    public UpdateBandera(viewModel: UpdateBandera): Observable<Bandera> {      
        return this.httpClient.put<Bandera>('api/bandera/updatebandera', viewModel)
            .pipe(catchError(this.handleError<Bandera>('UpdateBandera', undefined)));
    }

    public FindAllBandera(): Observable<Bandera[]> {
        return this.httpClient.get<Bandera[]>('api/bandera/findallbandera')
            .pipe(catchError(this.handleError<Bandera[]>('FindAllBandera', [])));
    }   

    public AddBandera(viewModel: AddBandera): Observable<Bandera> {
        return this.httpClient.post<Bandera>('api/bandera/addbandera', viewModel)
            .pipe(catchError(this.handleError<Bandera>('AddBandera', undefined)));
    }

    public RemoveBanderaById(id: number) {

        return this.httpClient.delete<any>('api/bandera/removebanderabyid/' + id)
            .pipe(catchError(this.handleError<any>('RemoveBanderaById', undefined)));
    }

    private handleError<T>(operation = 'Operation', result?: T) {
        return (error: any): Observable<T> => {

            this.matSnackBar.open(operation + ' Error');

            // Let the app keep running by returning an empty result.
            return of(result as T);
        };
    }
}
