import { UpdateBase } from './updatebase';

export interface UpdatePoblacion extends UpdateBase {
    Name: string;
    ProvinciaId: number;
    ImageUri: string;
}
