import {
  AfterViewInit,
  Component,
  ViewChild
} from '@angular/core';

import { MatDialog } from '@angular/material/dialog';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
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

import { FilterPage } from 'src/viewmodels/filters/filterpage';

@Component({
  selector: 'app-bandera-grid',
  templateUrl: './bandera-grid.component.html',
  styleUrls: ['./bandera-grid.component.scss']
})
export class BanderaGridComponent implements AfterViewInit {

  @ViewChild(MatPaginator, { static: true }) paginator!: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort!: MatSort;

  public ELEMENT_DATA: ViewBandera[] = [];

  public displayedColumns: string[] = ['Id', 'Name', 'ImageUri', 'LastModified'];

  public dataSource: MatTableDataSource<ViewBandera> = new MatTableDataSource<ViewBandera>();

  public page: FilterPage =
    {
      Index: 0,
      Size: 0,
      Length: 0
    };

  // Constructor
  constructor(
    private banderaService: BanderaService,
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
      Size: this.paginator.pageSize,
      Length: 0
    };

    this.FindPaginatedBandera();

  }

  // Get Data from Service
  public async FindPaginatedBandera(): Promise<void> {
    const view = await this.banderaService.FindPaginatedBandera(this.page);

    this.page.Length = view.Length;

    this.dataSource.data = Array.from(this.ELEMENT_DATA.concat(view.Items).reduce((m, t): Map<ViewBandera, ViewBandera> => m.set(t.Id, t), new Map()).values());
  }

  // Setup Table Settings
  public SetupMyTableSettings(): void {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  // Filter Data
  public ApplyMyFilter(target: EventTarget | null): void {
    this.dataSource.filter = (target as HTMLInputElement).value.trim().toLowerCase();
  }

  // Get Record from Table
  public GetRecord(row: ViewBandera): void {
    const dialogRef = this.matDialog.open(BanderaUpdateModalComponent, {
      width: '450px',
      data: row
    });

    dialogRef.afterClosed().subscribe(() => {
      this.FindPaginatedBandera();
    });
  }

  public AddRecord(): void {
    const dialogRef = this.matDialog.open(BanderaAddModalComponent, {
      width: '450px',
    });

    dialogRef.afterClosed().subscribe(() => {
      this.FindPaginatedBandera();
    });
  }

  public async TurnThePage(event: PageEvent) {
    this.page =
    {
      Index: event.pageIndex,
      Size: event.pageSize
    };

    await this.FindPaginatedBandera();
  }
}
