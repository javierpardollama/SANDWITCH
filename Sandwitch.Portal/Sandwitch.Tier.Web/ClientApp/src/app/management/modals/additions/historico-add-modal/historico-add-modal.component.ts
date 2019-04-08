import { Component, OnInit, Inject } from '@angular/core';
import { DatePipe } from '@angular/common';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ViewArenal } from '../../../../../viewmodels/views/viewarenal';
import { Bandera } from '../../../../../viewmodels/core/bandera';
import { AddHistorico } from '../../../../../viewmodels/additions/addhistorico';

import { HistoricoService } from '../../../../../services/historico.service.module';
import { BanderaService } from '../../../../../services/bandera.service.module';

@Component({
  selector: 'app-historico-add-modal',
  templateUrl: './historico-add-modal.component.html',
  styleUrls: ['./historico-add-modal.component.css']
})
export class HistoricoAddModalComponent implements OnInit {

  public formGroup: FormGroup;

  public datePipe: DatePipe;

  public timeFormat: string;

  public banderas: Bandera[];

  // Constructor
  constructor(private historicoService: HistoricoService,
    private banderaService: BanderaService,
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<HistoricoAddModalComponent>,
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
      'BajaMarAlba': [this.datePipe.transform(new Date(this.data.LastHistorico.BajaMarAlba), this.timeFormat), [Validators.required]],
      'AltaMarAlba': [this.datePipe.transform(new Date(this.data.LastHistorico.AltaMarAlba), this.timeFormat), [Validators.required]],
      'BajaMarOcaso': [this.datePipe.transform(new Date(this.data.LastHistorico.BajaMarOcaso), this.timeFormat), [Validators.required]],
      'AltaMarOcaso': [this.datePipe.transform(new Date(this.data.LastHistorico.AltaMarOcaso), this.timeFormat), [Validators.required]],
    });
  }

  // Form Actions
  onSubmit(viewModel: AddHistorico) {
    this.historicoService.AddHistorico(viewModel).subscribe(historico => {
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