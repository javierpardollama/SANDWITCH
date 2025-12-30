import { ViewBase } from './viewbase';
import { ViewCatalog } from './viewcatalog';
import { ViewHistoric } from './viewhistoric';

export interface ViewBeach extends ViewBase {
  Name: string;
  LastHistoric: ViewHistoric;
  Towns: ViewCatalog[];
}
