import { ViewBase } from './viewbase';
import { ViewProvincia } from './viewprovincia';
import { ViewArenalPoblacion } from './viewarenalpoblacion';
import { ViewArenal } from './viewarenal';

export interface ViewPoblacion extends ViewBase {
  ImageUri: string;
  Name: string;
  Provincia: ViewProvincia;
  ArenalPoblaciones: ViewArenalPoblacion[];
  Arenales: ViewArenal[];
}
