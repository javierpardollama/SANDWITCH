import { AddArenal } from '../viewmodels/additions/addarenal';
import { UpdateArenal } from '../viewmodels/updates/updatearenal';
import { ViewArenal } from '../viewmodels/views/viewarenal';
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

export class ArenalService {

    public constructor(
        private httpClient: HttpClient,
        private matSnackBar: MatSnackBar) {

    }

    public UpdateArenal(viewModel: UpdateArenal): Observable<ViewArenal> {
        return this.httpClient.put<ViewArenal>('api/arenal/updatearenal', viewModel)
            .pipe(catchError(this.HandleError<ViewArenal>('UpdateArenal', undefined)));
    }

    public FindAllArenal(): Observable<ViewArenal[]> {
        return this.httpClient.get<ViewArenal[]>('api/arenal/findallarenal')
            .pipe(catchError(this.HandleError<ViewArenal[]>('FindAllArenal', [])));
    }

    public FindAllArenalByPoblacionId(id: number): Observable<ViewArenal[]> {
        return this.httpClient.get<ViewArenal[]>('api/arenal/findallarenalbypoblacionid/' + id)
            .pipe(catchError(this.HandleError<ViewArenal[]>('FindAllArenalByPoblacionId', [])));
    }

    public AddArenal(viewModel: AddArenal): Observable<ViewArenal> {
        return this.httpClient.post<ViewArenal>('api/arenal/addarenal', viewModel)
            .pipe(catchError(this.HandleError<ViewArenal>('AddArenal', undefined)));
    }

    public RemoveArenalById(id: number) {
        return this.httpClient.delete<any>('api/arenal/removearenalbyid/' + id)
            .pipe(catchError(this.HandleError<any>('RemoveArenalById', undefined)));
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
