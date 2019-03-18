import { AddBandera } from '../viewmodels/additions/addbandera';
import { UpdateBandera } from '../viewmodels/updates/updatebandera';
import { Bandera } from '../viewmodels/core/bandera';
import { HttpClient } from '@angular/common/http';

export class BanderaService {

    public constructor(private httpClient: HttpClient) {

    }

    public UpdateBandera(viewModel: UpdateBandera) {
        return this.httpClient.put<Bandera>('api/bandera/updatebandera', viewModel);
    }

    public FindAllBandera() {
        return this.httpClient.get<Bandera[]>('api/bandera/findallbandera');
    }

    public AddBandera(viewModel: AddBandera) {
        return this.httpClient.post<Bandera>('api/bandera/addbandera', viewModel);
    }

    public RemoveBanderaById(id: number) {
        return this.httpClient.delete<Bandera>('api/bandera/removebanderabyid/' + id);
    }
}
