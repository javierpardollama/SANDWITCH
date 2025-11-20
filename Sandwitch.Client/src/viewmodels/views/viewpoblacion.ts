import { ViewBase } from './viewbase';
import { ViewCatalog } from './viewcatalog';

export interface ViewPoblacion extends ViewBase {
  ImageUri: string;
  Name: string;
  Provincia: ViewCatalog;
}
