import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Provincia } from '../../../../../viewmodels/core/provincia';
import { Poblacion } from '../../../../../viewmodels/core/poblacion';

import { UpdatePoblacion } from '../../../../../viewmodels/updates/updatepoblacion';

import { ProvinciaService } from '../../../../../services/provincia.service.module';
import { PoblacionService } from '../../../../../services/poblacion.service.module';

@Component({
  selector: 'app-poblacion-update-modal',
  templateUrl: './poblacion-update-modal.component.html',
  styleUrls: ['./poblacion-update-modal.component.css']
})
export class PoblacionUpdateModalComponent implements OnInit {

  public formGroup: FormGroup;

  public provincias: Provincia[];

  // Constructor
  constructor(private provinciaService: ProvinciaService,
    private poblacionService: PoblacionService,
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<PoblacionUpdateModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Poblacion) { }


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
      'ImageUri': [this.data.ImageUri, [Validators.required]],
      'ProvinciaId': [this.data.Provincia.Id, [Validators.required]]
    });
  }

  // Form Actions
  onSubmit(viewModel: UpdatePoblacion) {   
    this.poblacionService.UpdatePoblacion(viewModel).subscribe(poblacion => {
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
