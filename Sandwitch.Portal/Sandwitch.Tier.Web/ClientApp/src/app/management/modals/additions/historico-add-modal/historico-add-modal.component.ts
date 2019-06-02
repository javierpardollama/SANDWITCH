import { Component, OnInit, Inject } from '@angular/core';
import { DatePipe } from '@angular/common';
import { MatDialogRef, MAT_DIALOG_DATA, MatSnackBar } from '@angular/material';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ViewArenal } from '../../../../../viewmodels/views/viewarenal';
import { ViewBandera } from '../../../../../viewmodels/views/viewbandera';
import { AddHistorico } from '../../../../../viewmodels/additions/addhistorico';

import { HistoricoService } from '../../../../../services/historico.service.module';
import { BanderaService } from '../../../../../services/bandera.service.module';
import { AppConstants } from '../../../../app.constants';

@Component({
  selector: 'app-historico-add-modal',
  templateUrl: './historico-add-modal.component.html',
  styleUrls: ['./historico-add-modal.component.css']
})
export class HistoricoAddModalComponent implements OnInit {

  public formGroup: FormGroup;

  public datePipe: DatePipe;

  public timeFormat: string;

  public banderas: ViewBandera[];

  // Constructor
  constructor(private historicoService: HistoricoService,
    private banderaService: BanderaService,
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<HistoricoAddModalComponent>,
    private matSnackBar: MatSnackBar,
    @Inject(MAT_DIALOG_DATA) public data: ViewArenal) { }


  // Life Cicle
  ngOnInit() {
    this.FindAllBandera();
    this.CreateDateFormat();
    this.CreateForm();
  }

  // Pipes
  CreateDateFormat() {
    this.datePipe = new DatePipe('en-Us');
    this.timeFormat = 'HH:mm';
  }

  // Form
  CreateForm() {

    this.formGroup = this.formBuilder.group({
      'ArenalId': [this.data.Id, [Validators.required]],
      'BanderaId': [this.data.LastHistorico.Bandera.Id, [Validators.required]],
      'Temperatura': [this.data.LastHistorico.Temperatura, [Validators.required]],
      'BajaMarAlba': [this.datePipe.transform(new Date(), this.timeFormat), [Validators.required]],
      'AltaMarAlba': [this.datePipe.transform(new Date(), this.timeFormat), [Validators.required]],
      'BajaMarOcaso': [this.datePipe.transform(new Date(), this.timeFormat), [Validators.required]],
      'AltaMarOcaso': [this.datePipe.transform(new Date(), this.timeFormat), [Validators.required]],
    });
  }

  // Form Actions
  onSubmit(viewModel: AddHistorico) {
    this.historicoService.AddHistorico(viewModel).subscribe(historico => {

      if (historico !== undefined) {
        this.matSnackBar.open(AppConstants.AppSuccessButtonText, AppConstants.AppOkButtonText, { duration: AppConstants.AppToastSecondTicks * AppConstants.AppTimeSecondTicks });
      }

      this.dialogRef.close();
    });
  }

  // Get Data from Service
  public FindAllBandera() {
    this.banderaService.FindAllBandera().subscribe(banderas => {
      this.banderas = banderas;
    });
  }
}
