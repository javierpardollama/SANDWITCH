import { AddArenal } from '../viewmodels/additions/addarenal';
import { UpdateArenal } from '../viewmodels/updates/updatearenal';
import { Arenal } from '../viewmodels/core/arenal';
import { HttpClient } from '@angular/common/http';

export class ArenalService {

    public constructor(private httpClient: HttpClient) {

    }

    public UpdateArenal(viewModel: UpdateArenal) {
        return this.httpClient.put<Arenal>('api/arenal/updatearenal', viewModel);
    }

    public FindAllArenal() {
        return this.httpClient.get<Arenal[]>('api/arenal/findallarenal');
    }

    public FindAllArenalByPoblacionId(id: number) {
        return this.httpClient.get<Arenal[]>('api/arenal/findallarenalbypoblacionid/' + id);
    }

    public AddArenal(viewModel: AddArenal) {
        return this.httpClient.post<Arenal>('api/arenal/addarenal', viewModel);
    }

    public RemoveArenalById(id: number) {
        return this.httpClient.delete<Arenal>('api/arenal/removearenalbyid/' + id);
    }
}
