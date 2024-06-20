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

import { AddViento } from '../../../../../viewmodels/additions/addviento';

import { VientoService } from '../../../../../services/viento.service';

import { TextAppVariants } from '../../../../../variants/text.app.variants';

import { TimeAppVariants } from '../../../../../variants/time.app.variants';

@Component({
  selector: 'app-viento-add-modal',
  templateUrl: './viento-add-modal.component.html',
  styleUrls: ['./viento-add-modal.component.scss']
})
export class VientoAddModalComponent implements OnInit {

  public formGroup!: FormGroup;

  // Constructor
  constructor(
    private vientoService: VientoService,
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<VientoAddModalComponent>,
    private matSnackBar: MatSnackBar) { }


  // Life Cicle
  ngOnInit(): void {
    this.CreateForm();
  }

  // Form
  CreateForm(): void {
    this.formGroup = this.formBuilder.group({
      Name: new FormControl<string>(TextAppVariants.AppEmptyCoreText,
        [Validators.required, Validators.pattern(new RegExp(/^[0-9A-Za-zÀ-ÖØ-öø-ÿ .\-`']*$/))]),
      ImageUri: new FormControl<string>(TextAppVariants.AppEmptyCoreText,
        [Validators.required]),
    });
  }

  // Form Actions
  async onSubmit(viewModel: AddViento): Promise<void> {
    let viento = await this.vientoService.AddViento(viewModel);

    if (viento) {
      this.matSnackBar.open(
        TextAppVariants.AppOperationSuccessCoreText,
        TextAppVariants.AppOkButtonText,
        { duration: TimeAppVariants.AppToastSecondTicks * TimeAppVariants.AppTimeSecondTicks });
    }

    this.dialogRef.close();
  }
}
