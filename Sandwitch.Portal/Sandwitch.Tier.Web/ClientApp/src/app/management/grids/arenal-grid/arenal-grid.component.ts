import {
    AfterViewInit,
    Component,
    OnInit,
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
import { ScrollAppVariants } from 'src/variants/scroll.app.variants';


@Component({
    selector: 'app-arenal-grid',
    templateUrl: './arenal-grid.component.html',
    styleUrls: ['./arenal-grid.component.scss']
})
export class ArenalGridComponent implements OnInit, AfterViewInit {

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
    ngOnInit() {
        window.addEventListener('scroll', this.scrollEvent, true);
    }

    ngAfterViewInit(): void {
        this.FindPaginatedArenal();
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

        dialogRef.afterClosed().subscribe(result => {
            this.FindPaginatedArenal();
        });
    }

    public AddRecord() {
        const dialogRef = this.matDialog.open(ArenalAddModalComponent, {
            width: '450px',
        });

        dialogRef.afterClosed().subscribe(result => {
            this.FindPaginatedArenal();
        });
    }

    private scrollEvent = async (e: any): Promise<void> => {
        const tableViewHeight = e.target.offsetHeight // viewport: container class with 500px
        const tableScrollHeight = e.target.scrollHeight // length of the table
        const scrollLocation = e.target.scrollTop; // how far user scrolled     

        // If the user has scrolled within 200px of the bottom, add more data
        const limit = tableScrollHeight - tableViewHeight - ScrollAppVariants.AppScrollBuffer;

        if (scrollLocation > limit) {

            this.page =
            {
                Skip: this.ELEMENT_DATA.length,
                Take: this.page.Take++
            };

            this.ELEMENT_DATA = this.ELEMENT_DATA.concat(await this.arenalService.FindPaginatedArenal(this.page));

            this.SetupMyTableSettings();
        }
    }
}
