import { ChangeDetectionStrategy, Component, OnInit, computed, inject, signal } from '@angular/core';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';

import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';

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
import { toSignal } from '@angular/core/rxjs-interop';


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

  // Signals for state
  loading = signal(false);
  finders = signal<ViewFinder[]>([]);
  beaches = signal<ViewBeach[]>([]);

  buscadorCtrl = new FormControl<string | ViewFinder>('', { nonNullable: true });

  // Convert the control stream to a signal
  query = toSignal(
    this.buscadorCtrl.valueChanges.pipe(
      startWith<string | ViewFinder>(''),
      map(v => (typeof v === 'string' ? v : v?.Name ?? ''))
    ),
    { initialValue: '' }
  );

  // Derived signal for filtered list
  filteredFinders = computed(() => {
    const list = this.finders();
    const term = this.query().toLowerCase().trim();
    return term ? list.filter(f => f.Name?.toLowerCase().includes(term)) : list;
  });

  // Constructor
  constructor() {

  }

  // Life Cicle
  async ngOnInit(): Promise<void> {
    await this.FindAllFinder();
  }

  // Get Data from Service
  public async FindAllBeachByFinderId(option: MatOption<ViewFinder>): Promise<void> {
    this.loading.set(true);
    const finder: FinderBeach = { Id: option.value.Id, Group: option.value.Group };
    const beaches = await this.finderService.FindAllBeachByFinderId(finder);
    this.beaches.set(beaches);
    this.loading.set(false);
  }

  public async FindAllFinder(): Promise<void> {
    this.loading.set(true);
    const finders = await this.finderService.FindAllFinder();
    this.finders.set(finders);
    this.loading.set(false);
  }

  // Display Option Name
  public displayFn(buscador: ViewFinder): string {
    return buscador ? buscador.Name : '';
  }

  // Get Record from Card
  public GetRecord(row: ViewBeach): void {
    const dialogRef = this.matDialog.open(HistoricAddModalComponent, {
      width: '680px',
      data: row
    });

    dialogRef.afterClosed().subscribe(() => {

    });
  }
}
