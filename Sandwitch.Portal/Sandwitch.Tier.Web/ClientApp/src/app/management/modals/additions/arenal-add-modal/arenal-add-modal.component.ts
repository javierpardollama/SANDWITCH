import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Provincia } from '../../../../../viewmodels/core/provincia';

import { AddArenal } from '../../../../../viewmodels/additions/addarenal';

import { ArenalService } from '../../../../../services/arenal.service.module';
import { ProvinciaService } from '../../../../../services/provincia.service.module';

@Component({
  selector: 'app-arenal-add-modal',
  templateUrl: './arenal-add-modal.component.html',
  styleUrls: ['./arenal-add-modal.component.css']
})
export class ArenalAddModalComponent implements OnInit {

  public formGroup: FormGroup;

  public provincias: Provincia[];

  // Constructor
  constructor(private arenalService: ArenalService,
    private provinciaService: ProvinciaService,
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<ArenalAddModalComponent>) { }


  // Life Cicle
  ngOnInit() {
    this.FindAllProvincia();
    this.CreateForm();
  }

  // Form
  CreateForm() {
    this.formGroup = this.formBuilder.group({
      'Name': ['', [Validators.required]],
      'PoblacionesId': [undefined, [Validators.required]]
    });
  }

  // Form Actions
  onSubmit(viewModel: AddArenal) {
    this.arenalService.AddArenal(viewModel).subscribe(arenal => {
      this.dialogRef.close();
    });
  }

  // Get Data from Service
  public FindAllProvincia() {
    this.provinciaService.FindAllProvincia().subscribe(provincias => {
      this.provincias = provincias;
    });
  }
}
