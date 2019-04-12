import { ViewBase } from './viewbase';
import { ViewHistorico } from './viewhistorico';
import { ViewArenalPoblacion } from './viewarenalpoblacion';

export interface ViewArenal extends ViewBase {
    Name: string;
    Historicos: ViewHistorico[];
    LastHistorico: ViewHistorico;
    Poblaciones: ViewArenalPoblacion[];
}
