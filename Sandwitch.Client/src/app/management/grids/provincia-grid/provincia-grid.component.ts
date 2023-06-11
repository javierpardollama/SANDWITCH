import {
  AfterViewInit,
  Component,
  OnInit
} from '@angular/core';

import { MatDialog } from '@angular/material/dialog';
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
export class ProvinciaGridComponent implements OnInit, AfterViewInit {

  public ELEMENT_DATA: ViewProvincia[] = [];

  public displayedColumns: string[] = ['Id', 'Name', 'ImageUri', 'LastModified'];

  public dataSource: MatTableDataSource<ViewProvincia> = new MatTableDataSource<ViewProvincia>();

  public page: FilterPage =
    {
      Index: 0,
      Size: 15,
      Length: 0
    };

  // Constructor
  constructor(
    private provinciaService: ProvinciaService,
    public matDialog: MatDialog) {

  }

  // Life Cicle
  ngOnInit(): void {
    window.addEventListener('scroll', this.TurnThePage, true);
  }

  ngAfterViewInit(): void {
    this.FindPaginatedProvincia();
  }

  // Get Data from Service
  public async FindPaginatedProvincia(): Promise<void> {
    const view = await this.provinciaService.FindPaginatedProvincia(this.page);

    this.page.Length = view.Length;

    this.ELEMENT_DATA = this.ELEMENT_DATA.concat(view.Items);

    this.dataSource.data = this.ELEMENT_DATA;
  }

  // Filter Data
  public ApplyMyFilter(target: EventTarget | null): void {
    this.dataSource.filter = (target as HTMLInputElement).value.trim().toLowerCase();
  }

  // Get Record from Table
  public GetRecord(row: ViewProvincia): void {
    const dialogRef = this.matDialog.open(ProvinciaUpdateModalComponent, {
      width: '450px',
      data: row
    });

    dialogRef.afterClosed().subscribe(() => {
      this.FindPaginatedProvincia();
    });
  }

  public AddRecord(): void {
    const dialogRef = this.matDialog.open(ProvinciaAddModalComponent, {
      width: '450px',
    });

    dialogRef.afterClosed().subscribe(() => {
      this.FindPaginatedProvincia();
    });
  }

  private TurnThePage = async (e: any): Promise<void> => {
    const tableViewHeight = e.target.offsetHeight;
    const tableScrollHeight = e.target.scrollHeight;
    const scrollLocation = e.target.scrollTop;

    const limit = tableScrollHeight - tableViewHeight - this.page.Size;
    
    if (scrollLocation > limit) {
      this.page.Index++;
      await this.FindPaginatedProvincia();
    }
  }
}
