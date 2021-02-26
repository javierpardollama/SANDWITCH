import {
  AfterViewInit,
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
import { PageBase } from 'src/viewmodels/pagination/pagebase';
import { ScrollAppVariants } from 'src/variants/scroll.app.variants';

@Component({
  selector: 'app-bandera-grid',
  templateUrl: './bandera-grid.component.html',
  styleUrls: ['./bandera-grid.component.scss']
})
export class BanderaGridComponent implements OnInit, AfterViewInit {

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  public ELEMENT_DATA: ViewBandera[];

  public displayedColumns: string[] = ['Id', 'Name', 'ImageUri', 'LastModified'];

  public dataSource: MatTableDataSource<ViewBandera>;

  public page: PageBase =
    {
      Skip: 0,
      Take: 10
    };

  // Constructor
  constructor(
    private banderaService: BanderaService,
    public matDialog: MatDialog) {

  }

  // Life Cicle
  ngOnInit() {
    window.addEventListener('scroll', this.scrollEvent, true);
  }

  ngAfterViewInit(): void {
    this.FindPaginatedBandera();
  }

  // Get Data from Service
  public async FindPaginatedBandera() {
    this.ELEMENT_DATA = await this.banderaService.FindPaginatedBandera(this.page);

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
      this.FindPaginatedBandera();
    });
  }

  public AddRecord() {
    const dialogRef = this.matDialog.open(BanderaAddModalComponent, {
      width: '450px',
    });

    dialogRef.afterClosed().subscribe(result => {
      this.FindPaginatedBandera();
    });
  }

  private scrollEvent = async (e: any): Promise<void> => {
    const tableViewHeight = e.target.offsetHeight // viewport: container class with 500px
    const tableScrollHeight = e.target.scrollHeight // length of the table
    const scrollLocation = e.target.scrollTop; // how far user scrolled     

    // If the user has scrolled within 200px of the bottom, add more data
    const limit = tableScrollHeight - tableViewHeight - ScrollAppVariants.AppScrollBuffer;

    if (scrollLocation > limit) {

      this.page =
      {
        Skip: this.ELEMENT_DATA.length,
        Take: this.page.Take++
      };

      this.ELEMENT_DATA = this.ELEMENT_DATA.concat(await this.banderaService.FindPaginatedBandera(this.page));

      this.SetupMyTableSettings();
    }
  }
}
