import {
  Component,
  OnInit,
  Inject
} from '@angular/core';

import { MatDialogRef, MAT_DIALOG_DATA, MatDialogModule } from '@angular/material/dialog';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';

import {
  FormBuilder,
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators
} from '@angular/forms';

import { ViewArenal } from './../../../../../viewmodels/views/viewarenal';

import { ViewProvincia } from './../../../../../viewmodels/views/viewprovincia';

import { UpdateArenal } from './../../../../../viewmodels/updates/updatearenal';

import { ArenalService } from './../../../../../services/arenal.service';

import { ProvinciaService } from './../../../../../services/provincia.service';

import { TextAppVariants } from './../../../../../variants/text.app.variants';

import { TimeAppVariants } from './../../../../../variants/time.app.variants';

import { ExpressionAppVariants } from './../../../../../variants/expression.app.variants';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatChipsModule } from '@angular/material/chips';
import { MatDividerModule } from '@angular/material/divider';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSelectModule } from '@angular/material/select';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { NgOptimizedImage } from '@angular/common';

@Component({
    selector: 'app-arenal-update-modal',
    templateUrl: './arenal-update-modal.component.html',
    styleUrls: ['./arenal-update-modal.component.scss'],
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
    FormsModule,
    ReactiveFormsModule,
    NgOptimizedImage
]
})
export class ArenalUpdateModalComponent implements OnInit {

  public formGroup!: FormGroup;

  public provincias: ViewProvincia[] = [];


  // Constructor
  constructor(
    private arenalService: ArenalService,
    private provinciaService: ProvinciaService,
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<ArenalUpdateModalComponent>,
    private matSnackBar: MatSnackBar,
    @Inject(MAT_DIALOG_DATA) public data: ViewArenal) { }


  // Life Cicle
  ngOnInit(): void {
    this.FindAllProvincia();
    this.CreateForm();
  }

  // Form
  CreateForm(): void {
    this.formGroup = this.formBuilder.group({
      Id: new FormControl<number>(this.data.Id, [Validators.required]),
      Name: new FormControl<string>(this.data.Name,
        [
          Validators.required,
          Validators.pattern(new RegExp(ExpressionAppVariants.AppNameExpression))
        ]),
      PoblacionesId: new FormControl<number[]>(this.data.Poblaciones.map(({ Id }) => Id), [Validators.required])
    });
  }

  // Form Actions
  async onSubmit(viewModel: UpdateArenal): Promise<void> {
    let arenal = await this.arenalService.UpdateArenal(viewModel);

    if (arenal) {
      this.matSnackBar.open(
        TextAppVariants.AppOperationSuccessCoreText,
        TextAppVariants.AppOkButtonText,
        { duration: TimeAppVariants.AppToastSecondTicks * TimeAppVariants.AppTimeSecondTicks });
    }

    this.dialogRef.close();
  }

  async onDelete(viewModel: UpdateArenal): Promise<void> {
    await this.arenalService.RemoveArenalById(viewModel.Id);

    this.matSnackBar.open(
      TextAppVariants.AppOperationSuccessCoreText,
      TextAppVariants.AppOkButtonText,
      { duration: TimeAppVariants.AppToastSecondTicks * TimeAppVariants.AppTimeSecondTicks });

    this.dialogRef.close();

  }

  // Get Data from Service
  public async FindAllProvincia(): Promise<void> {
    this.provincias = await this.provinciaService.FindAllProvincia();
  }
}
