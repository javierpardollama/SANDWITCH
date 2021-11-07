import {
  AfterViewInit,
  Component,
  ViewChild
} from '@angular/core';

import { MatDialog } from '@angular/material/dialog';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';

import { ViewProvincia } from './../../../../viewmodels/views/viewprovincia';

import { ProvinciaService } from './../../../../services/provincia.service';

import {
  ProvinciaUpdateModalComponent
} from './../../modals/updates/provincia-update-modal/provincia-update-modal.component';

import {
  ProvinciaAddModalComponent
} from './../../modals/additions/provincia-add-modal/provincia-add-modal.component';

import { FilterPage } from 'src/viewmodels/filters/filterpage';

@Component({
  selector: 'app-provincia-grid',
  templateUrl: './provincia-grid.component.html',
  styleUrls: ['./provincia-grid.component.scss']
})
export class ProvinciaGridComponent implements AfterViewInit {

  @ViewChild(MatPaginator, { static: true }) paginator!: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort!: MatSort;

  public ELEMENT_DATA: ViewProvincia[] = [];

  public displayedColumns: string[] = ['Id', 'Name', 'ImageUri', 'LastModified'];

  public dataSource: MatTableDataSource<ViewProvincia> = new MatTableDataSource<ViewProvincia>();

  public page: FilterPage =
    {
      Index: 0,
      Size: 0,
      Length: 0
    };

  // Constructor
  constructor(
    private provinciaService: ProvinciaService,
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
    this.FindPaginatedProvincia();
  }

  // Get Data from Service
  public async FindPaginatedProvincia() {
    const view = await this.provinciaService.FindPaginatedProvincia(this.page);

    this.ELEMENT_DATA = this.ELEMENT_DATA.concat(view.Items);

    this.page.Length = view.Length;

    this.dataSource.data = this.ELEMENT_DATA;
  }

  // Setup Table Settings
  public SetupMyTableSettings() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  // Filter Data
  public ApplyMyFilter(target: EventTarget | null) {
    this.dataSource.filter = (target as HTMLTextAreaElement).value.trim().toLowerCase();
  }

  // Get Record from Table
  public GetRecord(row: ViewProvincia) {
    const dialogRef = this.matDialog.open(ProvinciaUpdateModalComponent, {
      width: '450px',
      data: row
    });

    dialogRef.afterClosed().subscribe(() => {
      this.FindPaginatedProvincia();
    });
  }

  public AddRecord() {
    const dialogRef = this.matDialog.open(ProvinciaAddModalComponent, {
      width: '450px',
    });

    dialogRef.afterClosed().subscribe(() => {
      this.FindPaginatedProvincia();
    });
  }

  public async TurnThePage(event: PageEvent) {
    this.page =
    {
      Index: event.pageIndex,
      Size: event.pageSize
    };

    await this.FindPaginatedProvincia();
  }
}
