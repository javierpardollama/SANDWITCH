import { ChangeDetectionStrategy, Component, OnInit, inject } from '@angular/core';

import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';

import {
  FormBuilder,
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators
} from '@angular/forms';


import { AddPoblacion } from '../../../../../viewmodels/additions/addpoblacion';

import { ProvinciaService } from '../../../../../services/provincia.service';

import { PoblacionService } from '../../../../../services/poblacion.service';

import { TextAppVariants } from '../../../../../variants/text.app.variants';

import { TimeAppVariants } from '../../../../../variants/time.app.variants';

import { ExpressionAppVariants } from '../../../../../variants/expression.app.variants';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { NgOptimizedImage } from '@angular/common';
import { ViewCatalog } from 'src/viewmodels/views/viewcatalog';
import { MatTooltipModule } from '@angular/material/tooltip';

@Component({
  changeDetection: ChangeDetectionStrategy.OnPush,
  selector: 'app-poblacion-add-modal',
  templateUrl: './poblacion-add-modal.component.html',
  styleUrls: ['./poblacion-add-modal.component.scss'],
  imports: [
    MatDialogModule,
    MatButtonModule,
    FormsModule,
    MatTooltipModule,
    MatSnackBarModule,
    MatSelectModule,
    MatInputModule,
    MatFormFieldModule,
    ReactiveFormsModule,
    NgOptimizedImage
  ]
})
export class PoblacionAddModalComponent implements OnInit {
  // DI
  private provinciaService = inject(ProvinciaService);
  private poblacionService = inject(PoblacionService);
  private formBuilder = inject(FormBuilder);
  dialogRef = inject<MatDialogRef<PoblacionAddModalComponent>>(MatDialogRef);
  private matSnackBar = inject(MatSnackBar);

  public formGroup!: FormGroup;

  public provincias: ViewCatalog[] = [];

  // Constructor
  constructor() { }


  // Life Cicle
  async ngOnInit(): Promise<void> {
    this.CreateForm();
    await this.FindAllProvincia();
  }

  // Form
  CreateForm(): void {
    this.formGroup = this.formBuilder.group({
      Name: new FormControl<string>(TextAppVariants.AppEmptyCoreText,
        [
          Validators.required,
          Validators.pattern(new RegExp(ExpressionAppVariants.AppNameExpression))
        ]),
      ImageUri: new FormControl<string>(TextAppVariants.AppEmptyCoreText,
        [Validators.required]),
      ProvinciaId: new FormControl<number>(0, [Validators.required])
    });
  }

  // Form Actions
  async onSubmit(viewModel: AddPoblacion): Promise<void> {
    let poblacion = await this.poblacionService.AddPoblacion(viewModel);

    if (poblacion) {
      this.matSnackBar.open(
        TextAppVariants.AppOperationSuccessCoreText,
        TextAppVariants.AppOkButtonText,
        { duration: TimeAppVariants.AppToastSecondTicks * TimeAppVariants.AppTimeSecondTicks });
    }

    this.dialogRef.close();
  }

  // Get Data from Service
  public async FindAllProvincia(): Promise<void> {
    this.provincias = await this.provinciaService.FindAllProvincia();
  }
}
