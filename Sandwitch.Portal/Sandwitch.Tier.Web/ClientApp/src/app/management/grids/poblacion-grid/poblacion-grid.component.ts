import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatPaginator, MatSort, MatDialog } from '@angular/material';
import { Poblacion } from '../../../../viewmodels/core/poblacion';

import { PoblacionService } from '../../../../services/poblacion.service.module';

import { PoblacionUpdateModalComponent } from '../../modals/updates/poblacion-update-modal/poblacion-update-modal.component';

@Component({
  selector: 'app-poblacion-grid',
  templateUrl: './poblacion-grid.component.html',
  styleUrls: ['./poblacion-grid.component.css']
})
export class PoblacionGridComponent implements OnInit {

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  public ELEMENT_DATA: Poblacion[];

  public displayedColumns: string[] = ['Id', 'Name', 'Provincia', 'ImageUri', 'LastModified'];

  public dataSource: MatTableDataSource<Poblacion>;

  // Constructor
  constructor(private poblacionService: PoblacionService,
    public matDialog: MatDialog) {

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

  // Get Record from Table
  public GetRecord(row: Poblacion) {
    const dialogRef = this.matDialog.open(PoblacionUpdateModalComponent, {
      width: '250px',
      data: row
    });

    dialogRef.afterClosed().subscribe(result => {
      this.FindAllPoblacion();
    });
  }
}