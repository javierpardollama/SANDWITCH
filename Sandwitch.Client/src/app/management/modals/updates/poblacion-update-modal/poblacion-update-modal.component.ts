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

import { ViewProvincia } from '../../../../../viewmodels/views/viewprovincia';

import { ViewPoblacion } from '../../../../../viewmodels/views/viewpoblacion';

import { UpdatePoblacion } from '../../../../../viewmodels/updates/updatepoblacion';

import { ProvinciaService } from '../../../../../services/provincia.service';

import { PoblacionService } from '../../../../../services/poblacion.service';

import { TextAppVariants } from '../../../../../variants/text.app.variants';

import { TimeAppVariants } from '../../../../../variants/time.app.variants';

import { ExpressionAppVariants } from '../../../../../variants/expression.app.variants';
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
import { ViewCatalog } from 'src/viewmodels/views/viewcatalog';

@Component({
    selector: 'app-poblacion-update-modal',
    templateUrl: './poblacion-update-modal.component.html',
    styleUrls: ['./poblacion-update-modal.component.scss'],
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
export class PoblacionUpdateModalComponent implements OnInit {

  public formGroup!: FormGroup;

  public provincias: ViewCatalog[] = [];

  // Constructor
  constructor(
    private provinciaService: ProvinciaService,
    private poblacionService: PoblacionService,
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<PoblacionUpdateModalComponent>,
    private matSnackBar: MatSnackBar,
    @Inject(MAT_DIALOG_DATA) public data: ViewPoblacion) { }


  // Life Cicle
  async ngOnInit(): Promise<void> {
      this.CreateForm();
      await this.FindAllProvincia();
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
      ImageUri: new FormControl<string>(this.data.ImageUri, [Validators.required]),
      ProvinciaId: new FormControl<number>(this.data.Provincia.Id, [Validators.required])
    });
  }

  // Form Actions
  async onSubmit(viewModel: UpdatePoblacion): Promise<void> {
    let poblacion = await this.poblacionService.UpdatePoblacion(viewModel);

    if (poblacion) {
      this.matSnackBar.open(
        TextAppVariants.AppOperationSuccessCoreText,
        TextAppVariants.AppOkButtonText,
        { duration: TimeAppVariants.AppToastSecondTicks * TimeAppVariants.AppTimeSecondTicks });
    }

    this.dialogRef.close();

  }

  async onDelete(viewModel: UpdatePoblacion): Promise<void> {
    await this.poblacionService.RemovePoblacionById(viewModel.Id);

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
