import { AddArenal } from '../viewmodels/additions/addarenal';
import { UpdateArenal } from '../viewmodels/updates/updatearenal';
import { ViewArenal } from '../viewmodels/views/viewarenal';
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

    public UpdateArenal(viewModel: UpdateArenal): Observable<ViewArenal> {

        const observable: Observable<ViewArenal> = this.httpClient.put<ViewArenal>('api/arenal/updatearenal', viewModel)
            .pipe(catchError(this.handleError<ViewArenal>('UpdateArenal', undefined)));

        if (observable !== undefined) {
            this.matSnackBar.open('Operation Successful', 'Ok');
        }

        return observable;
    }

    public FindAllArenal(): Observable<ViewArenal[]> {
        return this.httpClient.get<ViewArenal[]>('api/arenal/findallarenal')
            .pipe(catchError(this.handleError<ViewArenal[]>('FindAllArenal', [])));
    }

    public FindAllArenalByPoblacionId(id: number): Observable<ViewArenal[]> {
        return this.httpClient.get<ViewArenal[]>('api/arenal/findallarenalbypoblacionid/' + id)
            .pipe(catchError(this.handleError<ViewArenal[]>('FindAllArenalByPoblacionId', [])));
    }

    public AddArenal(viewModel: AddArenal): Observable<ViewArenal> {
        const observable: Observable<ViewArenal> = this.httpClient.post<ViewArenal>('api/arenal/addarenal', viewModel)
            .pipe(catchError(this.handleError<ViewArenal>('AddArenal', undefined)));

        if (observable !== undefined) {
            this.matSnackBar.open('Operation Successful', 'Ok');
        }

        return observable;
    }

    public RemoveArenalById(id: number) {

        return this.httpClient.delete<any>('api/arenal/removearenalbyid/' + id)
            .pipe(catchError(this.handleError<any>('RemoveArenalById', undefined)));
    }

    private handleError<T>(operation = 'Operation', result?: T) {
        return (error: any): Observable<T> => {

            this.matSnackBar.open(error.error, 'Ok');

            // Let the app keep running by returning an empty result.
            return of(result as T);
        };
    }
}
