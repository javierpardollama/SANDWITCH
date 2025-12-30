import { ChangeDetectionStrategy, Component, OnInit, inject } from '@angular/core';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';

import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';

import { Observable, of } from 'rxjs';

import {
  map,
  startWith
} from 'rxjs/operators';

import { ViewFinder } from "../../viewmodels/views/viewfinder";
import { FinderService } from "../../services/finder.service";
import { FinderBeach } from "../../viewmodels/finders/finderbeach";
import { ViewBeach } from '../../viewmodels/views/viewbeach';

import {
  HistoricAddModalComponent
} from '../management/modals/additions/historico-add-modal/historic-add-modal.component';
import { MatAutocompleteModule, MatOption } from '@angular/material/autocomplete';
import { MatCardModule } from '@angular/material/card';
import { MatDividerModule } from '@angular/material/divider';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { CommonModule, NgOptimizedImage } from '@angular/common';


@Component({
  changeDetection: ChangeDetectionStrategy.OnPush,
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss'],
  imports: [
    MatDividerModule,
    MatSelectModule,
    MatInputModule,
    MatDialogModule,
    MatAutocompleteModule,
    MatCardModule,
    MatFormFieldModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgOptimizedImage
  ]
})
export class SearchComponent implements OnInit {
  // DI
  matDialog = inject(MatDialog);
  private finderService = inject(FinderService);

  public loading: boolean = false;

  // Data
  public finders: ViewFinder[] = [];
  public filteredFinders: Observable<ViewFinder[]> = of([]);
  public beaches: ViewBeach[] = [];

  // Control
  public buscadorCtrl = new FormControl();

  // Constructor
  constructor() {

  }

  // Life Cicle
  async ngOnInit(): Promise<void> {
    await this.FindAllFinder();
  }

  // Get Data from Service
  public async FindAllBeachByFinderId(option: MatOption<ViewFinder>): Promise<void> {
    const finder: FinderBeach =
    {
      Id: option.value.Id,
      Group: option.value.Group
    };

    this.loading = true;
    this.beaches = await this.finderService.FindAllBeachByFinderId(finder);
    this.loading = false;
  }

  // Get Data from Service
  public async FindAllFinder(): Promise<void> {
    this.loading = true;
    this.finders = await this.finderService.FindAllFinder();
    this.loading = false;

    this.filteredFinders = this.buscadorCtrl.valueChanges
      .pipe(
        startWith(''),
        map(buscador => buscador ? this.FilterFinders(buscador.Name) : this.finders.slice())
      );
  }


  // Filter Data
  public FilterFinders(value: string): ViewFinder[] {
    const filterValue = value.toLowerCase();

    return this.finders.filter(finder => finder.Name.toLowerCase().indexOf(filterValue) === 0);
  }

  // Display Option Name
  public displayFn(buscador: ViewFinder): string {
    return buscador ? buscador.Name : '';
  }

  // Get Record from Card
  public GetRecord(row: ViewBeach): void {
    const dialogRef = this.matDialog.open(HistoricAddModalComponent, {
      width: '600px',
      data: row
    });

    dialogRef.afterClosed().subscribe(() => {

    });
  }
}
