import { AddHistorico } from './../viewmodels/additions/addhistorico';
import { ViewHistorico } from './../viewmodels/views/viewhistorico';
import { HttpClient } from '@angular/common/http';
import { MatSnackBar } from '@angular/material';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { BaseService } from './base.service';

@Injectable({
    providedIn: 'root',
})

export class HistoricoService extends BaseService {

    public constructor(
        protected httpClient: HttpClient,
        protected matSnackBar: MatSnackBar) {
        super(httpClient, matSnackBar);
    }

    public AddHistorico(viewModel: AddHistorico): Observable<ViewHistorico> {
        return this.httpClient.post<ViewHistorico>('api/historico/addhistorico', viewModel)
            .pipe(catchError(this.HandleError<ViewHistorico>('AddHistorico', undefined)));
    }
}
