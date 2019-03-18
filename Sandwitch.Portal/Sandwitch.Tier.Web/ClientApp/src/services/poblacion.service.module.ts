import { AddPoblacion } from '../viewmodels/additions/addpoblacion';
import { UpdatePoblacion } from '../viewmodels/updates/updatepoblacion';
import { Poblacion } from '../viewmodels/core/poblacion';
import { HttpClient } from '@angular/common/http';
import { MatSnackBar } from '@angular/material';

export class PoblacionService {

    public constructor(
        private httpClient: HttpClient,
        private matSnackBar: MatSnackBar) {

    }

    public UpdatePoblacion(viewModel: UpdatePoblacion) {
        let responseObject: Poblacion;

        return this.httpClient.put<Poblacion>('api/poblacion/updatepoblacion', viewModel).subscribe(resp => {
            responseObject = resp;

            if (responseObject) {
                this.matSnackBar.open('Data Updated');
            }
        }, error => {
            if (error) {
                this.matSnackBar.open('Operation Error');
            }
        });

    }

    public FindAllPoblacion() {
        let responseObjects: Poblacion[];

        return this.httpClient.get<Poblacion[]>('api/poblacion/findallpoblacion').subscribe(resp => {
            responseObjects = resp;        
            
            if (responseObjects) {
                this.matSnackBar.open('Data Loaded');
            }

        }, error => {
            if (error) {
                this.matSnackBar.open('Operation Error');
            }
        });
    }

    public FindAllPoblacionByProvinciaId(id: number) {
        let responseObjects: Poblacion[];

        return this.httpClient.get<Poblacion[]>('api/poblacion/findallpoblacionbyprovinciaid/' + id).subscribe(resp => {
            responseObjects = resp;        
            
            if (responseObjects) {
                this.matSnackBar.open('Data Loaded');
            }

        }, error => {
            if (error) {
                this.matSnackBar.open('Operation Error');
            }
        });
    }

    public AddPoblacion(viewModel: AddPoblacion) {
        let responseObject: Poblacion;

        return this.httpClient.post<Poblacion>('api/poblacion/addpoblacion', viewModel).subscribe(resp => {
            responseObject = resp;

            if (responseObject) {
                this.matSnackBar.open('Data Added');
            }
        }, error => {
            if (error) {
                this.matSnackBar.open('Operation Error');
            }
        });
    }

    public RemovePoblacionById(id: number) {
        let responseObject: any;

        return this.httpClient.delete<Poblacion>('api/poblacion/removepoblacionbyid/' + id).subscribe(resp => {
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
