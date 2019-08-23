import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

// Angular Material
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {
  MatDialogModule, MatChipsModule, MatSortModule, MatPaginatorModule, MatTableModule, MatCardModule, MatDividerModule,
  MatInputModule, MatFormFieldModule, MatButtonModule, MatSnackBarModule, MatAutocompleteModule, MatSelectModule
} from '@angular/material';

// Directives
import { NumericTypeDirective } from './../directives/numeric-type.directive';

// App
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

@NgModule({
  declarations: [
     // Directives
     NumericTypeDirective,
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
  exports:[
     // Directives
     NumericTypeDirective
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
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'management/banderas', component: BanderaGridComponent, pathMatch: 'full' },
      { path: 'management/poblaciones', component: PoblacionGridComponent, pathMatch: 'full' },
      { path: 'management/provincias', component: ProvinciaGridComponent, pathMatch: 'full' },
      { path: 'management/arenales', component: ArenalGridComponent, pathMatch: 'full' }
    ])
  ],
  entryComponents: [ArenalUpdateModalComponent, BanderaUpdateModalComponent, ProvinciaUpdateModalComponent, PoblacionUpdateModalComponent,
    ArenalAddModalComponent, BanderaAddModalComponent, ProvinciaAddModalComponent, PoblacionAddModalComponent, HistoricoAddModalComponent],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
