import { AddBandera } from '../viewmodels/additions/addbandera';
import { UpdateBandera } from '../viewmodels/updates/updatebandera';
import { ViewBandera } from '../viewmodels/views/viewbandera';
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

export class BanderaService {

    public constructor(
        private httpClient: HttpClient,
        private matSnackBar: MatSnackBar) {

    }

    public UpdateBandera(viewModel: UpdateBandera): Observable<ViewBandera> {
        return this.httpClient.put<ViewBandera>('api/bandera/updatebandera', viewModel)
            .pipe(catchError(this.HandleError<ViewBandera>('UpdateBandera', undefined)));
    }

    public FindAllBandera(): Observable<ViewBandera[]> {
        return this.httpClient.get<ViewBandera[]>('api/bandera/findallbandera')
            .pipe(catchError(this.HandleError<ViewBandera[]>('FindAllBandera', [])));
    }

    public AddBandera(viewModel: AddBandera): Observable<ViewBandera> {
        return this.httpClient.post<ViewBandera>('api/bandera/addbandera', viewModel)
            .pipe(catchError(this.HandleError<ViewBandera>('AddBandera', undefined)));
    }

    public RemoveBanderaById(id: number) {
        return this.httpClient.delete<any>('api/bandera/removebanderabyid/' + id)
            .pipe(catchError(this.HandleError<any>('RemoveBanderaById', undefined)));
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
