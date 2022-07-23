import { AddHistorico } from './../viewmodels/additions/addhistorico';

import { ViewHistorico } from './../viewmodels/views/viewhistorico';

import { HttpClient } from '@angular/common/http';

import { MatSnackBar } from '@angular/material/snack-bar';

import { Injectable } from '@angular/core';

import { catchError } from 'rxjs/operators';

import { BaseService } from './base.service';

import { firstValueFrom } from 'rxjs';

import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root',
})

export class HistoricoService extends BaseService {

    public constructor(
        protected override httpClient: HttpClient,
        protected override matSnackBar: MatSnackBar) {
        super(httpClient, matSnackBar);
    }

    public AddHistorico(viewModel: AddHistorico): Promise<ViewHistorico> {
        return firstValueFrom(this.httpClient.post<ViewHistorico>(`${environment.ApiService}api/historico/addhistorico`, viewModel)
            .pipe(catchError(this.HandleError<ViewHistorico>('AddHistorico', undefined))));
    }
}
