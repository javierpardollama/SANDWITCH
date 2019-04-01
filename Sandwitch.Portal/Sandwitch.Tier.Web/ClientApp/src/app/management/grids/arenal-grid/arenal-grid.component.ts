import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatPaginator, MatSort, MatDialog } from '@angular/material';
import { Arenal } from '../../../../viewmodels/core/arenal';

import { ArenalService } from '../../../../services/arenal.service.module';

import { ArenalUpdateModalComponent } from '../../modals/updates/arenal-update-modal/arenal-update-modal.component';
import { ArenalAddModalComponent } from '../../modals/additions/arenal-add-modal/arenal-add-modal.component';


@Component({
    selector: 'app-arenal-grid',
    templateUrl: './arenal-grid.component.html',
    styleUrls: ['./arenal-grid.component.css']
})
export class ArenalGridComponent implements OnInit {

    @ViewChild(MatPaginator) paginator: MatPaginator;
    @ViewChild(MatSort) sort: MatSort;

    public ELEMENT_DATA: Arenal[];

    public displayedColumns: string[] = ['Id', 'Name', 'Poblaciones', 'LastModified'];

    public dataSource: MatTableDataSource<Arenal>;

    // Constructor
    constructor(private arenalService: ArenalService,
        public matDialog: MatDialog) {

    }

    // Life Cicle
    ngOnInit() {
        this.FindAllArenal();
    }

    // Get Data from Service
    public FindAllArenal() {
        this.arenalService.FindAllArenal().subscribe(arenales => {
            this.ELEMENT_DATA = arenales;

            this.SetupMyTableSettings();
        });
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
    public GetRecord(row: Arenal) {
        const dialogRef = this.matDialog.open(ArenalUpdateModalComponent, {
            width: '250px',
            data: row
        });

        dialogRef.afterClosed().subscribe(result => {
            this.FindAllArenal();
        });
    }

    public AddRecord() {
        const dialogRef = this.matDialog.open(ArenalAddModalComponent, {
            width: '250px',
        });

        dialogRef.afterClosed().subscribe(result => {
            this.FindAllArenal();
        });
    }
}
