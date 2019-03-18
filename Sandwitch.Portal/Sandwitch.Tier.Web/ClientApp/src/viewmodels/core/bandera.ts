import { Base } from './base';
import { Historico } from './historico';

export interface Bandera extends Base {
    Name: string;
    Historicos: Historico[];
    ImageUri: string;
}
