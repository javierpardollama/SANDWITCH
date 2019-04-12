import { ViewBase } from './viewbase';
import { ViewArenal } from './viewarenal';
import { ViewPoblacion } from './viewpoblacion';


export interface ViewArenalPoblacion extends ViewBase {
    Arenal: ViewArenal;
    Poblacion: ViewPoblacion;
}
