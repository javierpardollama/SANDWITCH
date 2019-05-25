import { Component, OnInit } from '@angular/core';
import { MatDialogRef, MatSnackBar } from '@angular/material';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AddBandera } from '../../../../../viewmodels/additions/addbandera';

import { BanderaService } from '../../../../../services/bandera.service.module';

@Component({
  selector: 'app-bandera-add-modal',
  templateUrl: './bandera-add-modal.component.html',
  styleUrls: ['./bandera-add-modal.component.css']
})
export class BanderaAddModalComponent implements OnInit {

  public formGroup: FormGroup;

  // Constructor
  constructor(private banderaService: BanderaService,
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
      'Name': ['', [Validators.required]],
      'ImageUri': ['', [Validators.required]],
    });
  }

  // Form Actions
  onSubmit(viewModel: AddBandera) {
    this.banderaService.AddBandera(viewModel).subscribe(bandera => {

      if (bandera.Id !== undefined) {
        this.matSnackBar.open('Operation Successful', 'Ok');
      }

      this.dialogRef.close();
    });
  }
}
