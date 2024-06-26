import {
  Component,
  OnInit,
  Inject
} from '@angular/core';

import { Time } from '@angular/common';

import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';

import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators
} from '@angular/forms';

import { ViewArenal } from './../../../../../viewmodels/views/viewarenal';

import { ViewBandera } from './../../../../../viewmodels/views/viewbandera';

import { ViewViento } from '../../../../../viewmodels/views/viewviento';

import { AddHistorico } from './../../../../../viewmodels/additions/addhistorico';

import { HistoricoService } from './../../../../../services/historico.service';

import { BanderaService } from './../../../../../services/bandera.service';

import { VientoService } from '../../../../../services/viento.service';

import { TextAppVariants } from './../../../../../variants/text.app.variants';

import { TimeAppVariants } from './../../../../../variants/time.app.variants';

import { ExpressionAppVariants } from './../../../../../variants/expression.app.variants';

import { TimeService } from 'src/services/time.service';

@Component({
  selector: 'app-historico-add-modal',
  templateUrl: './historico-add-modal.component.html',
  styleUrls: ['./historico-add-modal.component.scss']
})
export class HistoricoAddModalComponent implements OnInit {

  public formGroup!: FormGroup;

  public banderas: ViewBandera[] = [];

  public vientos: ViewViento[] = [];

  // Constructor
  constructor(
    private historicoService: HistoricoService,
    private banderaService: BanderaService,
    private vientoService: VientoService,
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<HistoricoAddModalComponent>,
    private matSnackBar: MatSnackBar,
    @Inject(MAT_DIALOG_DATA) public data: ViewArenal) { }


  // Life Cicle
  ngOnInit(): void {
    this.FindAllBandera();
    this.FindAllViento();
    this.CreateForm();
  }

  // Form
  CreateForm(): void {
    this.formGroup = this.formBuilder.group({
      ArenalId: new FormControl<number>(this.data.Id,
        [Validators.required]),
      BanderaId: new FormControl<number>(this.data.LastHistorico.Bandera.Id,
        [Validators.required]),
      Temperatura: new FormControl<number>(this.data.LastHistorico.Temperatura,
        [Validators.required,
        Validators.pattern(ExpressionAppVariants.AppNumberExpression)]),
      VientoId: new FormControl<number>(this.data.LastHistorico.Viento.Id,
        [Validators.required]),
      Velocidad: new FormControl<number>(this.data.LastHistorico.Velocidad,
        [Validators.required,
        Validators.pattern(ExpressionAppVariants.AppNumberExpression)]),
      BajaMarAlba: new FormControl<Time>(TimeService.Now(),
        [Validators.required]),
      AltaMarAlba: new FormControl<Time>(TimeService.Now(),
        [Validators.required]),
      BajaMarOcaso: new FormControl<Time>(TimeService.Now(),
        [Validators.required]),
      AltaMarOcaso: new FormControl<Time>(TimeService.Now(),
        [Validators.required]),
    });
  }

  // Form Actions
  async onSubmit(viewModel: AddHistorico): Promise<void> {
    let historico = await this.historicoService.AddHistorico(viewModel);

    if (historico) {
      this.matSnackBar.open(
        TextAppVariants.AppOperationSuccessCoreText,
        TextAppVariants.AppOkButtonText,
        { duration: TimeAppVariants.AppToastSecondTicks * TimeAppVariants.AppTimeSecondTicks });
    }

    this.dialogRef.close();
  }

  // Get Data from Service
  public async FindAllBandera(): Promise<void> {
    this.banderas = await this.banderaService.FindAllBandera();
  }

  // Get Data from Service
  public async FindAllViento(): Promise<void> {
    this.vientos = await this.vientoService.FindAllViento();
  }
}
