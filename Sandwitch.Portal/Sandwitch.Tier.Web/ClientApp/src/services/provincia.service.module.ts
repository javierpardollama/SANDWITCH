import { AddProvincia } from '../viewmodels/additions/addprovincia';
import { UpdateProvincia } from '../viewmodels/updates/updateprovincia';
import { ViewProvincia } from '../viewmodels/views/viewprovincia';
import { ViewException } from '../viewmodels/views/viewexception';
import { HttpClient } from '@angular/common/http';
import { MatSnackBar } from '@angular/material';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

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
        return (exception: ViewException): Observable<T> => {

            this.matSnackBar.open(exception.Message, 'Ok');

            // Let the app keep running by returning an empty result.
            return of(result as T);
        };
    }
}
