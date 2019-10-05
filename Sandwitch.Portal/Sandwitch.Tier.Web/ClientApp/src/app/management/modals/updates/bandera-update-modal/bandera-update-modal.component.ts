import {
  Component,
  OnInit,
  Inject
} from '@angular/core';

import {
  MatDialogRef,
  MAT_DIALOG_DATA,
  MatSnackBar
} from '@angular/material';

import {
  FormBuilder,
  FormGroup,
  Validators
} from '@angular/forms';

import { ViewBandera } from './../../../../../viewmodels/views/viewbandera';

import { UpdateBandera } from './../../../../../viewmodels/updates/updatebandera';

import { BanderaService } from './../../../../../services/bandera.service';

import { TextAppVariants } from './../../../../../variants/text.app.variants';

import { TimeAppVariants } from './../../../../../variants/time.app.variants';

@Component({
  selector: 'app-bandera-update-modal',
  templateUrl: './bandera-update-modal.component.html',
  styleUrls: ['./bandera-update-modal.component.css']
})
export class BanderaUpdateModalComponent implements OnInit {

  public formGroup: FormGroup;

  // Constructor
  constructor(
    private banderaService: BanderaService,
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<BanderaUpdateModalComponent>,
    private matSnackBar: MatSnackBar,
    @Inject(MAT_DIALOG_DATA) public data: ViewBandera) { }


  // Life Cicle
  ngOnInit() {
    this.CreateForm();
  }

  // Form
  CreateForm() {
    this.formGroup = this.formBuilder.group({
      Id: [this.data.Id, [Validators.required]],
      Name: [this.data.Name, [Validators.required]],
      ImageUri: [this.data.ImageUri, [Validators.required]],
    });
  }

  // Form Actions
  onSubmit(viewModel: UpdateBandera) {
    this.banderaService.UpdateBandera(viewModel).subscribe(bandera => {

      if (bandera !== undefined) {
        this.matSnackBar.open(
          TextAppVariants.AppOperationSuccessCoreText,
          TextAppVariants.AppOkButtonText,
          { duration: TimeAppVariants.AppToastSecondTicks * TimeAppVariants.AppTimeSecondTicks });
      }

      this.dialogRef.close();
    });
  }

  onDelete(viewModel: UpdateBandera) {
    this.banderaService.RemoveBanderaById(viewModel.Id).subscribe(bandera => {

      this.matSnackBar.open(
        TextAppVariants.AppOperationSuccessCoreText,
        TextAppVariants.AppOkButtonText,
        { duration: TimeAppVariants.AppToastSecondTicks * TimeAppVariants.AppTimeSecondTicks });

      this.dialogRef.close();
    });
  }
}
