import { AddHistorico } from '../viewmodels/additions/addhistorico';
import { Historico } from '../viewmodels/core/historico';
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

    public AddHistorico(viewModel: AddHistorico): Observable<Historico> {

        const observable: Observable<Historico> = this.httpClient.post<Historico>('api/historico/addhistorico', viewModel)
            .pipe(catchError(this.handleError<Historico>('AddHistorico', undefined)));

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
