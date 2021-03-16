import {
  AfterViewInit,
  Component,
  ViewChild
} from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';

import { ViewPoblacion } from './../../../../viewmodels/views/viewpoblacion';

import { PoblacionService } from './../../../../services/poblacion.service';

import {
  PoblacionUpdateModalComponent
} from './../../modals/updates/poblacion-update-modal/poblacion-update-modal.component';

import {
  PoblacionAddModalComponent
} from './../../modals/additions/poblacion-add-modal/poblacion-add-modal.component';

import { FilterPage } from 'src/viewmodels/filters/filterpage';

@Component({
  selector: 'app-poblacion-grid',
  templateUrl: './poblacion-grid.component.html',
  styleUrls: ['./poblacion-grid.component.scss']
})
export class PoblacionGridComponent implements AfterViewInit {

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  public ELEMENT_DATA: ViewPoblacion[] = [];

  public displayedColumns: string[] = ['Id', 'Name', 'Provincia', 'ImageUri', 'LastModified'];

  public dataSource: MatTableDataSource<ViewPoblacion> = new MatTableDataSource<ViewPoblacion>();

  public page: FilterPage =
    {
      Index: 0,
      Size: 0,
      Length: 0
    };

  // Constructor
  constructor(
    private poblacionService: PoblacionService,
    public matDialog: MatDialog) {

  }

  // Life Cicle
  ngAfterViewInit(): void {
    this.SetupMyTableSettings();

    // If the user changes the sort order, reset back to the first page.
    this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);

    this.page =
    {
      Index: 0,
      Size: this.paginator.pageSize
    };

    this.FindPaginatedPoblacion();
  }

  // Get Data from Service
  public async FindPaginatedPoblacion() {
    const view = await this.poblacionService.FindPaginatedPoblacion(this.page);

    this.ELEMENT_DATA = this.ELEMENT_DATA.concat(view.Items);

    this.page.Length = view.Length;

    this.dataSource.data = this.ELEMENT_DATA;
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

    dialogRef.afterClosed().subscribe(() => {
      this.FindPaginatedPoblacion();
    });
  }

  public AddRecord() {
    const dialogRef = this.matDialog.open(PoblacionAddModalComponent, {
      width: '450px',
    });

    dialogRef.afterClosed().subscribe(() => {
      this.FindPaginatedPoblacion();
    });
  }

  public async TurnThePage(event: PageEvent) {
    this.page =
    {
      Index: event.pageIndex,
      Size: event.pageSize
    };

    await this.FindPaginatedPoblacion();
  }
}