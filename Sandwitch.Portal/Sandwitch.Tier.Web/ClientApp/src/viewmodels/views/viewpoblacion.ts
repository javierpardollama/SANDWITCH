import { ViewBase } from './viewbase';
import { ViewProvincia } from './viewprovincia';
import { ViewArenalPoblacion } from './viewarenalpoblacion';

export interface ViewPoblacion extends ViewBase {
    ImageUri: string;
    Name: string;
    Provincia: ViewProvincia;
    Arenales: ViewArenalPoblacion[];
}
