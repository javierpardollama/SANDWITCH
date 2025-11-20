import { ViewBase } from './viewbase';
import { ViewCatalog } from './viewcatalog';
import { ViewHistorico } from './viewhistorico';

export interface ViewArenal extends ViewBase {
  Name: string;
  LastHistorico: ViewHistorico;
  Poblaciones: ViewCatalog[];
}
