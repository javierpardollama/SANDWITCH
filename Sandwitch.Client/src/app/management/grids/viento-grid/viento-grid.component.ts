import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { VientoService } from '../../../../services/viento.service';
import { FilterPage } from '../../../../viewmodels/filters/filterpage';
import { ViewViento } from '../../../../viewmodels/views/viewviento';
import { ViewScroll } from '../../../../viewmodels/views/viewscroll';
import { VientoAddModalComponent } from '../../modals/additions/viento-add-modal/viento-add-modal.component';
import { VientoUpdateModalComponent } from '../../modals/updates/viento-update-modal/viento-update-modal.component';

@Component({
  selector: 'app-viento-grid',  
  templateUrl: './viento-grid.component.html',
  styleUrl: './viento-grid.component.scss'
})
export class VientoGridComponent {
  public ELEMENT_DATA: ViewViento[] = [];

  public displayedColumns: string[] = ['Id', 'Name', 'ImageUri', 'LastModified'];

  public dataSource: MatTableDataSource<ViewViento> = new MatTableDataSource<ViewViento>();

  public page: FilterPage =
    {
      Index: 0,
      Size: 15,
      Length: 0
    };

  // Constructor
  constructor(
    private vientoService: VientoService,
    public matDialog: MatDialog) {

  }

  // Life Cicle
  ngOnInit(): void {
    window.addEventListener('scroll', this.TurnThePage, true);
  }

  ngAfterViewInit(): void {
    this.FindPaginatedViento();
  }

  ngOnDestroy(): void {
    window.removeEventListener('scroll', this.TurnThePage, true);
  }

  // Get Data from Service
  public async FindPaginatedViento(): Promise<void> {
    const view = await this.vientoService.FindPaginatedViento(this.page);

    if (view) {
      this.page.Length = view?.Length;
      this.ELEMENT_DATA = Array.from(this.ELEMENT_DATA.concat(view?.Items).reduce((m, t): Map<ViewViento, ViewViento> => m.set(t?.Id, t), new Map()).values());
      this.dataSource.data = this.ELEMENT_DATA;
    }
  }

  // Filter Data
  public ApplyMyFilter(target: EventTarget | null): void {
    this.dataSource.filter = (target as HTMLInputElement).value.trim().toLowerCase();
  }

  // Get Record from Table
  public GetRecord(row: ViewViento): void {
    const dialogRef = this.matDialog.open(VientoUpdateModalComponent, {
      width: '450px',
      data: row
    });

    dialogRef.afterClosed().subscribe(() => {
      this.FindPaginatedViento();
    });
  }

  public AddRecord(): void {
    const dialogRef = this.matDialog.open(VientoAddModalComponent, {
      width: '450px',
    });

    dialogRef.afterClosed().subscribe(() => {
      this.FindPaginatedViento();
    });
  }

  private TurnThePage = async (event: Event): Promise<void> => {

    let scroll: ViewScroll = new ViewScroll(event.target as HTMLElement, this.page.Size);

    if (scroll.IsReached()) {
      this.page.Index++;
      await this.FindPaginatedViento();
    }
  }
}