import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () => import('./home/home.component').then((m) => m.HomeComponent),
    pathMatch: 'full'
  },
  {
    path: 'management/winds',
    loadComponent: () => import('./management/grids/wind-grid/wind-grid.component').then((m) => m.WindGridComponent),
    pathMatch: 'full'
  },
  {
    path: 'management/flags',
    loadComponent: () => import('./management/grids/flag-grid/flag-grid.component').then((m) => m.FlagGridComponent),
    pathMatch: 'full'
  },
  {
    path: 'management/towns',
    loadComponent: () => import('./management/grids/town-grid/town-grid.component').then((m) => m.TownGridComponent),
    pathMatch: 'full'
  },
  {
    path: 'management/states',
    loadComponent: () => import('./management/grids/state-grid/state-grid.component').then((m) => m.StateGridComponent),
    pathMatch: 'full'
  },
  {
    path: 'management/beaches',
    loadComponent: () => import('./management/grids/beach-grid/beach-grid.component').then((m) => m.BeachGridComponent),
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
