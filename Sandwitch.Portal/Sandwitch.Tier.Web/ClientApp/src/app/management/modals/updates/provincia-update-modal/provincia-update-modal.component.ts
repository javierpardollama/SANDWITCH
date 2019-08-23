import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA, MatSnackBar } from '@angular/material';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ViewProvincia } from './../../../../../viewmodels/views/viewprovincia';
import { UpdateProvincia } from './../../../../../viewmodels/updates/updateprovincia';

import { ProvinciaService } from './../../../../../services/provincia.service';
import { TextAppVariants } from './../../../../../variants/text.app.variants';
import { TimeAppVariants } from './../../../../../variants/time.app.variants';

@Component({
  selector: 'app-provincia-update-modal',
  templateUrl: './provincia-update-modal.component.html',
  styleUrls: ['./provincia-update-modal.component.css']
})
export class ProvinciaUpdateModalComponent implements OnInit {

  public formGroup: FormGroup;

  // Constructor
  constructor(private provinciaService: ProvinciaService,
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
      'Id': [this.data.Id, [Validators.required]],
      'Name': [this.data.Name, [Validators.required]],
      'ImageUri': [this.data.ImageUri, [Validators.required]],
    });
  }

  // Form Actions
  onSubmit(viewModel: UpdateProvincia) {
    this.provinciaService.UpdateProvincia(viewModel).subscribe(provincia => {

      if (provincia !== undefined) {
        this.matSnackBar.open(TextAppVariants.AppSuccessButtonText, TextAppVariants.AppOkButtonText, { duration: TimeAppVariants.AppToastSecondTicks * TimeAppVariants.AppTimeSecondTicks });
      }

      this.dialogRef.close();
    });
  }

  onDelete(viewModel: UpdateProvincia) {
    this.provinciaService.RemoveProvinciaById(viewModel.Id).subscribe(provincia => {
      this.matSnackBar.open(TextAppVariants.AppSuccessButtonText, TextAppVariants.AppOkButtonText, { duration: TimeAppVariants.AppToastSecondTicks * TimeAppVariants.AppTimeSecondTicks });

      this.dialogRef.close();
    });
  }
}
