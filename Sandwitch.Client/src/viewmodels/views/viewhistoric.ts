import { Time } from "@angular/common";

import { ViewBase } from './viewbase';
import { ViewCatalog } from "./viewcatalog";

export interface ViewHistoric extends ViewBase {
    Wind: ViewCatalog;
    Speed: number;
    Flag: ViewCatalog;
    Beach: ViewCatalog;
    Temperature: number;
    LowSeaDawn: Time;
    LowSeaSunset: Time;
    HighSeaDawn: Time;
    HighSeaSunset: Time;
}
