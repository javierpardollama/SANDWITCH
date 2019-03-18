import { UpdateHistorico } from '../viewmodels/updates/updatehistorico';
import { Poblacion } from '../viewmodels/core/poblacion';
import { HttpClient } from '@angular/common/http';

export class HistoricoService {

    public constructor(private httpClient: HttpClient) {

    }

    public UpdateHistorico(viewModel: UpdateHistorico) {
        return this.httpClient.put<Poblacion>('api/historico/updatehistorico', viewModel);
    }
}
