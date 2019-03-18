import { AddBandera } from '../viewmodels/additions/addbandera';
import { UpdateBandera } from '../viewmodels/updates/updatebandera';
import { Bandera } from '../viewmodels/core/bandera';
import { HttpClient } from '@angular/common/http';
import { MatSnackBar } from '@angular/material';

export class BanderaService {

    public constructor(
        private httpClient: HttpClient,
        private matSnackBar: MatSnackBar) {

    }

    public UpdateBandera(viewModel: UpdateBandera): Bandera {
        let responseObject: Bandera;

        this.httpClient.put<Bandera>('api/bandera/updatebandera', viewModel).subscribe(resp => {
            responseObject = resp;

            if (responseObject) {
                this.matSnackBar.open('Data Updated');
            }
        }, error => {
            if (error) {
                this.matSnackBar.open('Operation Error');
            }
        });

        return responseObject;
    }

    public FindAllBandera(): Bandera[] {
        let responseObjects: Bandera[];

        this.httpClient.get<Bandera[]>('api/bandera/findallbandera').subscribe(resp => {
            responseObjects = resp;

            if (responseObjects) {
                this.matSnackBar.open('Data Loaded');
            }

        }, error => {
            if (error) {
                this.matSnackBar.open('Operation Error');
            }
        });

        return responseObjects;
    }

    public AddBandera(viewModel: AddBandera): Bandera {
        let responseObject: Bandera;

        this.httpClient.post<Bandera>('api/bandera/addbandera', viewModel).subscribe(resp => {
            responseObject = resp;

            if (responseObject) {
                this.matSnackBar.open('Data Added');
            }
        }, error => {
            if (error) {
                this.matSnackBar.open('Operation Error');
            }
        });

        return responseObject;
    }

    public RemoveBanderaById(id: number) {
        let responseObject: any;

        return this.httpClient.delete<Bandera>('api/bandera/removebanderabyid/' + id).subscribe(resp => {
            responseObject = resp;

            if (responseObject) {
                this.matSnackBar.open('Data Removed');
            }
        }, error => {
            if (error) {
                this.matSnackBar.open('Operation Error');
            }
        });
    }
}
