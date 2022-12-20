import {
  Component,
  OnInit,
  Inject
} from '@angular/core';

import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';

import {
  FormBuilder,
  FormControl,
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
  styleUrls: ['./bandera-update-modal.component.scss']
})
export class BanderaUpdateModalComponent implements OnInit {

  public formGroup!: FormGroup;

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
      Id: new FormControl<number>(this.data.Id, [Validators.required]),
      Name: new FormControl<string>(this.data.Name, [Validators.required]),
      ImageUri: new FormControl<string>(this.data.ImageUri, [Validators.required]),
    });
  }

  // Form Actions
  async onSubmit(viewModel: UpdateBandera) {
    let bandera = await this.banderaService.UpdateBandera(viewModel);

    if (bandera) {
      this.matSnackBar.open(
        TextAppVariants.AppOperationSuccessCoreText,
        TextAppVariants.AppOkButtonText,
        { duration: TimeAppVariants.AppToastSecondTicks * TimeAppVariants.AppTimeSecondTicks });
    }

    this.dialogRef.close();

  }

  async onDelete(viewModel: UpdateBandera) {
    await this.banderaService.RemoveBanderaById(viewModel.Id);

    this.matSnackBar.open(
      TextAppVariants.AppOperationSuccessCoreText,
      TextAppVariants.AppOkButtonText,
      { duration: TimeAppVariants.AppToastSecondTicks * TimeAppVariants.AppTimeSecondTicks });

    this.dialogRef.close();
  }
}
