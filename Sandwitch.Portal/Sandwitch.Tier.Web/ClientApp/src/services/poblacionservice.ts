import { AddPoblacion } from '../viewmodels/additions/addpoblacion';
import { UpdatePoblacion } from '../viewmodels/updates/updatepoblacion';
import { Poblacion } from '../viewmodels/core/poblacion';
import { HttpClient } from '@angular/common/http';

export class PoblacionService {

    public constructor(private httpClient: HttpClient) {

    }

    public UpdatePoblacion(viewModel: UpdatePoblacion) {
        return this.httpClient.put<Poblacion>('api/poblacion/updatepoblacion', viewModel);
    }

    public FindAllPoblacion() {
        return this.httpClient.get<Poblacion[]>('api/poblacion/findallpoblacion');
    }

    public FindAllPoblacionByProvinciaId(id: number) {
        return this.httpClient.get<Poblacion[]>('api/poblacion/findallpoblacionbyprovinciaid/' + id);
    }

    public AddPoblacion(viewModel: AddPoblacion) {
        return this.httpClient.post<Poblacion>('api/poblacion/addpoblacion', viewModel);
    }

    public RemovePoblacionById(id: number) {
        return this.httpClient.delete<Poblacion>('api/poblacion/removepoblacionbyid/' + id);
    }
}
