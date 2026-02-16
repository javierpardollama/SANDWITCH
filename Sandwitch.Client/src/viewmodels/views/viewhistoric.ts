import { ViewBase } from './viewbase';
import { ViewCatalog } from "./viewcatalog";

export interface ViewHistoric extends ViewBase {
    Wind: ViewCatalog;
    Speed: number;
    Flag: ViewCatalog;
    Beach: ViewCatalog;
    Temperature: number;
    LowSeaDawn: Date;
    LowSeaSunset: Date;
    HighSeaDawn: Date;
    HighSeaSunset: Date;
}
