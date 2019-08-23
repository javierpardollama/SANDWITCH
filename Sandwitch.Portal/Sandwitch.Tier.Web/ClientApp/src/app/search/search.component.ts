import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { ViewPoblacion } from './../../viewmodels/views/viewpoblacion';
import { ViewProvincia } from './../../viewmodels/views/viewprovincia';
import { ViewArenal } from './../../viewmodels/views/viewarenal';
import { ProvinciaService } from './../../services/provincia.service';
import { PoblacionService } from './../../services/poblacion.service';
import { ArenalService } from './../../services/arenal.service';
import { HistoricoAddModalComponent } from './../management/modals/additions/historico-add-modal/historico-add-modal.component';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  // Data
  public poblaciones: ViewPoblacion[];
  public filteredPoblaciones: Observable<ViewPoblacion[]>;
  public provincias: ViewProvincia[];
  public filteredProvincias: Observable<ViewProvincia[]>;
  public arenales: ViewArenal[];

  // Control
  public poblacionCtrl = new FormControl();
  public provinciaCtrl = new FormControl();

  // Constructor
  constructor(public matDialog: MatDialog,
    private provinciaService: ProvinciaService,
    private poblacionService: PoblacionService,
    private arenalService: ArenalService) {

  }

  // Life Cicle
  ngOnInit() {
    this.FindAllProvincia();
  }

  // Get Data from Service
  public FindAllArenalByPoblacionId(id: number) {
    this.arenalService.FindAllArenalByPoblacionId(id).subscribe(arenales => {
      this.arenales = arenales;
    });
  }

  // Get Data from Service
  public FindAllProvincia() {
    this.provinciaService.FindAllProvincia().subscribe(provincias => {
      this.provincias = provincias;

      this.filteredProvincias = this.provinciaCtrl.valueChanges
        .pipe(
          startWith(''),
          map(provincia => provincia ? this.FilterProvincias(provincia) : this.provincias.slice())
        );
    });
  }

  // Get Data from Service
  public FindAllPoblacionByProvinciaId(id: number) {
    this.poblacionService.FindAllPoblacionByProvinciaId(id).subscribe(poblaciones => {
      this.poblaciones = poblaciones;

      this.filteredPoblaciones = this.poblacionCtrl.valueChanges
        .pipe(
          startWith(''),
          map(poblacion => poblacion ? this.FilterPoblaciones(poblacion) : this.poblaciones.slice())
        );
    });

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
  public GetRecord(row: ViewArenal) {
    const dialogRef = this.matDialog.open(HistoricoAddModalComponent, {
      width: '600px',
      data: row
    });

    dialogRef.afterClosed().subscribe(result => {

    });
  }
}
