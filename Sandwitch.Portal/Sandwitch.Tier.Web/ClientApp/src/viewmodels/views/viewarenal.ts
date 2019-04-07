import { ViewBase } from './viewbase';
import { ViewHistorico } from './viewhistorico';

export interface ViewArenal extends ViewBase {
    Name: string;
    Historicos: ViewHistorico[];
    LastHistorico: ViewHistorico;
}