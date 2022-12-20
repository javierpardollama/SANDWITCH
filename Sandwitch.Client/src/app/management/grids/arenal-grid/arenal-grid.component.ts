import {
    AfterViewInit,
    Component,
    ViewChild
} from '@angular/core';

import { MatDialog } from '@angular/material/dialog';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';

import { ViewArenal } from './../../../../viewmodels/views/viewarenal';

import { ArenalService } from './../../../../services/arenal.service';

import {
    ArenalUpdateModalComponent
} from './../../modals/updates/arenal-update-modal/arenal-update-modal.component';

import {
    ArenalAddModalComponent
} from './../../modals/additions/arenal-add-modal/arenal-add-modal.component';

import { FilterPage } from 'src/viewmodels/filters/filterpage';


@Component({
    selector: 'app-arenal-grid',
    templateUrl: './arenal-grid.component.html',
    styleUrls: ['./arenal-grid.component.scss']
})
export class ArenalGridComponent implements AfterViewInit {

    @ViewChild(MatPaginator) paginator!: MatPaginator;
    @ViewChild(MatSort) sort!: MatSort;

    public ELEMENT_DATA: ViewArenal[] = [];

    public displayedColumns: string[] = ['Id', 'Name', 'Poblaciones', 'LastModified'];

    public dataSource: MatTableDataSource<ViewArenal> = new MatTableDataSource<ViewArenal>();

    public page: FilterPage =
        {
            Index: 0,
            Size: 0,
            Length: 0
        };

    // Constructor
    constructor(
        private arenalService: ArenalService,
        public matDialog: MatDialog) {

    }

    // Life Cicle
    ngAfterViewInit(): void {

        this.SetupMyTableSettings();

        // If the user changes the sort order, reset back to the first page.
        this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);

        this.page =
        {
          Index: 0,
          Size: this.paginator.pageSize,
          Length: 0
        };

        this.FindPaginatedArenal();
    }

    // Get Data from Service
    public async FindPaginatedArenal() {

        const view = await this.arenalService.FindPaginatedArenal(this.page);

        this.ELEMENT_DATA = Array.from(new Set(this.ELEMENT_DATA.concat(view.Items)));

        this.page.Length = view.Length;

        this.dataSource.data = this.ELEMENT_DATA;
    }

    // Setup Table Settings
    public SetupMyTableSettings() {
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
    }

    // Filter Data
    public ApplyMyFilter(target: EventTarget | null) {
        this.dataSource.filter = (target as HTMLInputElement).value.trim().toLowerCase();
    }

    // Get Record from Table
    public GetRecord(row: ViewArenal) {
        const dialogRef = this.matDialog.open(ArenalUpdateModalComponent, {
            width: '450px',
            data: row
        });

        dialogRef.afterClosed().subscribe(() => {
            this.FindPaginatedArenal();
        });
    }

    public AddRecord() {
        const dialogRef = this.matDialog.open(ArenalAddModalComponent, {
            width: '450px',
        });

        dialogRef.afterClosed().subscribe(() => {
            this.FindPaginatedArenal();
        });
    }

    public async TurnThePage(event: PageEvent) {
        this.page =
        {
            Index: event.pageIndex,
            Size: event.pageSize,
        };

        await this.FindPaginatedArenal();
    }
}
