import {
  Component,
  OnInit
} from '@angular/core';

import { MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';

import {
  FormBuilder,
  FormGroup,
  Validators
} from '@angular/forms';

import { ViewProvincia } from './../../../../../viewmodels/views/viewprovincia';

import { AddPoblacion } from './../../../../../viewmodels/additions/addpoblacion';

import { ProvinciaService } from './../../../../../services/provincia.service';

import { PoblacionService } from './../../../../../services/poblacion.service';

import { TextAppVariants } from './../../../../../variants/text.app.variants';

import { TimeAppVariants } from './../../../../../variants/time.app.variants';

@Component({
  selector: 'app-poblacion-add-modal',
  templateUrl: './poblacion-add-modal.component.html',
  styleUrls: ['./poblacion-add-modal.component.css']
})
export class PoblacionAddModalComponent implements OnInit {

  public formGroup: FormGroup;

  public provincias: ViewProvincia[];

  // Constructor
  constructor(
    private provinciaService: ProvinciaService,
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
      Name: [TextAppVariants.AppEmptyCoreText,
      [Validators.required]],
      ImageUri: [TextAppVariants.AppEmptyCoreText,
      [Validators.required]],
      ProvinciaId: [0, [Validators.required]]
    });
  }

  // Form Actions
  onSubmit(viewModel: AddPoblacion) {
    this.poblacionService.AddPoblacion(viewModel).subscribe(poblacion => {

      if (poblacion !== undefined) {
        this.matSnackBar.open(
          TextAppVariants.AppOperationSuccessCoreText,
          TextAppVariants.AppOkButtonText,
          { duration: TimeAppVariants.AppToastSecondTicks * TimeAppVariants.AppTimeSecondTicks });
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
