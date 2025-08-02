import { AddPoblacion } from '../viewmodels/additions/addpoblacion';

import { UpdatePoblacion } from '../viewmodels/updates/updatepoblacion';

import { ViewPage } from '../viewmodels/views/viewpage';

import { ViewPoblacion } from '../viewmodels/views/viewpoblacion';

import { HttpClient } from '@angular/common/http';

import { MatSnackBar } from '@angular/material/snack-bar';

import { Injectable } from '@angular/core';

import { catchError } from 'rxjs/operators';

import { BaseService } from './base.service';

import { FilterPage } from 'src/viewmodels/filters/filterpage';

import { firstValueFrom } from 'rxjs';

import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';

@Injectable({
    providedIn: 'root',
})

export class PoblacionService extends BaseService {

    public constructor(
        protected override httpClient: HttpClient,
        protected override matSnackBar: MatSnackBar,
        protected override router: Router) {
        super(httpClient, matSnackBar, router);
    }

    public UpdatePoblacion(viewModel: UpdatePoblacion): Promise<ViewPoblacion> {
        return firstValueFrom(this.httpClient.put<ViewPoblacion>(`${environment.Api.Service}api/poblacion/updatepoblacion`, viewModel)
            .pipe(catchError(this.HandleError<ViewPoblacion>('UpdatePoblacion', undefined))));
    }

    public FindPaginatedPoblacion(viewModel: FilterPage): Promise<ViewPage<ViewPoblacion>> {
        return firstValueFrom(this.httpClient.post<ViewPage<ViewPoblacion>>(`${environment.Api.Service}api/poblacion/findpaginatedpoblacion`, viewModel)
            .pipe(catchError(this.HandleError<ViewPage<ViewPoblacion>>('FindPaginatedPoblacion', undefined))));
    }

    public AddPoblacion(viewModel: AddPoblacion): Promise<ViewPoblacion> {
        return firstValueFrom(this.httpClient.post<ViewPoblacion>(`${environment.Api.Service}api/poblacion/addpoblacion`, viewModel)
            .pipe(catchError(this.HandleError<ViewPoblacion>('AddPoblacion', undefined))));
    }

    public RemovePoblacionById(id: number): Promise<any> {
        return firstValueFrom(this.httpClient.delete<any>(`${environment.Api.Service}api/poblacion/removepoblacionbyid/${id}`)
            .pipe(catchError(this.HandleError<any>('RemovePoblacionById', undefined))));
    }
}
