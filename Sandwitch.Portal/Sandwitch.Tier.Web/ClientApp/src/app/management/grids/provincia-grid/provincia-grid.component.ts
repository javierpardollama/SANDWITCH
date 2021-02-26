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

import { ViewProvincia } from './../../../../viewmodels/views/viewprovincia';

import { ProvinciaService } from './../../../../services/provincia.service';

import {
  ProvinciaUpdateModalComponent
} from './../../modals/updates/provincia-update-modal/provincia-update-modal.component';

import {
  ProvinciaAddModalComponent
} from './../../modals/additions/provincia-add-modal/provincia-add-modal.component';
import { PageBase } from 'src/viewmodels/pagination/pagebase';
import { ScrollAppVariants } from 'src/variants/scroll.app.variants';

@Component({
  selector: 'app-provincia-grid',
  templateUrl: './provincia-grid.component.html',
  styleUrls: ['./provincia-grid.component.scss']
})
export class ProvinciaGridComponent implements OnInit, AfterViewInit {

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  public ELEMENT_DATA: ViewProvincia[];

  public displayedColumns: string[] = ['Id', 'Name', 'ImageUri', 'LastModified'];

  public dataSource: MatTableDataSource<ViewProvincia>;

  public page: PageBase =
    {
      Skip: 0,
      Take: 10
    };

  // Constructor
  constructor(
    private provinciaService: ProvinciaService,
    public matDialog: MatDialog) {

  }

  // Life Cicle
  ngOnInit() {
    window.addEventListener('scroll', this.scrollEvent, true);
  }

  ngAfterViewInit(): void {
    this.FindPaginatedProvincia();
  }

  // Get Data from Service
  public async FindPaginatedProvincia() {
    this.ELEMENT_DATA = await this.provinciaService.FindPaginatedProvincia(this.page);

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
  public GetRecord(row: ViewProvincia) {
    const dialogRef = this.matDialog.open(ProvinciaUpdateModalComponent, {
      width: '450px',
      data: row
    });

    dialogRef.afterClosed().subscribe(result => {
      this.FindPaginatedProvincia();
    });
  }

  public AddRecord() {
    const dialogRef = this.matDialog.open(ProvinciaAddModalComponent, {
      width: '450px',
    });

    dialogRef.afterClosed().subscribe(result => {
      this.FindPaginatedProvincia();
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

      this.ELEMENT_DATA = this.ELEMENT_DATA.concat(await this.provinciaService.FindPaginatedProvincia(this.page));

      this.SetupMyTableSettings();
    }
  }
}
