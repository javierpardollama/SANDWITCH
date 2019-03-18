import { Base } from './base';
import { Poblacion } from './poblacion';

export interface Provincia extends Base {
    Name: string;
    Poblaciones: Poblacion[];
}
