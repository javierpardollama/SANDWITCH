import { Component, OnInit } from '@angular/core';
import { MatDialogRef, MatSnackBar } from '@angular/material';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ViewProvincia } from '../../../../../viewmodels/views/viewprovincia';

import { AddArenal } from '../../../../../viewmodels/additions/addarenal';

import { ArenalService } from '../../../../../services/arenal.service.module';
import { ProvinciaService } from '../../../../../services/provincia.service.module';
import { AppConstants } from '../../../../app.constants';

@Component({
  selector: 'app-arenal-add-modal',
  templateUrl: './arenal-add-modal.component.html',
  styleUrls: ['./arenal-add-modal.component.css']
})
export class ArenalAddModalComponent implements OnInit {

  public formGroup: FormGroup;

  public provincias: ViewProvincia[];

  // Constructor
  constructor(private arenalService: ArenalService,
    private provinciaService: ProvinciaService,
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<ArenalAddModalComponent>,
    private matSnackBar: MatSnackBar) { }


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

      if (arenal !== undefined) {
        this.matSnackBar.open(AppConstants.AppSuccessButtonText, AppConstants.AppOkButtonText, { duration: AppConstants.AppToastSecondTicks * AppConstants.AppTimeSecondTicks });
      }

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
