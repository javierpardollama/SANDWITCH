import { BrowserModule } from '@angular/platform-browser';

import { NgModule } from '@angular/core';

import {
  FormsModule,
  ReactiveFormsModule
} from '@angular/forms';

import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

// Angular Material
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatChipsModule } from '@angular/material/chips';
import { MatDialogModule } from '@angular/material/dialog';
import { MatDividerModule } from '@angular/material/divider';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSelectModule } from '@angular/material/select';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';

// App
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { SearchComponent } from './search/search.component';

// App-Grid
import { BanderaGridComponent } from './management/grids/bandera-grid/bandera-grid.component';
import { PoblacionGridComponent } from './management/grids/poblacion-grid/poblacion-grid.component';
import { ProvinciaGridComponent } from './management/grids/provincia-grid/provincia-grid.component';
import { ArenalGridComponent } from './management/grids/arenal-grid/arenal-grid.component';

// App-Modal-Adition
import { ArenalAddModalComponent } from './management/modals/additions/arenal-add-modal/arenal-add-modal.component';
import { BanderaAddModalComponent } from './management/modals/additions/bandera-add-modal/bandera-add-modal.component';
import { ProvinciaAddModalComponent } from './management/modals/additions/provincia-add-modal/provincia-add-modal.component';
import { PoblacionAddModalComponent } from './management/modals/additions/poblacion-add-modal/poblacion-add-modal.component';
import { HistoricoAddModalComponent } from './management/modals/additions/historico-add-modal/historico-add-modal.component';

// App-Modal-Update
import { ArenalUpdateModalComponent } from './management/modals/updates/arenal-update-modal/arenal-update-modal.component';
import { BanderaUpdateModalComponent } from './management/modals/updates/bandera-update-modal/bandera-update-modal.component';
import { ProvinciaUpdateModalComponent } from './management/modals/updates/provincia-update-modal/provincia-update-modal.component';
import { PoblacionUpdateModalComponent } from './management/modals/updates/poblacion-update-modal/poblacion-update-modal.component';
import { AuthInterceptor } from 'src/interceptors/auth.interceptor';
import { NgOptimizedImage } from '@angular/common';

@NgModule({
  declarations: [
    // App
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    SearchComponent,
    // App-Grid
    BanderaGridComponent,
    PoblacionGridComponent,
    ProvinciaGridComponent,
    ArenalGridComponent,
    // App-Modal-Adition
    ArenalAddModalComponent,
    BanderaAddModalComponent,
    ProvinciaAddModalComponent,
    PoblacionAddModalComponent,
    HistoricoAddModalComponent,
    // App-Modal-Update
    ArenalUpdateModalComponent,
    BanderaUpdateModalComponent,
    ProvinciaUpdateModalComponent,
    PoblacionUpdateModalComponent
  ],
  imports: [
    // Angular Material
    BrowserAnimationsModule,
    MatDividerModule,
    MatSelectModule,
    MatInputModule,
    MatDialogModule,
    MatPaginatorModule,
    MatButtonModule,
    MatSnackBarModule,
    MatChipsModule,
    MatAutocompleteModule,
    MatCardModule,
    MatTableModule,
    MatSortModule,
    MatFormFieldModule,
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    NgOptimizedImage,
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
