import { Base } from './base';
import { ArenalPoblacion } from './arenalpoblacion';
import { Historico } from './historico';

export interface Arenal extends Base {
    Name: string;
    Poblaciones: ArenalPoblacion[];
    Historicos: Historico[];
}
