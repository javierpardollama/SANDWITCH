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

import { AddArenal } from './../../../../../viewmodels/additions/addarenal';

import { ArenalService } from './../../../../../services/arenal.service';

import { ProvinciaService } from './../../../../../services/provincia.service';

import { TextAppVariants } from '../../../../../variants/text.app.variants';

import { TimeAppVariants } from '../../../../../variants/time.app.variants';

import { ExpressionAppVariants } from '../../../../../variants/expression.app.variants';

@Component({
  selector: 'app-arenal-add-modal',
  templateUrl: './arenal-add-modal.component.html',
  styleUrls: ['./arenal-add-modal.component.scss']
})
export class ArenalAddModalComponent implements OnInit {

  public formGroup!: FormGroup;

  public provincias: ViewProvincia[] = [];

  // Constructor
  constructor(
    private arenalService: ArenalService,
    private provinciaService: ProvinciaService,
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<ArenalAddModalComponent>,
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
      PoblacionesId: new FormControl<number[]>([], [Validators.required])
    });
  }

  // Form Actions
  async onSubmit(viewModel: AddArenal): Promise<void> {
    let arenal = await this.arenalService.AddArenal(viewModel);

    if (arenal) {
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
