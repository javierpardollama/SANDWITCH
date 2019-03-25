import { AddArenal } from '../viewmodels/additions/addarenal';
import { UpdateArenal } from '../viewmodels/updates/updatearenal';
import { Arenal } from '../viewmodels/core/arenal';
import { HttpClient } from '@angular/common/http';
import { MatSnackBar } from '@angular/material';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
    providedIn: 'root',
})

export class ArenalService {

    public constructor(
        private httpClient: HttpClient,
        private matSnackBar: MatSnackBar) {

    }

    public UpdateArenal(viewModel: UpdateArenal): Observable<Arenal> {
        return this.httpClient.put<Arenal>('api/arenal/updatearenal', viewModel)
            .pipe(catchError(this.handleError<Arenal>('UpdateArenal', undefined)));
    }

    public FindAllArenal(): Observable<Arenal[]> {
        return this.httpClient.get<Arenal[]>('api/arenal/findallarenal')
            .pipe(catchError(this.handleError<Arenal[]>('FindAllArenal', [])));
    }

    public FindAllArenalByPoblacionId(id: number): Observable<Arenal[]> {
        return this.httpClient.get<Arenal[]>('api/arenal/findallarenalbypoblacionid/' + id)
            .pipe(catchError(this.handleError<Arenal[]>('FindAllArenalByPoblacionId', [])));
    }

    public AddArenal(viewModel: AddArenal): Observable<Arenal> {
        return this.httpClient.post<Arenal>('api/arenal/addarenal', viewModel)
            .pipe(catchError(this.handleError<Arenal>('AddArenal', undefined)));
    }

    public RemoveArenalById(id: number) {

        return this.httpClient.delete<any>('api/arenal/removearenalbyid/' + id)
            .pipe(catchError(this.handleError<any>('RemoveArenalById', undefined)));
    }

    private handleError<T>(operation = 'Operation', result?: T) {
        return (error: any): Observable<T> => {

            this.matSnackBar.open(operation + ' Error');

            // Let the app keep running by returning an empty result.
            return of(result as T);
        };
    }
}
