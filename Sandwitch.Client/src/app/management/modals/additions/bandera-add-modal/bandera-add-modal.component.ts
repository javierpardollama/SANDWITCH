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

  public formGroup!: FormGroup;

  // Constructor
  constructor(
    private banderaService: BanderaService,
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<BanderaAddModalComponent>,
    private matSnackBar: MatSnackBar) { }


  // Life Cicle
  ngOnInit(): void {
    this.CreateForm();
  }

  // Form
  CreateForm(): void {
    this.formGroup = this.formBuilder.group({
      Name: new FormControl<string>(TextAppVariants.AppEmptyCoreText,
        [Validators.required]),
      ImageUri: new FormControl<string>(TextAppVariants.AppEmptyCoreText,
        [Validators.required]),
    });
  }

  // Form Actions
  async onSubmit(viewModel: AddBandera): Promise<void> {
    let bandera = await this.banderaService.AddBandera(viewModel);

    if (bandera) {
      this.matSnackBar.open(
        TextAppVariants.AppOperationSuccessCoreText,
        TextAppVariants.AppOkButtonText,
        { duration: TimeAppVariants.AppToastSecondTicks * TimeAppVariants.AppTimeSecondTicks });
    }

    this.dialogRef.close();
  }
}
