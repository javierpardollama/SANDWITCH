import { Base } from './base';
import { Arenal } from './arenal';
import { Poblacion } from './poblacion';

export interface ArenalPoblacion extends Base {
    Arenal: Arenal;
    Poblacion: Poblacion;
}
