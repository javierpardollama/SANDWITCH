import {
    AfterViewInit,
    Component,
    OnInit
} from '@angular/core';

import { MatDialog } from '@angular/material/dialog';
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
export class ArenalGridComponent implements OnInit, AfterViewInit {

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
    constructor(
        private arenalService: ArenalService,
        public matDialog: MatDialog) {
    }

    // Life Cicle
    ngOnInit(): void {
        window.addEventListener('scroll', this.TurnThePage, true);
    }

    ngAfterViewInit(): void {
        this.FindPaginatedArenal();
    }

    // Get Data from Service
    public async FindPaginatedArenal(): Promise<void> {
        const view = await this.arenalService.FindPaginatedArenal(this.page);

        this.page.Length = view.Length;

        this.ELEMENT_DATA = this.ELEMENT_DATA.concat(view.Items);

        this.dataSource.data = this.ELEMENT_DATA;
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

        dialogRef.afterClosed().subscribe(() => {
            this.FindPaginatedArenal();
        });
    }

    public AddRecord(): void {
        const dialogRef = this.matDialog.open(ArenalAddModalComponent, {
            width: '450px',
        });

        dialogRef.afterClosed().subscribe(() => {
            this.FindPaginatedArenal();
        });
    }


    private TurnThePage = async (e: any): Promise<void> => {
        const tableViewHeight = e.target.offsetHeight;
        const tableScrollHeight = e.target.scrollHeight;
        const scrollLocation = e.target.scrollTop;

        const limit = tableScrollHeight - tableViewHeight - this.page.Size;

        if (scrollLocation > limit) {
            this.page.Index++;
            await this.FindPaginatedArenal();
        }
    }
}
