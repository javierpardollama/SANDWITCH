import { UpdateBase } from './updatebase';

export interface UpdateBeach extends UpdateBase {
    Name: string;
    TownsId: number[];
}
