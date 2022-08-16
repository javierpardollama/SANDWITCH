import {
  Component,
  OnInit,
  Inject
} from '@angular/core';

import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';

import {
  FormBuilder,
  FormGroup,
  Validators
} from '@angular/forms';

import { ViewProvincia } from './../../../../../viewmodels/views/viewprovincia';

import { UpdateProvincia } from './../../../../../viewmodels/updates/updateprovincia';

import { ProvinciaService } from './../../../../../services/provincia.service';

import { TextAppVariants } from './../../../../../variants/text.app.variants';

import { TimeAppVariants } from './../../../../../variants/time.app.variants';

@Component({
  selector: 'app-provincia-update-modal',
  templateUrl: './provincia-update-modal.component.html',
  styleUrls: ['./provincia-update-modal.component.scss']
})
export class ProvinciaUpdateModalComponent implements OnInit {

  public formGroup!: FormGroup;

  // Constructor
  constructor(
    private provinciaService: ProvinciaService,
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<ProvinciaUpdateModalComponent>,
    private matSnackBar: MatSnackBar,
    @Inject(MAT_DIALOG_DATA) public data: ViewProvincia) { }


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
  async onSubmit(viewModel: UpdateProvincia) {
    let provincia = await this.provinciaService.UpdateProvincia(viewModel)

    if (provincia) {
      this.matSnackBar.open(
        TextAppVariants.AppOperationSuccessCoreText,
        TextAppVariants.AppOkButtonText,
        { duration: TimeAppVariants.AppToastSecondTicks * TimeAppVariants.AppTimeSecondTicks });
    }

    this.dialogRef.close();
  }

  async onDelete(viewModel: UpdateProvincia) {
    await this.provinciaService.RemoveProvinciaById(viewModel.Id);
    
    this.matSnackBar.open(
      TextAppVariants.AppOperationSuccessCoreText,
      TextAppVariants.AppOkButtonText,
      { duration: TimeAppVariants.AppToastSecondTicks * TimeAppVariants.AppTimeSecondTicks }
    );

    this.dialogRef.close();
  }
}
