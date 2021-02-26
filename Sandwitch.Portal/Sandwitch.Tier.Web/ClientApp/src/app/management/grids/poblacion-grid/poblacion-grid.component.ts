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

import { ViewPoblacion } from './../../../../viewmodels/views/viewpoblacion';

import { PoblacionService } from './../../../../services/poblacion.service';

import {
  PoblacionUpdateModalComponent
} from './../../modals/updates/poblacion-update-modal/poblacion-update-modal.component';

import {
  PoblacionAddModalComponent
} from './../../modals/additions/poblacion-add-modal/poblacion-add-modal.component';
import { PageBase } from 'src/viewmodels/pagination/pagebase';
import { ScrollAppVariants } from 'src/variants/scroll.app.variants';

@Component({
  selector: 'app-poblacion-grid',
  templateUrl: './poblacion-grid.component.html',
  styleUrls: ['./poblacion-grid.component.scss']
})
export class PoblacionGridComponent implements OnInit, AfterViewInit {

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  public ELEMENT_DATA: ViewPoblacion[];

  public displayedColumns: string[] = ['Id', 'Name', 'Provincia', 'ImageUri', 'LastModified'];

  public dataSource: MatTableDataSource<ViewPoblacion>;

  public page: PageBase =
    {
      Skip: 0,
      Take: 10
    };

  // Constructor
  constructor(
    private poblacionService: PoblacionService,
    public matDialog: MatDialog) {

  }

  // Life Cicle
  ngOnInit() {
    window.addEventListener('scroll', this.scrollEvent, true);
  }

  ngAfterViewInit(): void {
    this.FindPaginatedPoblacion();
  }

  // Get Data from Service
  public async FindPaginatedPoblacion() {
    this.ELEMENT_DATA = await this.poblacionService.FindPaginatedPoblacion(this.page);

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
  public GetRecord(row: ViewPoblacion) {
    const dialogRef = this.matDialog.open(PoblacionUpdateModalComponent, {
      width: '450px',
      data: row
    });

    dialogRef.afterClosed().subscribe(result => {
      this.FindPaginatedPoblacion();
    });
  }
  public AddRecord() {
    const dialogRef = this.matDialog.open(PoblacionAddModalComponent, {
      width: '450px',
    });

    dialogRef.afterClosed().subscribe(result => {
      this.FindPaginatedPoblacion();
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

      this.ELEMENT_DATA = this.ELEMENT_DATA.concat(await this.poblacionService.FindPaginatedPoblacion(this.page));

      this.SetupMyTableSettings();
    }
  }
}