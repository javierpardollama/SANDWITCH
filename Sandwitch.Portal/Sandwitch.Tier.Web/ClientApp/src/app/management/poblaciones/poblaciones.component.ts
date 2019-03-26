import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatPaginator, MatSort } from '@angular/material';
import { Poblacion } from '../../../viewmodels/core/poblacion';

import { PoblacionService } from '../../../services/poblacion.service.module';

@Component({
  selector: 'app-poblaciones',
  templateUrl: './poblaciones.component.html',
  styleUrls: ['./poblaciones.component.css']
})
export class PoblacionesComponent implements OnInit {

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  public ELEMENT_DATA: Poblacion[];

  public displayedColumns: string[] = ['Id', 'Name', 'Provincia', 'ImageUri', 'LastModified'];

  public dataSource: MatTableDataSource<Poblacion>;

  // Constructor
  constructor(private poblacionService: PoblacionService) {

  }

  // Life Cicle
  ngOnInit() {
    this.FindAllPoblacion();
  }

  // Get Data from Service
  public FindAllPoblacion() {
    this.poblacionService.FindAllPoblacion().subscribe(poblaciones => {
      this.ELEMENT_DATA = poblaciones;

      this.SetupMyTableSettings();
    });
  }

  // Setup Table Settings
  public SetupMyTableSettings() {
    this.dataSource = new MatTableDataSource(this.ELEMENT_DATA);

    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  // Filter Data
  public ApplyMyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
}
