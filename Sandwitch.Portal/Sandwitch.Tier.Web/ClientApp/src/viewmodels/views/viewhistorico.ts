import { ViewBase } from './viewbase';
import { ViewBandera } from './viewbandera';
import { ViewArenal } from './viewarenal';

export interface ViewHistorico extends ViewBase {
    Bandera: ViewBandera;
    Arenal: ViewArenal;
    Temperatura: number;
    BajaMarAlba: Date;
    BajaMarOcaso: Date;
    AltaMarAlba: Date;
    AltaMarOcaso: Date;
}
