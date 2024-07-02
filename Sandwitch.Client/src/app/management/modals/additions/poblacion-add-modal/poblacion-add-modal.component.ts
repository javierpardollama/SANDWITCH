import {
  Component,
  OnInit
} from '@angular/core';

import { MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';

import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators
} from '@angular/forms';

import { ViewProvincia } from './../../../../../viewmodels/views/viewprovincia';

import { AddPoblacion } from './../../../../../viewmodels/additions/addpoblacion';

import { ProvinciaService } from './../../../../../services/provincia.service';

import { PoblacionService } from './../../../../../services/poblacion.service';

import { TextAppVariants } from './../../../../../variants/text.app.variants';

import { TimeAppVariants } from './../../../../../variants/time.app.variants';

import { ExpressionAppVariants } from './../../../../../variants/expression.app.variants';

@Component({
  selector: 'app-poblacion-add-modal',
  templateUrl: './poblacion-add-modal.component.html',
  styleUrls: ['./poblacion-add-modal.component.scss']
})
export class PoblacionAddModalComponent implements OnInit {

  public formGroup!: FormGroup;

  public provincias: ViewProvincia[] = [];

  // Constructor
  constructor(
    private provinciaService: ProvinciaService,
    private poblacionService: PoblacionService,
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<PoblacionAddModalComponent>,
    private matSnackBar: MatSnackBar) { }


  // Life Cicle
  ngOnInit(): void {
    this.FindAllProvincia();
    this.CreateForm();
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
