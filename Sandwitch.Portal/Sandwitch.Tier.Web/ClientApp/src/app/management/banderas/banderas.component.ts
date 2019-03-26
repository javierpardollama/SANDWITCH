import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatPaginator, MatSort } from '@angular/material';
import { Bandera } from '../../../viewmodels/core/bandera';

import { BanderaService } from '../../../services/bandera.service.module';

@Component({
  selector: 'app-banderas',
  templateUrl: './banderas.component.html',
  styleUrls: ['./banderas.component.css']
})
export class BanderasComponent implements OnInit {

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  public ELEMENT_DATA: Bandera[];

  public displayedColumns: string[] = ['Id', 'Name', 'ImageUri', 'LastModified'];

  public dataSource: MatTableDataSource<Bandera>;

  // Constructor
  constructor(private banderaService: BanderaService) {

  }

  // Life Cicle
  ngOnInit() {
    this.FindAllBandera();
  }

  // Get Data from Service
  public FindAllBandera() {
    this.banderaService.FindAllBandera().subscribe(banderas => {
      this.ELEMENT_DATA = banderas;

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
