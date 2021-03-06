import {
  Component,
  OnInit
} from '@angular/core';

import { MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';

import {
  FormBuilder,
  FormGroup,
  Validators
} from '@angular/forms';

import { AddProvincia } from './../../../../../viewmodels/additions/addprovincia';

import { ProvinciaService } from './../../../../../services/provincia.service';
import { TextAppVariants } from './../../../../../variants/text.app.variants';
import { TimeAppVariants } from './../../../../../variants/time.app.variants';

@Component({
  selector: 'app-provincia-add-modal',
  templateUrl: './provincia-add-modal.component.html',
  styleUrls: ['./provincia-add-modal.component.scss']
})
export class ProvinciaAddModalComponent implements OnInit {

  public formGroup: FormGroup;

  // Constructor
  constructor(
    private provinciaService: ProvinciaService,
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<ProvinciaAddModalComponent>,
    private matSnackBar: MatSnackBar) { }


  // Life Cicle
  ngOnInit() {
    this.CreateForm();
  }

  // Form
  CreateForm() {
    this.formGroup = this.formBuilder.group({
      Name: [TextAppVariants.AppEmptyCoreText, [Validators.required]],
      ImageUri: [TextAppVariants.AppEmptyCoreText, [Validators.required]],
    });
  }

  // Form Actions
  async onSubmit(viewModel: AddProvincia) {
    let provincia = await this.provinciaService.AddProvincia(viewModel);

    if (provincia !== undefined) {
      this.matSnackBar.open(
        TextAppVariants.AppOperationSuccessCoreText,
        TextAppVariants.AppOkButtonText,
        { duration: TimeAppVariants.AppToastSecondTicks * TimeAppVariants.AppTimeSecondTicks });
    }

    this.dialogRef.close();
  }
}
