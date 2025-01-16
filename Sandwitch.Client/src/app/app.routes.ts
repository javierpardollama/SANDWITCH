import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () => import('./home/home.component').then((m) => m.HomeComponent),
    pathMatch: 'full'
  },
  {
    path: 'management/vientos',
    loadComponent: () => import('./management/grids/viento-grid/viento-grid.component').then((m) => m.VientoGridComponent),
    pathMatch: 'full'
  },
  {
    path: 'management/banderas',
    loadComponent: () => import('./management/grids/bandera-grid/bandera-grid.component').then((m) => m.BanderaGridComponent),
    pathMatch: 'full'
  },
  {
    path: 'management/poblaciones',
    loadComponent: () => import('./management/grids/poblacion-grid/poblacion-grid.component').then((m) => m.PoblacionGridComponent),
    pathMatch: 'full'
  },
  {
    path: 'management/provincias',
    loadComponent: () => import('./management/grids/provincia-grid/provincia-grid.component').then((m) => m.ProvinciaGridComponent),
    pathMatch: 'full'
  },
  {
    path: 'management/arenales',
    loadComponent: () => import('./management/grids/arenal-grid/arenal-grid.component').then((m) => m.ArenalGridComponent),
    pathMatch: 'full'
  },
  {
    path: 'unknown',
    loadComponent: () => import('./unknown/unknown.component').then((m) => m.UnknownComponent),
    pathMatch: 'full'
  },
  {
    path: 'unauthorized',
    loadComponent: () => import('./unauthorized/unauthorized.component').then((m) => m.UnauthorizedComponent),
    pathMatch: 'full'
  }];
