import { AfterViewInit, ChangeDetectionStrategy, Component, OnDestroy, OnInit, inject } from '@angular/core';

import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';

import { ViewBeach } from '../../../../viewmodels/views/viewbeach';

import { BeachService } from '../../../../services/beach.service';

import {
    BeachUpdateModalComponent
} from '../../modals/updates/beach-update-modal/beach-update-modal.component';

import {
    BeachAddModalComponent
} from '../../modals/additions/beach-add-modal/beach-add-modal.component';

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
    selector: 'app-beach-grid',
    templateUrl: './beach-grid.component.html',
    styleUrls: ['./beach-grid.component.scss'],
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
export class BeachGridComponent implements OnInit, AfterViewInit, OnDestroy {
    // DI
    private beachService = inject(BeachService);
    matDialog = inject(MatDialog);

    public loading: boolean = false;

    public ELEMENT_DATA: ViewBeach[] = [];

    public displayedColumns: string[] = ['Id', 'Name', 'Towns', 'LastModified'];

    public dataSource: MatTableDataSource<ViewBeach> = new MatTableDataSource<ViewBeach>();

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
        await this.FindPaginatedBeach();
    }

    ngOnDestroy(): void {
        window.removeEventListener('scroll', this.TurnThePage, true);
    }

    // Get Data from Service
    public async FindPaginatedBeach(): Promise<void> {
        this.loading = true;
        const view = await this.beachService.FindPaginatedBeach(this.page);
        this.loading = false;

        if (view) {
            this.page.Length = view.Length;
            this.ELEMENT_DATA = Array.from(this.ELEMENT_DATA.concat(view.Items).reduce((m, t): Map<ViewBeach, ViewBeach> => m.set(t.Id, t), new Map()).values());
            this.dataSource.data = this.ELEMENT_DATA;
        }
    }

    // Filter Data
    public ApplyMyFilter(target: EventTarget | null): void {
        this.dataSource.filter = (target as HTMLInputElement).value.trim().toLowerCase();
    }

    // Get Record from Table
    public GetRecord(row: ViewBeach): void {
        const dialogRef = this.matDialog.open(BeachUpdateModalComponent, {
            width: '450px',
            data: row
        });

        dialogRef.afterClosed().subscribe(async () => {
            await this.FindPaginatedBeach();
        });
    }

    public AddRecord(): void {
        const dialogRef = this.matDialog.open(BeachAddModalComponent, {
            width: '450px',
        });

        dialogRef.afterClosed().subscribe(async () => {
            await this.FindPaginatedBeach();
        });
    }


    private TurnThePage = async (event: Event): Promise<void> => {

        let scroll: ViewScroll = new ViewScroll(event.target as HTMLElement, this.page.Size, this.ELEMENT_DATA.length, this.page.Length);

        if (scroll.IsReached()) {
            this.page.Index++;
            await this.FindPaginatedBeach();
        }
    }
}
