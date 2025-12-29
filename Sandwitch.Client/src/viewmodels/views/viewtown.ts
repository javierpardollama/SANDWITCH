import { ViewBase } from './viewbase';
import { ViewCatalog } from './viewcatalog';

export interface ViewTown extends ViewBase {
  ImageUri: string;
  Name: string;
  State: ViewCatalog;
}
