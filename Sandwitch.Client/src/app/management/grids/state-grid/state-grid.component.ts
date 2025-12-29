import { AfterViewInit, ChangeDetectionStrategy, Component, OnDestroy, OnInit, inject } from '@angular/core';

import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';

import { ViewState } from '../../../../viewmodels/views/viewstate';

import { StateService } from '../../../../services/state.service';

import {
  StateUpdateModalComponent
} from '../../modals/updates/state-update-modal/state-update-modal.component';

import {
  StateAddModalComponent
} from '../../modals/additions/state-add-modal/state-add-modal.component';

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
  selector: 'app-state-grid',
  templateUrl: './state-grid.component.html',
  styleUrls: ['./state-grid.component.scss'],
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
export class StateGridComponent implements OnInit, AfterViewInit, OnDestroy {
  // DI
  private stateService = inject(StateService);
  matDialog = inject(MatDialog);

  public loading: boolean = false;

  public ELEMENT_DATA: ViewState[] = [];

  public displayedColumns: string[] = ['Id', 'Name', 'ImageUri', 'LastModified'];

  public dataSource: MatTableDataSource<ViewState> = new MatTableDataSource<ViewState>();

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
    await this.FindPaginatedState();
  }

  ngOnDestroy(): void {
    window.removeEventListener('scroll', this.TurnThePage, true);
  }

  // Get Data from Service
  public async FindPaginatedState(): Promise<void> {
    this.loading = true;
    const view = await this.stateService.FindPaginatedState(this.page);
    this.loading = false;

    if (view) {
      this.page.Length = view?.Length;
      this.ELEMENT_DATA = Array.from(this.ELEMENT_DATA.concat(view?.Items).reduce((m, t): Map<ViewState, ViewState> => m.set(t?.Id, t), new Map()).values());
      this.dataSource.data = this.ELEMENT_DATA;
    }
  }

  // Filter Data
  public ApplyMyFilter(target: EventTarget | null): void {
    this.dataSource.filter = (target as HTMLInputElement).value.trim().toLowerCase();
  }

  // Get Record from Table
  public GetRecord(row: ViewState): void {
    const dialogRef = this.matDialog.open(StateUpdateModalComponent, {
      width: '450px',
      data: row
    });

    dialogRef.afterClosed().subscribe(async () => {
      await this.FindPaginatedState();
    });
  }

  public AddRecord(): void {
    const dialogRef = this.matDialog.open(StateAddModalComponent, {
      width: '450px',
    });

    dialogRef.afterClosed().subscribe(async () => {
      await this.FindPaginatedState();
    });
  }

  private TurnThePage = async (event: Event): Promise<void> => {

    let scroll: ViewScroll = new ViewScroll(event.target as HTMLElement, this.page.Size, this.ELEMENT_DATA.length, this.page.Length);

    if (scroll.IsReached()) {
      this.page.Index++;
      await this.FindPaginatedState();
    }
  }
}
