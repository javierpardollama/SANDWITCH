import { AddArenal } from '../viewmodels/additions/addarenal';
import { UpdateArenal } from '../viewmodels/updates/updatearenal';
import { Arenal } from '../viewmodels/core/arenal';
import { HttpClient } from '@angular/common/http';
import { MatSnackBar } from '@angular/material';

export class ArenalService {

    public constructor(
        private httpClient: HttpClient,
        private matSnackBar: MatSnackBar) {

    }

    public UpdateArenal(viewModel: UpdateArenal): Arenal {
        let responseObject: Arenal;

        this.httpClient.put<Arenal>('api/arenal/updatearenal', viewModel).subscribe(resp => {
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

    public FindAllArenal(): Arenal[] {
        let responseObjects: Arenal[];

        this.httpClient.get<Arenal[]>('api/arenal/findallarenal').subscribe(resp => {
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

    public FindAllArenalByPoblacionId(id: number): Arenal[] {
        let responseObjects: Arenal[];

        this.httpClient.get<Arenal[]>('api/arenal/findallarenalbypoblacionid/' + id).subscribe(resp => {
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

    public AddArenal(viewModel: AddArenal): Arenal {
        let responseObject: Arenal;

        this.httpClient.post<Arenal>('api/arenal/addarenal', viewModel).subscribe(resp => {
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

    public RemoveArenalById(id: number) {
        let responseObject: any;

        return this.httpClient.delete<Arenal>('api/arenal/removearenalbyid/' + id).subscribe(resp => {
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
