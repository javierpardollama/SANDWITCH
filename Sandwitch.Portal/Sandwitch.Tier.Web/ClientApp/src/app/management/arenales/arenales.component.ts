import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatPaginator, MatSort } from '@angular/material';
import { Arenal } from '../../../viewmodels/core/arenal';

import { ArenalService } from '../../../services/arenal.service.module';

@Component({
  selector: 'app-arenales',
  templateUrl: './arenales.component.html',
  styleUrls: ['./arenales.component.css']
})
export class ArenalesComponent implements OnInit {

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  public ELEMENT_DATA: Arenal[];

  public displayedColumns: string[] = ['Id', 'Name', 'Poblaciones', 'LastModified'];

  public dataSource: MatTableDataSource<Arenal>;

  // Constructor
  constructor(private arenalService: ArenalService) {

  }

  // Life Cicle
  ngOnInit() {
    this.FindAllArenal();
  }

  // Get Data from Service
  public FindAllArenal() {
    this.arenalService.FindAllArenal().subscribe(arenales => {
      this.ELEMENT_DATA = arenales;

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
  public GetRecord(row: Arenal) {
    
  }
}
