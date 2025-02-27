import {
  Component,
  OnInit
} from '@angular/core';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';

import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';

import { Observable, of } from 'rxjs';

import {
  map,
  startWith
} from 'rxjs/operators';
import { ViewPoblacion } from './../../viewmodels/views/viewpoblacion';

import { ViewProvincia } from './../../viewmodels/views/viewprovincia';

import { ViewArenal } from './../../viewmodels/views/viewarenal';

import { ProvinciaService } from './../../services/provincia.service';

import { PoblacionService } from './../../services/poblacion.service';

import { ArenalService } from './../../services/arenal.service';

import {
  HistoricoAddModalComponent
} from './../management/modals/additions/historico-add-modal/historico-add-modal.component';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatChipsModule } from '@angular/material/chips';
import { MatDividerModule } from '@angular/material/divider';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSelectModule } from '@angular/material/select';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { CommonModule, NgOptimizedImage } from '@angular/common';

@Component({
    selector: 'app-search',
    templateUrl: './search.component.html',
    styleUrls: ['./search.component.scss'],
    imports: [
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
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        NgOptimizedImage
    ]
})
export class SearchComponent implements OnInit {

  // Data
  public poblaciones: ViewPoblacion[] = [];
  public filteredPoblaciones: Observable<ViewPoblacion[]> = of([]);
  public provincias: ViewProvincia[] = [];
  public filteredProvincias: Observable<ViewProvincia[]> = of([]);
  public arenales: ViewArenal[] = [];

  // Control
  public poblacionCtrl = new FormControl();
  public provinciaCtrl = new FormControl();

  // Constructor
  constructor(
    public matDialog: MatDialog,
    private provinciaService: ProvinciaService,
    private poblacionService: PoblacionService,
    private arenalService: ArenalService) {

  }

  // Life Cicle
  ngOnInit(): void {
    this.FindAllProvincia();
  }

  // Get Data from Service
  public async FindAllArenalByPoblacionId(id: string): Promise<void> {
    this.arenales = await this.arenalService.FindAllArenalByPoblacionId(Number(id));
  }

  // Get Data from Service
  public async FindAllProvincia(): Promise<void> {
    this.provincias = await this.provinciaService.FindAllProvincia();

    this.filteredProvincias = this.provinciaCtrl.valueChanges
      .pipe(
        startWith(''),
        map(provincia => provincia ? this.FilterProvincias(provincia) : this.provincias.slice())
      );
  }

  // Get Data from Service
  public async FindAllPoblacionByProvinciaId(id: string): Promise<void> {
    this.poblaciones = await this.poblacionService.FindAllPoblacionByProvinciaId(Number(id));

    this.filteredPoblaciones = this.poblacionCtrl.valueChanges
      .pipe(
        startWith(''),
        map(poblacion => poblacion ? this.FilterPoblaciones(poblacion) : this.poblaciones.slice())
      );
  }

  // Filter Data
  public FilterProvincias(value: string): ViewProvincia[] {
    const filterValue = value.toLowerCase();

    return this.provincias.filter(provincia => provincia.Name.toLowerCase().indexOf(filterValue) === 0);
  }

  // Filter Data
  public FilterPoblaciones(value: string): ViewPoblacion[] {
    const filterValue = value.toLowerCase();

    return this.poblaciones.filter(poblacion => poblacion.Name.toLowerCase().indexOf(filterValue) === 0);
  }

  // Get Record from Card
  public GetRecord(row: ViewArenal): void {
    const dialogRef = this.matDialog.open(HistoricoAddModalComponent, {
      width: '600px',
      data: row
    });

    dialogRef.afterClosed().subscribe(result => {

    });
  }
}
