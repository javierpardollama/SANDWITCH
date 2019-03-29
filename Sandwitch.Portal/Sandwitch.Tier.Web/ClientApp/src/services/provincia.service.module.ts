import { AddProvincia } from '../viewmodels/additions/addprovincia';
import { UpdateProvincia } from '../viewmodels/updates/updateprovincia';
import { Provincia } from '../viewmodels/core/provincia';
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

    public UpdateProvincia(viewModel: UpdateProvincia): Observable<Provincia> {
        const observable: Observable<Provincia> = this.httpClient.put<Provincia>('api/provincia/updateprovincia', viewModel)
            .pipe(catchError(this.handleError<Provincia>('UpdateProvincia', undefined)));

        if (observable !== undefined) {
            this.matSnackBar.open('Operation Successful', 'Ok');
        }

        return observable;
    }

    public FindAllProvincia(): Observable<Provincia[]> {
        return this.httpClient.get<Provincia[]>('api/provincia/findallprovincia')
            .pipe(catchError(this.handleError<Provincia[]>('FindAllProvincia', [])));
    }

    public AddProvincia(viewModel: AddProvincia): Observable<Provincia> {
        const observable: Observable<Provincia> = this.httpClient.post<Provincia>('api/provincia/addprovincia', viewModel)
            .pipe(catchError(this.handleError<Provincia>('AddProvincia', undefined)));

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
