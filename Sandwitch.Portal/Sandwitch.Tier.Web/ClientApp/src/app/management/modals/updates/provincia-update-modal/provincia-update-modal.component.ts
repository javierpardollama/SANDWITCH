import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Provincia } from '../../../../../viewmodels/core/provincia';
import { UpdateProvincia } from '../../../../../viewmodels/updates/updateprovincia';

import { ProvinciaService } from '../../../../../services/provincia.service.module';

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
    @Inject(MAT_DIALOG_DATA) public data: Provincia) { }


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
      this.dialogRef.close();
    });
  }
}
