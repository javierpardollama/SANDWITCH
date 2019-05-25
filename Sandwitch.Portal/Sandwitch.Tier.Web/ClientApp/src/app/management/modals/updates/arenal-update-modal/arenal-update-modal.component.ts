import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA, MatSnackBar } from '@angular/material';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ViewArenal } from '../../../../../viewmodels/views/viewarenal';
import { ViewProvincia } from '../../../../../viewmodels/views/viewprovincia';

import { UpdateArenal } from '../../../../../viewmodels/updates/updatearenal';

import { ArenalService } from '../../../../../services/arenal.service.module';
import { ProvinciaService } from '../../../../../services/provincia.service.module';

@Component({
  selector: 'app-arenal-update-modal',
  templateUrl: './arenal-update-modal.component.html',
  styleUrls: ['./arenal-update-modal.component.css']
})
export class ArenalUpdateModalComponent implements OnInit {

  public formGroup: FormGroup;

  public provincias: ViewProvincia[];

  // Constructor
  constructor(private arenalService: ArenalService,
    private provinciaService: ProvinciaService,
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<ArenalUpdateModalComponent>,
    private matSnackBar: MatSnackBar,
    @Inject(MAT_DIALOG_DATA) public data: ViewArenal) { }


  // Life Cicle
  ngOnInit() {
    this.FindAllProvincia();
    this.CreateForm();
  }

  // Form
  CreateForm() {
    this.formGroup = this.formBuilder.group({
      'Id': [this.data.Id, [Validators.required]],
      'Name': [this.data.Name, [Validators.required]],
      'PoblacionesId': [this.data.Poblaciones, [Validators.required]]
    });
  }

  // Form Actions
  onSubmit(viewModel: UpdateArenal) {
    this.arenalService.UpdateArenal(viewModel).subscribe(arenal => {

      if (arenal.Id !== undefined) {
        this.matSnackBar.open('Operation Successful', 'Ok');
      }

      this.dialogRef.close();
    });
  }

  onDelete(viewModel: UpdateArenal) {
    this.arenalService.RemoveArenalById(viewModel.Id).subscribe(arenal => {

      this.matSnackBar.open('Operation Successful', 'Ok');

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
