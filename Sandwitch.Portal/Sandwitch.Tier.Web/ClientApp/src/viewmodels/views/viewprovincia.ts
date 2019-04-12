import { ViewBase } from './viewbase';
import { ViewPoblacion } from './viewpoblacion';

export interface ViewProvincia extends ViewBase {
    ImageUri: string;
    Name: string;
    Poblaciones: ViewPoblacion[];
}
