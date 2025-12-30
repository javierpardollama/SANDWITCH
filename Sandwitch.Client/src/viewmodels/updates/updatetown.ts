import { UpdateBase } from './updatebase';

export interface UpdateTown extends UpdateBase {
    Name: string;
    StateId: number;
    ImageUri: string;
}
