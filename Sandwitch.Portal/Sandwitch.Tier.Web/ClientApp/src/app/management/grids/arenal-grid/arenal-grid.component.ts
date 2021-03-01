import {
    AfterViewInit,
    Component,
    ViewChild
} from '@angular/core';

import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
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
import { PageBase } from 'src/viewmodels/pagination/pagebase';
import { merge } from 'rxjs';


@Component({
    selector: 'app-arenal-grid',
    templateUrl: './arenal-grid.component.html',
    styleUrls: ['./arenal-grid.component.scss']
})
export class ArenalGridComponent implements AfterViewInit {

    @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
    @ViewChild(MatSort, { static: true }) sort: MatSort;

    public ELEMENT_DATA: ViewArenal[];

    public displayedColumns: string[] = ['Id', 'Name', 'Poblaciones', 'LastModified'];

    public dataSource: MatTableDataSource<ViewArenal>;

    public page: PageBase =
        {
            Skip: 0,
            Take: 10
        };

    // Constructor
    constructor(
        private arenalService: ArenalService,
        public matDialog: MatDialog) {

    }

    // Life Cicle
    ngAfterViewInit(): void {

        // If the user changes the sort order, reset back to the first page.
        this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);

        this.page =
        {
            Skip: 0,
            Take: (this.paginator.pageSize + 2)
        };

        this.FindPaginatedArenal();

        this.TriggerPagination();
    }

    // Get Data from Service
    public async FindPaginatedArenal() {
        this.ELEMENT_DATA = await this.arenalService.FindPaginatedArenal(this.page);

        this.SetupMyTableSettings();
    }

    // Setup Table Settings
    public SetupMyTableSettings() {
        this.dataSource = new MatTableDataSource(this.ELEMENT_DATA);

        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
    }

    // Filter Data
    public ApplyMyFilter(filterValue: string) {
        this.dataSource.filter = filterValue.trim().toLowerCase();
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

    public TriggerPagination() {

        merge(this.paginator.page).pipe().subscribe(() => {

            this.page =
            {
                Skip: 0,
                Take: this.paginator.pageSize * (this.paginator.pageIndex + 2)
            };

            this.FindPaginatedArenal();
        });
    }
}
