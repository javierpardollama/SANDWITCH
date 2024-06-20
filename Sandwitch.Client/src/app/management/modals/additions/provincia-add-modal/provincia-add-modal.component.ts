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

import { AddProvincia } from './../../../../../viewmodels/additions/addprovincia';

import { ProvinciaService } from './../../../../../services/provincia.service';

import { TextAppVariants } from './../../../../../variants/text.app.variants';

import { TimeAppVariants } from './../../../../../variants/time.app.variants';

import { ExpressionAppVariants } from './../../../../../variants/expression.app.variants';

@Component({
  selector: 'app-provincia-add-modal',
  templateUrl: './provincia-add-modal.component.html',
  styleUrls: ['./provincia-add-modal.component.scss']
})
export class ProvinciaAddModalComponent implements OnInit {

  public formGroup!: FormGroup;

  // Constructor
  constructor(
    private provinciaService: ProvinciaService,
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<ProvinciaAddModalComponent>,
    private matSnackBar: MatSnackBar) { }


  // Life Cicle
  ngOnInit(): void {
    this.CreateForm();
  }

  // Form
  CreateForm(): void {
    this.formGroup = this.formBuilder.group({
      Name: new FormControl<string>(TextAppVariants.AppEmptyCoreText,
        [
          Validators.required,
          Validators.pattern(new RegExp(ExpressionAppVariants.AppPoorInputValidationExpression))
        ]),
      ImageUri: new FormControl<string>(TextAppVariants.AppEmptyCoreText, [Validators.required]),
    });
  }

  // Form Actions
  async onSubmit(viewModel: AddProvincia): Promise<void> {
    let provincia = await this.provinciaService.AddProvincia(viewModel);

    if (provincia) {
      this.matSnackBar.open(
        TextAppVariants.AppOperationSuccessCoreText,
        TextAppVariants.AppOkButtonText,
        { duration: TimeAppVariants.AppToastSecondTicks * TimeAppVariants.AppTimeSecondTicks });
    }

    this.dialogRef.close();
  }
}
