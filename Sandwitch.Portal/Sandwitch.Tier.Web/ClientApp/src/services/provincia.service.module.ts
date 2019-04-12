import { AddProvincia } from '../viewmodels/additions/addprovincia';
import { UpdateProvincia } from '../viewmodels/updates/updateprovincia';
import { ViewProvincia } from '../viewmodels/views/viewprovincia';
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
        const observable: Observable<ViewProvincia> = this.httpClient.put<ViewProvincia>('api/provincia/updateprovincia', viewModel)
            .pipe(catchError(this.handleError<ViewProvincia>('UpdateProvincia', undefined)));

        if (observable !== undefined) {
            this.matSnackBar.open('Operation Successful', 'Ok');
        }

        return observable;
    }

    public FindAllProvincia(): Observable<ViewProvincia[]> {
        return this.httpClient.get<ViewProvincia[]>('api/provincia/findallprovincia')
            .pipe(catchError(this.handleError<ViewProvincia[]>('FindAllProvincia', [])));
    }

    public AddProvincia(viewModel: AddProvincia): Observable<ViewProvincia> {
        const observable: Observable<ViewProvincia> = this.httpClient.post<ViewProvincia>('api/provincia/addprovincia', viewModel)
            .pipe(catchError(this.handleError<ViewProvincia>('AddProvincia', undefined)));

        if (observable !== undefined) {
            this.matSnackBar.open('Operation Successful', 'Ok');
        }

        return observable;
    }

    public RemoveProvinciaById(id: number) {
        return this.httpClient.delete<any>('api/provincia/removeprovinciabyid/' + id)
            .pipe(catchError(this.handleError<any>('RemoveProvinciaById', undefined)));
    }

    private handleError<T>(operation = 'Operation', result?: T) {
        return (error: any): Observable<T> => {

            this.matSnackBar.open(operation + ' Error', 'Ok');

            // Let the app keep running by returning an empty result.
            return of(result as T);
        };
    }
}
