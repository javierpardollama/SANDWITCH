import { AddProvincia } from '../viewmodels/additions/addprovincia';
import { UpdateProvincia } from '../viewmodels/updates/updateprovincia';
import { ViewProvincia } from '../viewmodels/views/viewprovincia';
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

export class ProvinciaService {

    public constructor(
        private httpClient: HttpClient,
        private matSnackBar: MatSnackBar) {

    }

    public UpdateProvincia(viewModel: UpdateProvincia): Observable<ViewProvincia> {
        return this.httpClient.put<ViewProvincia>('api/provincia/updateprovincia', viewModel)
            .pipe(catchError(this.HandleError<ViewProvincia>('UpdateProvincia', undefined)));
    }

    public FindAllProvincia(): Observable<ViewProvincia[]> {
        return this.httpClient.get<ViewProvincia[]>('api/provincia/findallprovincia')
            .pipe(catchError(this.HandleError<ViewProvincia[]>('FindAllProvincia', [])));
    }

    public AddProvincia(viewModel: AddProvincia): Observable<ViewProvincia> {
        return this.httpClient.post<ViewProvincia>('api/provincia/addprovincia', viewModel)
            .pipe(catchError(this.HandleError<ViewProvincia>('AddProvincia', undefined)));
    }

    public RemoveProvinciaById(id: number) {
        return this.httpClient.delete<any>('api/provincia/removeprovinciabyid/' + id)
            .pipe(catchError(this.HandleError<any>('RemoveProvinciaById', undefined)));
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
