import { AfterViewInit, ChangeDetectionStrategy, Component, OnDestroy, OnInit, inject } from '@angular/core';

import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';

import { ViewFlag } from '../../../../viewmodels/views/viewflag';

import { FlagService } from '../../../../services/flag.service';

import {
  FlagUpdateModalComponent
} from '../../modals/updates/flag-update-modal/flag-update-modal.component';

import {
  FlagAddModalComponent
} from '../../modals/additions/flag-add-modal/flag-add-modal.component';

import { FilterPage } from 'src/viewmodels/filters/filterpage';
import { ViewScroll } from 'src/viewmodels/views/viewscroll';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatChipsModule } from '@angular/material/chips';
import { MatFormFieldModule } from '@angular/material/form-field';
import { CommonModule } from '@angular/common';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatInputModule } from '@angular/material/input';

@Component({
  changeDetection: ChangeDetectionStrategy.OnPush,
  selector: 'app-flag-grid',
  templateUrl: './flag-grid.component.html',
  styleUrls: ['./flag-grid.component.scss'],
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
export class FlagGridComponent implements OnInit, AfterViewInit, OnDestroy {
  // DI
  private flagService = inject(FlagService);
  matDialog = inject(MatDialog);

  public loading: boolean = false;

  public ELEMENT_DATA: ViewFlag[] = [];

  public displayedColumns: string[] = ['Id', 'Name', 'ImageUri', 'LastModified'];

  public dataSource: MatTableDataSource<ViewFlag> = new MatTableDataSource<ViewFlag>();

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
    await this.FindPaginatedFlag();
  }

  ngOnDestroy(): void {
    window.removeEventListener('scroll', this.TurnThePage, true);
  }

  // Get Data from Service
  public async FindPaginatedFlag(): Promise<void> {
    this.loading = true;
    const view = await this.flagService.FindPaginatedFlag(this.page);
    this.loading = false;

    if (view) {
      this.page.Length = view?.Length;
      this.ELEMENT_DATA = Array.from(this.ELEMENT_DATA.concat(view?.Items).reduce((m, t): Map<ViewFlag, ViewFlag> => m.set(t?.Id, t), new Map()).values());
      this.dataSource.data = this.ELEMENT_DATA;
    }
  }

  // Filter Data
  public ApplyMyFilter(target: EventTarget | null): void {
    this.dataSource.filter = (target as HTMLInputElement).value.trim().toLowerCase();
  }

  // Get Record from Table
  public GetRecord(row: ViewFlag): void {
    const dialogRef = this.matDialog.open(FlagUpdateModalComponent, {
      width: '450px',
      data: row
    });

    dialogRef.afterClosed().subscribe(async () => {
      await this.FindPaginatedFlag();
    });
  }

  public AddRecord(): void {
    const dialogRef = this.matDialog.open(FlagAddModalComponent, {
      width: '450px',
    });

    dialogRef.afterClosed().subscribe(async () => {
      await this.FindPaginatedFlag();
    });
  }

  private TurnThePage = async (event: Event): Promise<void> => {

    let scroll: ViewScroll = new ViewScroll(event.target as HTMLElement, this.page.Size, this.ELEMENT_DATA.length, this.page.Length);

    if (scroll.IsReached()) {
      this.page.Index++;
      await this.FindPaginatedFlag();
    }
  }
}
