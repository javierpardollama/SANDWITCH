import {
  AfterViewInit,
  Component,
  OnDestroy,
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
import { ViewScroll } from 'src/viewmodels/views/viewscroll';

@Component({
  selector: 'app-provincia-grid',
  templateUrl: './provincia-grid.component.html',
  styleUrls: ['./provincia-grid.component.scss']
})
export class ProvinciaGridComponent implements OnInit, AfterViewInit, OnDestroy {

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

  ngOnDestroy(): void {
    window.removeEventListener('scroll', this.TurnThePage, true);
  }

  // Get Data from Service
  public async FindPaginatedProvincia(): Promise<void> {
    const view = await this.provinciaService.FindPaginatedProvincia(this.page);

    if (view) {
      this.page.Length = view?.Length;
      this.ELEMENT_DATA = Array.from(this.ELEMENT_DATA.concat(view?.Items).reduce((m, t): Map<ViewProvincia, ViewProvincia> => m.set(t?.Id, t), new Map()).values());
      this.dataSource.data = this.ELEMENT_DATA;
    }
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

  private TurnThePage = async (event: Event): Promise<void> => {

    let scroll: ViewScroll = new ViewScroll(event.target as HTMLElement, this.page.Size);

    if (scroll.IsReached()) {
      this.page.Index++;
      await this.FindPaginatedProvincia();
    }
  }
}
