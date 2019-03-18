import { UpdateHistorico } from '../viewmodels/updates/updatehistorico';
import { Historico } from '../viewmodels/core/historico';
import { HttpClient } from '@angular/common/http';
import { MatSnackBar } from '@angular/material';

export class HistoricoService {

    public constructor(
        private httpClient: HttpClient,
        private matSnackBar: MatSnackBar) {

    }

    public UpdateHistorico(viewModel: UpdateHistorico): Historico {
        let responseObject: Historico;

        this.httpClient.put<Historico>('api/historico/updatehistorico', viewModel).subscribe(resp => {
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
}
