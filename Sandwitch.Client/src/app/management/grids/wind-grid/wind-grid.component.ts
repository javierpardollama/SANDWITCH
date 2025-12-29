import { AfterViewInit, ChangeDetectionStrategy, Component, OnDestroy, OnInit, inject } from '@angular/core';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { WindService } from '../../../../services/wind.service';
import { FilterPage } from '../../../../viewmodels/filters/filterpage';
import { ViewWind } from '../../../../viewmodels/views/viewwind';
import { ViewScroll } from '../../../../viewmodels/views/viewscroll';
import { WindAddModalComponent } from '../../modals/additions/wind-add-modal/wind-add-modal.component';
import { WindUpdateModalComponent } from '../../modals/updates/wind-update-modal/wind-update-modal.component';
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
  selector: 'app-wind-grid',
  templateUrl: './wind-grid.component.html',
  styleUrl: './wind-grid.component.scss',
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
export class WindGridComponent implements OnInit, AfterViewInit, OnDestroy {
  // DI
  private windService = inject(WindService);
  matDialog = inject(MatDialog);

  public loading: boolean = false;

  public ELEMENT_DATA: ViewWind[] = [];

  public displayedColumns: string[] = ['Id', 'Name', 'ImageUri', 'LastModified'];

  public dataSource: MatTableDataSource<ViewWind> = new MatTableDataSource<ViewWind>();

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
    await this.FindPaginatedViento();
  }

  ngOnDestroy(): void {
    window.removeEventListener('scroll', this.TurnThePage, true);
  }

  // Get Data from Service
  public async FindPaginatedViento(): Promise<void> {
    this.loading = true;
    const view = await this.windService.FindPaginatedWind(this.page);
    this.loading = false;

    if (view) {
      this.page.Length = view?.Length;
      this.ELEMENT_DATA = Array.from(this.ELEMENT_DATA.concat(view?.Items).reduce((m, t): Map<ViewWind, ViewWind> => m.set(t?.Id, t), new Map()).values());
      this.dataSource.data = this.ELEMENT_DATA;
    }
  }

  // Filter Data
  public ApplyMyFilter(target: EventTarget | null): void {
    this.dataSource.filter = (target as HTMLInputElement).value.trim().toLowerCase();
  }

  // Get Record from Table
  public GetRecord(row: ViewWind): void {
    const dialogRef = this.matDialog.open(WindUpdateModalComponent, {
      width: '450px',
      data: row
    });

    dialogRef.afterClosed().subscribe(async () => {
      await this.FindPaginatedViento();
    });
  }

  public AddRecord(): void {
    const dialogRef = this.matDialog.open(WindAddModalComponent, {
      width: '450px',
    });

    dialogRef.afterClosed().subscribe(async () => {
      await this.FindPaginatedViento();
    });
  }

  private TurnThePage = async (event: Event): Promise<void> => {

    let scroll: ViewScroll = new ViewScroll(event.target as HTMLElement, this.page.Size, this.ELEMENT_DATA.length, this.page.Length);

    if (scroll.IsReached()) {
      this.page.Index++;
      await this.FindPaginatedViento();
    }
  }
}