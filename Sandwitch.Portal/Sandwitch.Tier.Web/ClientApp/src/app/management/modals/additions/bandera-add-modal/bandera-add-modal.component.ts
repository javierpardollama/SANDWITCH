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

import { AddBandera } from './../../../../../viewmodels/additions/addbandera';

import { BanderaService } from './../../../../../services/bandera.service';

import { TextAppVariants } from './../../../../../variants/text.app.variants';

import { TimeAppVariants } from './../../../../../variants/time.app.variants';

@Component({
  selector: 'app-bandera-add-modal',
  templateUrl: './bandera-add-modal.component.html',
  styleUrls: ['./bandera-add-modal.component.scss']
})
export class BanderaAddModalComponent implements OnInit {

  public formGroup: FormGroup;

  // Constructor
  constructor(
    private banderaService: BanderaService,
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<BanderaAddModalComponent>,
    private matSnackBar: MatSnackBar) { }


  // Life Cicle
  ngOnInit() {
    this.CreateForm();
  }

  // Form
  CreateForm() {
    this.formGroup = this.formBuilder.group({
      Name: [TextAppVariants.AppEmptyCoreText,
      [Validators.required]],
      ImageUri: [TextAppVariants.AppEmptyCoreText,
      [Validators.required]],
    });
  }

  // Form Actions
  async onSubmit(viewModel: AddBandera) {
    let bandera = await this.banderaService.AddBandera(viewModel);
    
    if (bandera !== undefined) {
      this.matSnackBar.open(
        TextAppVariants.AppOperationSuccessCoreText,
        TextAppVariants.AppOkButtonText,
        { duration: TimeAppVariants.AppToastSecondTicks * TimeAppVariants.AppTimeSecondTicks });
    }

    this.dialogRef.close();
  }
}
