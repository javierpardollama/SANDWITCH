import { AddHistorico } from '../viewmodels/additions/addhistorico';
import { ViewHistorico } from '../viewmodels/views/viewhistorico';
import { ViewException } from '../viewmodels/views/viewexception';
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
        return this.httpClient.post<ViewHistorico>('api/historico/addhistorico', viewModel)
            .pipe(catchError(this.HandleError<ViewHistorico>('AddHistorico', undefined)));
    }

    private HandleError<T>(operation = 'Operation', result?: T) {
        return (exception: ViewException): Observable<T> => {

            this.matSnackBar.open(exception.Message, 'Ok');

            // Let the app keep running by returning an empty result.
            return of(result as T);
        };
    }
}
