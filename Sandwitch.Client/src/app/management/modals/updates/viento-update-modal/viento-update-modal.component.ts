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

import { ViewViento } from '../../../../../viewmodels/views/viewviento';

import { UpdateViento } from '../../../../../viewmodels/updates/updateviento';

import { VientoService } from '../../../../../services/viento.service';

import { TextAppVariants } from '../../../../../variants/text.app.variants';

import { TimeAppVariants } from '../../../../../variants/time.app.variants';

@Component({
  selector: 'app-viento-update-modal',
  templateUrl: './viento-update-modal.component.html',
  styleUrls: ['./viento-update-modal.component.scss']
})
export class VientoUpdateModalComponent implements OnInit {

  public formGroup!: FormGroup;

  // Constructor
  constructor(
    private vientoService: VientoService,
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<VientoUpdateModalComponent>,
    private matSnackBar: MatSnackBar,
    @Inject(MAT_DIALOG_DATA) public data: ViewViento) { }


  // Life Cicle
  ngOnInit(): void {
    this.CreateForm();
  }

  // Form
  CreateForm(): void {
    this.formGroup = this.formBuilder.group({
      Id: new FormControl<number>(this.data.Id, [Validators.required]),
      Name: new FormControl<string>(this.data.Name, [Validators.required, Validators.pattern(new RegExp(/^[0-9A-Za-zÀ-ÖØ-öø-ÿ .\-`']*$/))]),
      ImageUri: new FormControl<string>(this.data.ImageUri, [Validators.required]),
    });
  }

  // Form Actions
  async onSubmit(viewModel: UpdateViento): Promise<void> {
    let viento = await this.vientoService.UpdateViento(viewModel);

    if (viento) {
      this.matSnackBar.open(
        TextAppVariants.AppOperationSuccessCoreText,
        TextAppVariants.AppOkButtonText,
        { duration: TimeAppVariants.AppToastSecondTicks * TimeAppVariants.AppTimeSecondTicks });
    }

    this.dialogRef.close();

  }

  async onDelete(viewModel: UpdateViento): Promise<void> {
    await this.vientoService.RemoveVientoById(viewModel.Id);

    this.matSnackBar.open(
      TextAppVariants.AppOperationSuccessCoreText,
      TextAppVariants.AppOkButtonText,
      { duration: TimeAppVariants.AppToastSecondTicks * TimeAppVariants.AppTimeSecondTicks });

    this.dialogRef.close();
  }
}
