import {
  Component,
  OnInit,
  ViewChild
} from '@angular/core';

import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';

import { ViewBandera } from './../../../../viewmodels/views/viewbandera';

import { BanderaService } from './../../../../services/bandera.service';

import {
  BanderaUpdateModalComponent
} from './../../modals/updates/bandera-update-modal/bandera-update-modal.component';

import {
  BanderaAddModalComponent
} from './../../modals/additions/bandera-add-modal/bandera-add-modal.component';

@Component({
  selector: 'app-bandera-grid',
  templateUrl: './bandera-grid.component.html',
  styleUrls: ['./bandera-grid.component.css']
})
export class BanderaGridComponent implements OnInit {

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  public ELEMENT_DATA: ViewBandera[];

  public displayedColumns: string[] = ['Id', 'Name', 'ImageUri', 'LastModified'];

  public dataSource: MatTableDataSource<ViewBandera>;

  // Constructor
  constructor(
    private banderaService: BanderaService,
    public matDialog: MatDialog) {

  }

  // Life Cicle
  ngOnInit() {
    this.FindAllBandera();
  }

  // Get Data from Service
  public async FindAllBandera() {
    this.ELEMENT_DATA = await this.banderaService.FindAllBandera();

    this.SetupMyTableSettings();
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
  public GetRecord(row: ViewBandera) {
    const dialogRef = this.matDialog.open(BanderaUpdateModalComponent, {
      width: '450px',
      data: row
    });

    dialogRef.afterClosed().subscribe(result => {
      this.FindAllBandera();
    });
  }

  public AddRecord() {
    const dialogRef = this.matDialog.open(BanderaAddModalComponent, {
      width: '450px',
    });

    dialogRef.afterClosed().subscribe(result => {
      this.FindAllBandera();
    });
  }
}
