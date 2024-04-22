import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ArenalGridComponent } from './management/grids/arenal-grid/arenal-grid.component';
import { BanderaGridComponent } from './management/grids/bandera-grid/bandera-grid.component';
import { PoblacionGridComponent } from './management/grids/poblacion-grid/poblacion-grid.component';
import { ProvinciaGridComponent } from './management/grids/provincia-grid/provincia-grid.component';
import { UnknownComponent } from './unknown/unknown.component';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';
import { VientoGridComponent } from './management/grids/viento-grid/viento-grid.component';

@NgModule({
  imports: [RouterModule.forRoot([
    {
      path: '',
      component: HomeComponent,
      pathMatch: 'full'
    },
    {
      path: 'management/vientos',
      component: VientoGridComponent,
      pathMatch: 'full'
    },
    {
      path: 'management/banderas',
      component: BanderaGridComponent,
      pathMatch: 'full'
    },
    {
      path: 'management/poblaciones',
      component: PoblacionGridComponent,
      pathMatch: 'full'
    },
    {
      path: 'management/provincias',
      component: ProvinciaGridComponent,
      pathMatch: 'full'
    },
    {
      path: 'management/arenales',
      component: ArenalGridComponent,
      pathMatch: 'full'
    },
    {
      path: 'unknown',
      component: UnknownComponent,
      pathMatch: 'full'
    },
    {
      path: 'unauthorized',
      component: UnauthorizedComponent,
      pathMatch: 'full'
    }
  ])
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
