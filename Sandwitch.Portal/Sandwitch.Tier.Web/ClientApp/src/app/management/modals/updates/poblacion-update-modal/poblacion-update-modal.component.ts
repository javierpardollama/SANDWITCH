import {
  Component,
  OnInit,
  Inject
} from '@angular/core';

import {
  MatDialogRef,
  MAT_DIALOG_DATA,
  MatSnackBar
} from '@angular/material';

import {
  FormBuilder,
  FormGroup,
  Validators
} from '@angular/forms';

import { ViewProvincia } from './../../../../../viewmodels/views/viewprovincia';

import { ViewPoblacion } from './../../../../../viewmodels/views/viewpoblacion';

import { UpdatePoblacion } from './../../../../../viewmodels/updates/updatepoblacion';

import { ProvinciaService } from './../../../../../services/provincia.service';

import { PoblacionService } from './../../../../../services/poblacion.service';

import { TextAppVariants } from './../../../../../variants/text.app.variants';

import { TimeAppVariants } from './../../../../../variants/time.app.variants';

@Component({
  selector: 'app-poblacion-update-modal',
  templateUrl: './poblacion-update-modal.component.html',
  styleUrls: ['./poblacion-update-modal.component.css']
})
export class PoblacionUpdateModalComponent implements OnInit {

  public formGroup: FormGroup;

  public provincias: ViewProvincia[];

  // Constructor
  constructor(
    private provinciaService: ProvinciaService,
    private poblacionService: PoblacionService,
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<PoblacionUpdateModalComponent>,
    private matSnackBar: MatSnackBar,
    @Inject(MAT_DIALOG_DATA) public data: ViewPoblacion) { }


  // Life Cicle
  ngOnInit() {
    this.FindAllProvincia();
    this.CreateForm();
  }

  // Form
  CreateForm() {
    this.formGroup = this.formBuilder.group({
      Id: [this.data.Id, [Validators.required]],
      Name: [this.data.Name, [Validators.required]],
      ImageUri: [this.data.ImageUri, [Validators.required]],
      ProvinciaId: [this.data.Provincia.Id, [Validators.required]]
    });
  }

  // Form Actions
  onSubmit(viewModel: UpdatePoblacion) {
    this.poblacionService.UpdatePoblacion(viewModel).subscribe(poblacion => {

      if (poblacion !== undefined) {
        this.matSnackBar.open(
          TextAppVariants.AppOperationSuccessCoreText,
          TextAppVariants.AppOkButtonText,
          { duration: TimeAppVariants.AppToastSecondTicks * TimeAppVariants.AppTimeSecondTicks });
      }

      this.dialogRef.close();
    });
  }

  onDelete(viewModel: UpdatePoblacion) {
    this.poblacionService.RemovePoblacionById(viewModel.Id).subscribe(poblacion => {
      this.matSnackBar.open(
        TextAppVariants.AppOperationSuccessCoreText,
        TextAppVariants.AppOkButtonText,
        { duration: TimeAppVariants.AppToastSecondTicks * TimeAppVariants.AppTimeSecondTicks });

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
