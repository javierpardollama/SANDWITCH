import {
  AfterViewInit,
  Component,
  OnInit
} from '@angular/core';

import { MatDialog } from '@angular/material/dialog';
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
export class BanderaGridComponent implements OnInit, AfterViewInit {

  public ELEMENT_DATA: ViewBandera[] = [];

  public displayedColumns: string[] = ['Id', 'Name', 'ImageUri', 'LastModified'];

  public dataSource: MatTableDataSource<ViewBandera> = new MatTableDataSource<ViewBandera>();

  public page: FilterPage =
    {
      Index: 0,
      Size: 15,
      Length: 0
    };

  // Constructor
  constructor(
    private banderaService: BanderaService,
    public matDialog: MatDialog) {

  }

  // Life Cicle
  ngOnInit(): void {
    window.addEventListener('scroll', this.TurnThePage, true);
  }

  ngAfterViewInit(): void {
    this.FindPaginatedBandera();
  }

  // Get Data from Service
  public async FindPaginatedBandera(): Promise<void> {
    const view = await this.banderaService.FindPaginatedBandera(this.page);

    this.page.Length = view.Length;

    this.ELEMENT_DATA = this.ELEMENT_DATA.concat(view.Items);

    this.dataSource.data = this.ELEMENT_DATA;
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

  private TurnThePage = async (e: any): Promise<void> => {
    const tableViewHeight = e.target.offsetHeight;
    const tableScrollHeight = e.target.scrollHeight;
    const scrollLocation = e.target.scrollTop;

    const limit = tableScrollHeight - tableViewHeight - this.page.Size;
    
    if (scrollLocation > limit) {
      this.page.Index++;
      await this.FindPaginatedBandera();
    }
  }
}
