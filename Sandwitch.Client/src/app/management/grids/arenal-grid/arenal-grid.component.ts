import { AfterViewInit, ChangeDetectionStrategy, Component, OnDestroy, OnInit, inject } from '@angular/core';

import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';

import { ViewArenal } from '../../../../viewmodels/views/viewarenal';

import { ArenalService } from '../../../../services/arenal.service';

import {
    ArenalUpdateModalComponent
} from '../../modals/updates/arenal-update-modal/arenal-update-modal.component';

import {
    ArenalAddModalComponent
} from '../../modals/additions/arenal-add-modal/arenal-add-modal.component';

import { FilterPage } from 'src/viewmodels/filters/filterpage';
import { ViewScroll } from 'src/viewmodels/views/viewscroll';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatChipsModule } from '@angular/material/chips';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatInputModule } from '@angular/material/input';


@Component({
    changeDetection: ChangeDetectionStrategy.OnPush,
    selector: 'app-arenal-grid',
    templateUrl: './arenal-grid.component.html',
    styleUrls: ['./arenal-grid.component.scss'],
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
export class ArenalGridComponent implements OnInit, AfterViewInit, OnDestroy {
    // DI
    private arenalService = inject(ArenalService);
    matDialog = inject(MatDialog);

    public loading: boolean = false;

    public ELEMENT_DATA: ViewArenal[] = [];

    public displayedColumns: string[] = ['Id', 'Name', 'Poblaciones', 'LastModified'];

    public dataSource: MatTableDataSource<ViewArenal> = new MatTableDataSource<ViewArenal>();

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
        await this.FindPaginatedArenal();
    }

    ngOnDestroy(): void {
        window.removeEventListener('scroll', this.TurnThePage, true);
    }

    // Get Data from Service
    public async FindPaginatedArenal(): Promise<void> {
        this.loading = true;
        const view = await this.arenalService.FindPaginatedArenal(this.page);
        this.loading = false;

        if (view) {
            this.page.Length = view.Length;
            this.ELEMENT_DATA = Array.from(this.ELEMENT_DATA.concat(view.Items).reduce((m, t): Map<ViewArenal, ViewArenal> => m.set(t.Id, t), new Map()).values());
            this.dataSource.data = this.ELEMENT_DATA;
        }
    }

    // Filter Data
    public ApplyMyFilter(target: EventTarget | null): void {
        this.dataSource.filter = (target as HTMLInputElement).value.trim().toLowerCase();
    }

    // Get Record from Table
    public GetRecord(row: ViewArenal): void {
        const dialogRef = this.matDialog.open(ArenalUpdateModalComponent, {
            width: '450px',
            data: row
        });

        dialogRef.afterClosed().subscribe(async () => {
            await this.FindPaginatedArenal();
        });
    }

    public AddRecord(): void {
        const dialogRef = this.matDialog.open(ArenalAddModalComponent, {
            width: '450px',
        });

        dialogRef.afterClosed().subscribe(async () => {
            await this.FindPaginatedArenal();
        });
    }


    private TurnThePage = async (event: Event): Promise<void> => {

        let scroll: ViewScroll = new ViewScroll(event.target as HTMLElement, this.page.Size, this.ELEMENT_DATA.length, this.page.Length);

        if (scroll.IsReached()) {
            this.page.Index++;
            await this.FindPaginatedArenal();
        }
    }
}
