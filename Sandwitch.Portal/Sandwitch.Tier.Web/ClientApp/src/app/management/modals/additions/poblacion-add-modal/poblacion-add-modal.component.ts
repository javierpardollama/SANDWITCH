import { Component, OnInit } from '@angular/core';
import { MatDialogRef, MatSnackBar } from '@angular/material';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ViewProvincia } from '../../../../../viewmodels/views/viewprovincia';

import { AddPoblacion } from '../../../../../viewmodels/additions/addpoblacion';

import { ProvinciaService } from '../../../../../services/provincia.service.module';
import { PoblacionService } from '../../../../../services/poblacion.service.module';
import { AppConstants } from '../../../../app.constants';

@Component({
  selector: 'app-poblacion-add-modal',
  templateUrl: './poblacion-add-modal.component.html',
  styleUrls: ['./poblacion-add-modal.component.css']
})
export class PoblacionAddModalComponent implements OnInit {

  public formGroup: FormGroup;

  public provincias: ViewProvincia[];

  // Constructor
  constructor(private provinciaService: ProvinciaService,
    private poblacionService: PoblacionService,
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<PoblacionAddModalComponent>,
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
      'ImageUri': ['', [Validators.required]],
      'ProvinciaId': [0, [Validators.required]]
    });
  }

  // Form Actions
  onSubmit(viewModel: AddPoblacion) {
    this.poblacionService.AddPoblacion(viewModel).subscribe(poblacion => {

      if (poblacion !== undefined) {
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
