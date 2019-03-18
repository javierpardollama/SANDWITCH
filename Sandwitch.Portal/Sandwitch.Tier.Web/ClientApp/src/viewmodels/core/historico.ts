import { Base } from './base';
import { Arenal } from './arenal';
import { Bandera } from './bandera';

export interface Historico extends Base {
    Bandera: Bandera;
    Arenal: Arenal;
    Temperatura: number;
}