import { UpdateHistorico } from '../viewmodels/updates/updatehistorico';
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

    public UpdateHistorico(viewModel: UpdateHistorico): Observable<Historico> {
       
        return this.httpClient.put<Historico>('api/provincia/updatehistorico', viewModel)
            .pipe(catchError(this.handleError<Historico>('UpdateHistorico', undefined)));            
    }

    private handleError<T>(operation = 'operation', result?: T) {
        return (error: any): Observable<T> => {

            this.matSnackBar.open('Operation Error');

            // Let the app keep running by returning an empty result.
            return of(result as T);
        };
    }
}
