import {
  Component,
  OnInit,
  Inject
} from '@angular/core';

import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';

import {
  FormBuilder,
  FormControl,
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
  styleUrls: ['./poblacion-update-modal.component.scss']
})
export class PoblacionUpdateModalComponent implements OnInit {

  public formGroup!: FormGroup;

  public provincias: ViewProvincia[] = [];

  // Constructor
  constructor(
    private provinciaService: ProvinciaService,
    private poblacionService: PoblacionService,
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<PoblacionUpdateModalComponent>,
    private matSnackBar: MatSnackBar,
    @Inject(MAT_DIALOG_DATA) public data: ViewPoblacion) { }


  // Life Cicle
  ngOnInit(): void {
    this.FindAllProvincia();
    this.CreateForm();
  }

  // Form
  CreateForm(): void {
    this.formGroup = this.formBuilder.group({
      Id: new FormControl<number>(this.data.Id, [Validators.required]),
      Name: new FormControl<string>(this.data.Name, [Validators.required, Validators.pattern(new RegExp(/^[0-9A-Za-zÀ-ÖØ-öø-ÿ .\-`']*$/))]),
      ImageUri: new FormControl<string>(this.data.ImageUri, [Validators.required]),
      ProvinciaId: new FormControl<number>(this.data.Provincia.Id, [Validators.required])
    });
  }

  // Form Actions
  async onSubmit(viewModel: UpdatePoblacion): Promise<void> {
    let poblacion = await this.poblacionService.UpdatePoblacion(viewModel);

    if (poblacion) {
      this.matSnackBar.open(
        TextAppVariants.AppOperationSuccessCoreText,
        TextAppVariants.AppOkButtonText,
        { duration: TimeAppVariants.AppToastSecondTicks * TimeAppVariants.AppTimeSecondTicks });
    }

    this.dialogRef.close();

  }

  async onDelete(viewModel: UpdatePoblacion): Promise<void> {
    await this.poblacionService.RemovePoblacionById(viewModel.Id);

    this.matSnackBar.open(
      TextAppVariants.AppOperationSuccessCoreText,
      TextAppVariants.AppOkButtonText,
      { duration: TimeAppVariants.AppToastSecondTicks * TimeAppVariants.AppTimeSecondTicks });

    this.dialogRef.close();

  }

  // Get Data from Service
  public async FindAllProvincia(): Promise<void> {
    this.provincias = await this.provinciaService.FindAllProvincia();
  }
}
