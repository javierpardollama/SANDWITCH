import { AfterViewInit, ChangeDetectionStrategy, Component, OnDestroy, OnInit, ViewChild, inject } from '@angular/core';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';

import { ViewTown } from '../../../../viewmodels/views/viewtown';

import { TownService } from '../../../../services/town.service';

import {
  TownUpdateModalComponent
} from '../../modals/updates/town-update-modal/town-update-modal.component';

import {
  TownAddModalComponent
} from '../../modals/additions/town-add-modal/town-add-modal.component';

import { FilterPage } from 'src/viewmodels/filters/filterpage';
import { ViewScroll } from 'src/viewmodels/views/viewscroll';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatChipsModule } from '@angular/material/chips';
import { MatFormFieldModule } from '@angular/material/form-field';
import { CommonModule } from '@angular/common';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatInputModule } from '@angular/material/input';

@Component({
  changeDetection: ChangeDetectionStrategy.OnPush,
  selector: 'app-town-grid',
  templateUrl: './town-grid.component.html',
  styleUrls: ['./town-grid.component.scss'],
  imports: [
    MatTableModule,
    MatDialogModule,
    FormsModule,
    MatButtonModule,
    MatTooltipModule,
    MatChipsModule,
    MatFormFieldModule,
    CommonModule,
    MatPaginatorModule,
    MatSortModule,
    MatInputModule
  ]
})
export class TownGridComponent implements OnInit, AfterViewInit, OnDestroy {
  // DI
  private townService = inject(TownService);
  matDialog = inject(MatDialog);

  @ViewChild(MatSort, { static: true }) sort!: MatSort;

  public loading: boolean = false;

  public ELEMENT_DATA: ViewTown[] = [];

  public displayedColumns: string[] = ['Id', 'Name', 'State', 'ImageUri', 'LastModified'];

  public dataSource: MatTableDataSource<ViewTown> = new MatTableDataSource<ViewTown>();

  public page: FilterPage =
    {
      Index: 0,
      Size: 15,
      Length: 0
    };

  // Constructor
  constructor() {
  }

  // Life Cicle
  ngOnInit(): void {
    window.addEventListener('scroll', this.TurnThePage, true);
  }

  async ngAfterViewInit(): Promise<void> {
    await this.FindPaginatedTown();
  }

  ngOnDestroy(): void {
    window.removeEventListener('scroll', this.TurnThePage, true);
  }

  // Get Data from Service
  public async FindPaginatedTown(): Promise<void> {
    this.loading = true;
    const view = await this.townService.FindPaginatedTown(this.page);
    this.loading = false;

    if (view) {
      this.page.Length = view?.Length;
      this.ELEMENT_DATA = Array.from(this.ELEMENT_DATA.concat(view?.Items).reduce((m, t): Map<ViewTown, ViewTown> => m.set(t?.Id, t), new Map()).values());
      this.dataSource.data = this.ELEMENT_DATA;
    }
  }

  // Filter Data
  public ApplyMyFilter(target: EventTarget | null): void {
    this.dataSource.filter = (target as HTMLInputElement).value.trim().toLowerCase();
  }

  // Get Record from Table
  public GetRecord(row: ViewTown): void {
    const dialogRef = this.matDialog.open(TownUpdateModalComponent, {
      width: '450px',
      data: row
    });

    dialogRef.afterClosed().subscribe(async () => {
      await this.FindPaginatedTown();
    });
  }

  public AddRecord(): void {
    const dialogRef = this.matDialog.open(TownAddModalComponent, {
      width: '450px',
    });

    dialogRef.afterClosed().subscribe(async () => {
      await this.FindPaginatedTown();
    });
  }

  private TurnThePage = async (event: Event): Promise<void> => {

    let scroll: ViewScroll = new ViewScroll(event.target as HTMLElement, this.page.Size, this.ELEMENT_DATA.length, this.page.Length);

    if (scroll.IsReached()) {
      this.page.Index++;
      await this.FindPaginatedTown();
    }
  }
}