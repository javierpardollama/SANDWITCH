import { AddHistorico } from '../viewmodels/additions/addhistorico';
import { ViewHistorico } from '../viewmodels/views/viewhistorico';
import { ViewException } from '../viewmodels/views/viewexception';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { MatSnackBar } from '@angular/material';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AppConstants } from './../app/app.constants';

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
        return (httpErrorResponse: HttpErrorResponse): Observable<T> => {

            const expception: ViewException =
            {
                Message: httpErrorResponse.error.Message,
                StatusCode: httpErrorResponse.error.StatusCode
            }

            this.matSnackBar.open(expception.Message, AppConstants.AppOkButtonText, { duration: AppConstants.AppToastSecondTicks * AppConstants.AppTimeSecondTicks });

            // Let the app keep running by returning an empty result.
            return of(result as T);
        };
    }
}
