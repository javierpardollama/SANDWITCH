import { ViewBase } from './viewbase';
import { ViewHistorico } from './viewhistorico';
import { ViewArenalPoblacion } from './viewarenalpoblacion';
import { ViewPoblacion } from './viewpoblacion';

export interface ViewArenal extends ViewBase {
  Name: string;
  Historicos: ViewHistorico[];
  LastHistorico: ViewHistorico;
  ArenalPoblaciones: ViewArenalPoblacion[];
  Poblaciones: ViewPoblacion[];
}
