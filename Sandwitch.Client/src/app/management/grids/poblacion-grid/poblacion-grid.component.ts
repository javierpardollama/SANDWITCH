import {
  AfterViewInit,
  Component,
  OnInit,
  ViewChild
} from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
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
export class PoblacionGridComponent implements OnInit, AfterViewInit {

  @ViewChild(MatSort, { static: true }) sort!: MatSort;

  public ELEMENT_DATA: ViewPoblacion[] = [];

  public displayedColumns: string[] = ['Id', 'Name', 'Provincia', 'ImageUri', 'LastModified'];

  public dataSource: MatTableDataSource<ViewPoblacion> = new MatTableDataSource<ViewPoblacion>();

  public page: FilterPage =
    {
      Index: 0,
      Size: 15,
      Length: 0
    };

  // Constructor
  constructor(
    private poblacionService: PoblacionService,
    public matDialog: MatDialog) {
  }

  // Life Cicle
  ngOnInit(): void {
    window.addEventListener('scroll', this.TurnThePage, true);
  }

  ngAfterViewInit(): void {
    this.FindPaginatedPoblacion();
  }

  // Get Data from Service
  public async FindPaginatedPoblacion(): Promise<void> {
    const view = await this.poblacionService.FindPaginatedPoblacion(this.page);

    this.page.Length = view.Length;

    this.ELEMENT_DATA = this.ELEMENT_DATA.concat(view.Items);

    this.dataSource.data = this.ELEMENT_DATA;
  }

  // Filter Data
  public ApplyMyFilter(target: EventTarget | null): void {
    this.dataSource.filter = (target as HTMLInputElement).value.trim().toLowerCase();
  }

  // Get Record from Table
  public GetRecord(row: ViewPoblacion): void {
    const dialogRef = this.matDialog.open(PoblacionUpdateModalComponent, {
      width: '450px',
      data: row
    });

    dialogRef.afterClosed().subscribe(() => {
      this.FindPaginatedPoblacion();
    });
  }

  public AddRecord(): void {
    const dialogRef = this.matDialog.open(PoblacionAddModalComponent, {
      width: '450px',
    });

    dialogRef.afterClosed().subscribe(() => {
      this.FindPaginatedPoblacion();
    });
  }

  private TurnThePage = async (e: any): Promise<void> => {
    const tableViewHeight = e.target.offsetHeight;
    const tableScrollHeight = e.target.scrollHeight;
    const scrollLocation = e.target.scrollTop;

    const limit = tableScrollHeight - tableViewHeight - this.page.Size;
    
    if (scrollLocation > limit) {
      this.page.Index++;
      await this.FindPaginatedPoblacion();
    }
  }
}