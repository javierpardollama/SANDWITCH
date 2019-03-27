import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Bandera } from '../../../../../viewmodels/core/bandera';
import { UpdateBandera } from '../../../../../viewmodels/updates/updatebandera';

import { BanderaService } from '../../../../../services/bandera.service.module';

@Component({
  selector: 'app-bandera-update-modal',
  templateUrl: './bandera-update-modal.component.html',
  styleUrls: ['./bandera-update-modal.component.css']
})
export class BanderaUpdateModalComponent implements OnInit {

  public formGroup: FormGroup;

  // Constructor
  constructor(private banderaService: BanderaService,
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<BanderaUpdateModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Bandera) { }


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
  onSubmit(viewModel: UpdateBandera) {  
    this.banderaService.UpdateBandera(viewModel).subscribe(bandera => {
      this.dialogRef.close();
    });
  }
}
