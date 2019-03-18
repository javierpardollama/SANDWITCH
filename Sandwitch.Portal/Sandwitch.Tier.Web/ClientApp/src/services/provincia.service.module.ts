import { AddProvincia } from '../viewmodels/additions/addprovincia';
import { UpdateProvincia } from '../viewmodels/updates/updateprovincia';
import { Provincia } from '../viewmodels/core/provincia';
import { HttpClient } from '@angular/common/http';
import { MatSnackBar } from '@angular/material';

export class ProvinciaService {

    public constructor(
        private httpClient: HttpClient,
        private matSnackBar: MatSnackBar) {

    }

    public UpdateProvincia(viewModel: UpdateProvincia): Provincia {
        let responseObject: Provincia;

        this.httpClient.put<Provincia>('api/provincia/updateprovincia', viewModel).subscribe(resp => {
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

    public FindAllProvincia(): Provincia[] {
        let responseObjects: Provincia[];

        this.httpClient.get<Provincia[]>('api/provincia/findallprovincia').subscribe(resp => {
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

    public AddProvincia(viewModel: AddProvincia): Provincia {
        let responseObject: Provincia;

        this.httpClient.post<Provincia>('api/provincia/addprovincia', viewModel).subscribe(resp => {
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

    public RemoveProvinciaById(id: number) {
        let responseObject: any;

        return this.httpClient.delete<Provincia>('api/provincia/removeprovinciabyid/' + id).subscribe(resp => {
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
