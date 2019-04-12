import { ViewBase } from './viewbase';
import { ViewHistorico } from './viewhistorico';

export interface ViewBandera extends ViewBase {
    ImageUri: string;
    Name: string;
    Historicos: ViewHistorico[];
}
