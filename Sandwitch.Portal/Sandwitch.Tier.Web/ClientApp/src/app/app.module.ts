import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

// Angular Material
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSortModule, MatPaginatorModule, MatTableModule, MatCardModule, MatInputModule, MatFormFieldModule, MatButtonModule, MatSnackBarModule, MatAutocompleteModule } from '@angular/material';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { SearchComponent } from './search/search.component';
import { BanderasComponent } from './management/banderas/banderas.component';
import { PoblacionesComponent } from './management/poblaciones/poblaciones.component';
import { ProvinciasComponent } from './management/provincias/provincias.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    SearchComponent,
    BanderasComponent,
    PoblacionesComponent,
    ProvinciasComponent,
  ],
  imports: [
    // Angular Material
    BrowserAnimationsModule,
    MatInputModule,
    MatPaginatorModule,
    MatButtonModule,
    MatSnackBarModule,
    MatAutocompleteModule,
    MatCardModule,
    MatTableModule,
    MatSortModule,
    MatFormFieldModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,  
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'banderas', component: BanderasComponent, pathMatch: 'full' },
      { path: 'poblaciones', component: PoblacionesComponent, pathMatch: 'full' },
      { path: 'provincias', component: ProvinciasComponent, pathMatch: 'full' }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
