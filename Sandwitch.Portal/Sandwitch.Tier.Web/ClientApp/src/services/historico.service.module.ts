import { AddHistorico } from '../viewmodels/additions/addhistorico';
import { ViewHistorico } from '../viewmodels/views/viewhistorico';
import { HttpClient } from '@angular/common/http';
import { MatSnackBar } from '@angular/material';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
    providedIn: 'root',
})

export class HistoricoService {

    public constructor(
        private httpClient: HttpClient,
        private matSnackBar: MatSnackBar) {

    }

    public AddHistorico(viewModel: AddHistorico): Observable<ViewHistorico> {

        const observable: Observable<ViewHistorico> = this.httpClient.post<ViewHistorico>('api/historico/addhistorico', viewModel)
            .pipe(catchError(this.handleError<ViewHistorico>('AddHistorico', undefined)));

        if (observable !== undefined) {
            this.matSnackBar.open('Operation Successful', 'Ok');
        }

        return observable;
    }

    private handleError<T>(operation = 'Operation', result?: T) {
        return (error: any): Observable<T> => {

            this.matSnackBar.open(operation + ' Error', 'Ok');

            // Let the app keep running by returning an empty result.
            return of(result as T);
        };
    }
}
