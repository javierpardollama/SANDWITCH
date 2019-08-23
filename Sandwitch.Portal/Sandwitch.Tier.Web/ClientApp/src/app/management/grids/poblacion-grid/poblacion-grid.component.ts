import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatPaginator, MatSort, MatDialog } from '@angular/material';
import { ViewPoblacion } from './../../../../viewmodels/views/viewpoblacion';

import { PoblacionService } from './../../../../services/poblacion.service';

import { PoblacionUpdateModalComponent } from './../../modals/updates/poblacion-update-modal/poblacion-update-modal.component';
import { PoblacionAddModalComponent } from './../../modals/additions/poblacion-add-modal/poblacion-add-modal.component';

@Component({
  selector: 'app-poblacion-grid',
  templateUrl: './poblacion-grid.component.html',
  styleUrls: ['./poblacion-grid.component.css']
})
export class PoblacionGridComponent implements OnInit {

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort: MatSort;

  public ELEMENT_DATA: ViewPoblacion[];

  public displayedColumns: string[] = ['Id', 'Name', 'Provincia', 'ImageUri', 'LastModified'];

  public dataSource: MatTableDataSource<ViewPoblacion>;

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
  public GetRecord(row: ViewPoblacion) {
    const dialogRef = this.matDialog.open(PoblacionUpdateModalComponent, {
      width: '450px',
      data: row
    });

    dialogRef.afterClosed().subscribe(result => {
      this.FindAllPoblacion();
    });
  }
  public AddRecord() {
    const dialogRef = this.matDialog.open(PoblacionAddModalComponent, {
      width: '450px',
    });

    dialogRef.afterClosed().subscribe(result => {
      this.FindAllPoblacion();
    });
  }
}
