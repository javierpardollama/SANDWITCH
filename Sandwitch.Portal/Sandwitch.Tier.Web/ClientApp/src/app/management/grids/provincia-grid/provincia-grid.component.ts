import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatPaginator, MatSort, MatDialog } from '@angular/material';
import { Provincia } from '../../../../viewmodels/core/provincia';

import { ProvinciaService } from '../../../../services/provincia.service.module';

import { ProvinciaUpdateModalComponent } from '../../modals/updates/provincia-update-modal/provincia-update-modal.component';
import { ProvinciaAddModalComponent } from '../../modals/additions/provincia-add-modal/provincia-add-modal.component';

@Component({
  selector: 'app-provincia-grid',
  templateUrl: './provincia-grid.component.html',
  styleUrls: ['./provincia-grid.component.css']
})
export class ProvinciaGridComponent implements OnInit {

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  public ELEMENT_DATA: Provincia[];

  public displayedColumns: string[] = ['Id', 'Name', 'ImageUri', 'LastModified'];

  public dataSource: MatTableDataSource<Provincia>;

  // Constructor
  constructor(private provinciaService: ProvinciaService,
    public matDialog: MatDialog) {

  }

  // Life Cicle
  ngOnInit() {
    this.FindAllProvincia();
  }

  // Get Data from Service
  public FindAllProvincia() {
    this.provinciaService.FindAllProvincia().subscribe(poblaciones => {
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
  public GetRecord(row: Provincia) {
    const dialogRef = this.matDialog.open(ProvinciaUpdateModalComponent, {
      width: '250px',
      data: row
    });

    dialogRef.afterClosed().subscribe(result => {
      this.FindAllProvincia();
    });
  }

  public AddRecord() {
    const dialogRef = this.matDialog.open(ProvinciaAddModalComponent, {
      width: '250px',
    });

    dialogRef.afterClosed().subscribe(result => {
      this.FindAllProvincia();
    });
  }
}
