import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AddProvincia } from '../../../../../viewmodels/additions/addprovincia';

import { ProvinciaService } from '../../../../../services/provincia.service.module';

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
    public dialogRef: MatDialogRef<ProvinciaAddModalComponent>) { }


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
      this.dialogRef.close();
    });
  }
}
