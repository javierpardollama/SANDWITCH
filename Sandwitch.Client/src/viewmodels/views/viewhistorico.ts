import { Time } from "@angular/common";

import { ViewBase } from './viewbase';
import { ViewCatalog } from "./viewcatalog";

export interface ViewHistorico extends ViewBase {
    Viento: ViewCatalog;
    Velocidad: number;
    Bandera: ViewCatalog;
    Arenal: ViewCatalog;
    Temperatura: number;
    BajaMarAlba: Time;
    BajaMarOcaso: Time;
    AltaMarAlba: Time;
    AltaMarOcaso: Time;
}
