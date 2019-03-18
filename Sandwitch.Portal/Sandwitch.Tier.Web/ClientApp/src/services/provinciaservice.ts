import { AddProvincia } from '../viewmodels/additions/addprovincia';
import { UpdateProvincia } from '../viewmodels/updates/updateprovincia';
import { Provincia } from '../viewmodels/core/provincia';
import { HttpClient } from '@angular/common/http';

export class ProvinciaService {

    public constructor(private httpClient: HttpClient) {

    }

    public UpdateProvincia(viewModel: UpdateProvincia) {
        return this.httpClient.put<Provincia>('api/provincia/updateprovincia', viewModel);
    }

    public FindAllProvincia() {
        return this.httpClient.get<Provincia[]>('api/provincia/findallprovincia');
    }

    public AddProvincia(viewModel: AddProvincia) {
        return this.httpClient.post<Provincia>('api/provincia/addprovincia', viewModel);
    }

    public RemoveProvinciaById(id: number) {
        return this.httpClient.delete<Provincia>('api/provincia/removeprovinciabyid/' + id);
    }
}
