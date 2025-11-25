import {
  Component,
  OnInit
} from '@angular/core';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';

import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';

import { Observable, of } from 'rxjs';

import {
  map,
  startWith
} from 'rxjs/operators';

import { ViewBuscador } from "../../viewmodels/views/viewbuscador";
import { BuscadorService } from "../../services/buscador.service";
import { FinderArenal } from "../../viewmodels/finders/finderarenal";
import { ViewArenal } from '../../viewmodels/views/viewarenal';

import {
  HistoricoAddModalComponent
} from '../management/modals/additions/historico-add-modal/historico-add-modal.component';
import { MatAutocompleteModule, MatOption } from '@angular/material/autocomplete';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatChipsModule } from '@angular/material/chips';
import { MatDividerModule } from '@angular/material/divider';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSelectModule } from '@angular/material/select';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { CommonModule, NgOptimizedImage } from '@angular/common';


@Component({
    selector: 'app-search',
    templateUrl: './search.component.html',
    styleUrls: ['./search.component.scss'],
    imports: [
        MatDividerModule,
        MatSelectModule,
        MatInputModule,
        MatDialogModule,
        MatPaginatorModule,
        MatButtonModule,
        MatSnackBarModule,
        MatChipsModule,
        MatAutocompleteModule,
        MatCardModule,
        MatTableModule,
        MatSortModule,
        MatFormFieldModule,
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        NgOptimizedImage
    ]
})
export class SearchComponent implements OnInit {

  // Data
  public buscadores : ViewBuscador[] = [];
  public filteredBuscadores: Observable<ViewBuscador[]> = of([]);
  public arenales: ViewArenal[] = [];

  // Control
  public buscadorCtrl = new FormControl();

  // Constructor
  constructor(
    public matDialog: MatDialog,
    private buscadorService: BuscadorService
    ) {

  }

  // Life Cicle
  async ngOnInit(): Promise<void> {
    await this.FindAllBuscador();
  }

  // Get Data from Service
  public async FindAllArenalByBuscadorId(option: MatOption<ViewBuscador>): Promise<void> {
      const finder: FinderArenal =
          {
              Id: option.value.Id,
              Group: option.value.Group
          };

      this.arenales = await this.buscadorService.FindAllArenalByBuscadorId(finder);
  }

  // Get Data from Service
  public async FindAllBuscador(): Promise<void> {
    this.buscadores = await this.buscadorService.FindAllBuscador();

    this.filteredBuscadores = this.buscadorCtrl.valueChanges
      .pipe(
        startWith(''),
        map(buscador => buscador ? this.FilterBuscadores(buscador.Name) : this.buscadores.slice())
      );
  }


  // Filter Data
  public FilterBuscadores(value: string): ViewBuscador[] {
    const filterValue = value.toLowerCase();

    return this.buscadores.filter(buscador => buscador.Name.toLowerCase().indexOf(filterValue) === 0);
  }

  // Display Option Name
  public displayFn(buscador: ViewBuscador): string {
        return buscador ? buscador.Name : '';
  }

  // Get Record from Card
  public GetRecord(row: ViewArenal): void {
    const dialogRef = this.matDialog.open(HistoricoAddModalComponent, {
      width: '600px',
      data: row
    });

    dialogRef.afterClosed().subscribe(() => {

    });
  }
}
