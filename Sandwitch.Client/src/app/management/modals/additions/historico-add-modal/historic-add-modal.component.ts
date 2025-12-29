import { ChangeDetectionStrategy, Component, OnInit, inject } from '@angular/core';

import { NgOptimizedImage, Time } from '@angular/common';

import { MatDialogRef, MAT_DIALOG_DATA, MatDialogModule } from '@angular/material/dialog';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';

import {
  FormBuilder,
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators
} from '@angular/forms';

import { ViewBeach } from '../../../../../viewmodels/views/viewbeach';

import { AddHistoric } from '../../../../../viewmodels/additions/addhistoric';

import { HistoricService } from '../../../../../services/historic.service';

import { FlagService } from '../../../../../services/flag.service';

import { WindService } from '../../../../../services/wind.service';

import { TextAppVariants } from '../../../../../variants/text.app.variants';

import { TimeAppVariants } from '../../../../../variants/time.app.variants';

import { ExpressionAppVariants } from '../../../../../variants/expression.app.variants';

import { TimeService } from 'src/services/time.service';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { ViewCatalog } from 'src/viewmodels/views/viewcatalog';
import { MatTooltipModule } from '@angular/material/tooltip';

@Component({
  changeDetection: ChangeDetectionStrategy.OnPush,
  selector: 'app-historic-add-modal',
  templateUrl: './historic-add-modal.component.html',
  styleUrls: ['./historic-add-modal.component.scss'],
  imports: [
    MatDialogModule,
    MatButtonModule,
    FormsModule,
    MatTooltipModule,
    MatSnackBarModule,
    MatSelectModule,
    MatInputModule,
    MatFormFieldModule,
    ReactiveFormsModule,
    NgOptimizedImage
  ]
})
export class HistoricAddModalComponent implements OnInit {
  // DI
  private historicService = inject(HistoricService);
  private flagService = inject(FlagService);
  private windService = inject(WindService);
  private formBuilder = inject(FormBuilder);
  dialogRef = inject<MatDialogRef<HistoricAddModalComponent>>(MatDialogRef);
  private matSnackBar = inject(MatSnackBar);
  data = inject<ViewBeach>(MAT_DIALOG_DATA);


  public formGroup!: FormGroup;

  public flags: ViewCatalog[] = [];

  public winds: ViewCatalog[] = [];

  // Constructor
  constructor() { }


  // Life Cicle
  async ngOnInit(): Promise<void> {
    this.CreateForm();
    await this.FindAllFlag();
    await this.FindAllWind();
  }

  // Form
  CreateForm(): void {
    this.formGroup = this.formBuilder.group({
      BeachId: new FormControl<number>(this.data.Id,
        [Validators.required]),
      FlagId: new FormControl<number>(this.data.LastHistoric.Flag.Id,
        [Validators.required]),
      Temperatura: new FormControl<number>(this.data.LastHistoric.Temperature,
        [Validators.required,
        Validators.pattern(ExpressionAppVariants.AppNumberExpression)]),
      WindId: new FormControl<number>(this.data.LastHistoric.Wind.Id,
        [Validators.required]),
      Speed: new FormControl<number>(this.data.LastHistoric.Speed,
        [Validators.required,
        Validators.pattern(ExpressionAppVariants.AppNumberExpression)]),
      LowSeaDawn: new FormControl<Time>(TimeService.Now(),
        [Validators.required]),
      HighSeaDawn: new FormControl<Time>(TimeService.Now(),
        [Validators.required]),
      LowSeaSunset: new FormControl<Time>(TimeService.Now(),
        [Validators.required]),
      HighSeaSunset: new FormControl<Time>(TimeService.Now(),
        [Validators.required]),
    });
  }

  // Form Actions
  async onSubmit(viewModel: AddHistoric): Promise<void> {
    let historico = await this.historicService.AddHistoric(viewModel);

    if (historico) {
      this.matSnackBar.open(
        TextAppVariants.AppOperationSuccessCoreText,
        TextAppVariants.AppOkButtonText,
        { duration: TimeAppVariants.AppToastSecondTicks * TimeAppVariants.AppTimeSecondTicks });
    }

    this.dialogRef.close();
  }

  // Get Data from Service
  public async FindAllFlag(): Promise<void> {
    this.flags = await this.flagService.FindAllFlag();
  }

  // Get Data from Service
  public async FindAllWind(): Promise<void> {
    this.winds = await this.windService.FindAllWind();
  }
}
