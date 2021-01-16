import {
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


@Component({
    selector: 'app-arenal-grid',
    templateUrl: './arenal-grid.component.html',
    styleUrls: ['./arenal-grid.component.scss']
})
export class ArenalGridComponent implements OnInit {

    @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
    @ViewChild(MatSort, { static: true }) sort: MatSort;

    public ELEMENT_DATA: ViewArenal[];

    public displayedColumns: string[] = ['Id', 'Name', 'Poblaciones', 'LastModified'];

    public dataSource: MatTableDataSource<ViewArenal>;

    // Constructor
    constructor(
        private arenalService: ArenalService,
        public matDialog: MatDialog) {

    }

    // Life Cicle
    ngOnInit() {
        this.FindAllArenal();
    }

    // Get Data from Service
    public async FindAllArenal() {
        this.ELEMENT_DATA = await this.arenalService.FindAllArenal();

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
            this.FindAllArenal();
        });
    }

    public AddRecord() {
        const dialogRef = this.matDialog.open(ArenalAddModalComponent, {
            width: '450px',
        });

        dialogRef.afterClosed().subscribe(result => {
            this.FindAllArenal();
        });
    }
}
