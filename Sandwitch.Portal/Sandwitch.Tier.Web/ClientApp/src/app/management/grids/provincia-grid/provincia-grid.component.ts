import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatPaginator, MatSort, MatDialog } from '@angular/material';
import { ViewProvincia } from './../../../../viewmodels/views/viewprovincia';

import { ProvinciaService } from './../../../../services/provincia.service';

import { ProvinciaUpdateModalComponent } from './../../modals/updates/provincia-update-modal/provincia-update-modal.component';
import { ProvinciaAddModalComponent } from './../../modals/additions/provincia-add-modal/provincia-add-modal.component';

@Component({
  selector: 'app-provincia-grid',
  templateUrl: './provincia-grid.component.html',
  styleUrls: ['./provincia-grid.component.css']
})
export class ProvinciaGridComponent implements OnInit {

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort: MatSort;

  public ELEMENT_DATA: ViewProvincia[];

  public displayedColumns: string[] = ['Id', 'Name', 'ImageUri', 'LastModified'];

  public dataSource: MatTableDataSource<ViewProvincia>;

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
  public GetRecord(row: ViewProvincia) {
    const dialogRef = this.matDialog.open(ProvinciaUpdateModalComponent, {
      width: '450px',
      data: row
    });

    dialogRef.afterClosed().subscribe(result => {
      this.FindAllProvincia();
    });
  }

  public AddRecord() {
    const dialogRef = this.matDialog.open(ProvinciaAddModalComponent, {
      width: '450px',
    });

    dialogRef.afterClosed().subscribe(result => {
      this.FindAllProvincia();
    });
  }
}
