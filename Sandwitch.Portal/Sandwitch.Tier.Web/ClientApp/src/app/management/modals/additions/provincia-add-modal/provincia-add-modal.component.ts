import { Component, OnInit } from '@angular/core';
import { MatDialogRef, MatSnackBar } from '@angular/material';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AddProvincia } from './../../../../../viewmodels/additions/addprovincia';

import { ProvinciaService } from './../../../../../services/provincia.service.module';
import { TextAppVariants } from './../../../../../variants/text.app.variants';
import { TimeAppVariants } from './../../../../../variants/time.app.variants';

@Component({
  selector: 'app-provincia-add-modal',
  templateUrl: './provincia-add-modal.component.html',
  styleUrls: ['./provincia-add-modal.component.css']
})
export class ProvinciaAddModalComponent implements OnInit {

  public formGroup: FormGroup;

  // Constructor
  constructor(private provinciaService: ProvinciaService,
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
      'Name': ['', [Validators.required]],
      'ImageUri': ['', [Validators.required]],
    });
  }

  // Form Actions
  onSubmit(viewModel: AddProvincia) {
    this.provinciaService.AddProvincia(viewModel).subscribe(provincia => {

      if (provincia !== undefined) {
        this.matSnackBar.open(TextAppVariants.AppSuccessButtonText, TextAppVariants.AppOkButtonText, { duration: TimeAppVariants.AppToastSecondTicks * TimeAppVariants.AppTimeSecondTicks });
      }

      this.dialogRef.close();
    });
  }
}
