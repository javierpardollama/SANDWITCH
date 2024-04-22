import { ViewBase } from './viewbase';
import { ViewHistorico } from './viewhistorico';

export interface ViewViento extends ViewBase {
    ImageUri: string;
    Name: string;
    Historicos: ViewHistorico[];
}
