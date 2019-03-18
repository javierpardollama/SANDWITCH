import { Base } from './base';
import { Provincia } from './provincia';
import { ArenalPoblacion } from './arenalpoblacion';

export interface Poblacion extends Base {
    Name: string;
    Provincia: Provincia;
    Arenales: ArenalPoblacion[];
}
