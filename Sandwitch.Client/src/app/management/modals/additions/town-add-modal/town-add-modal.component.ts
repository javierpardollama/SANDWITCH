import { ChangeDetectionStrategy, Component, OnInit, inject } from '@angular/core';

import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';

import {
  FormBuilder,
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators
} from '@angular/forms';


import { AddTown } from '../../../../../viewmodels/additions/addtown';

import { StateService } from '../../../../../services/state.service';

import { TownService } from '../../../../../services/town.service';

import { TextAppVariants } from '../../../../../variants/text.app.variants';

import { TimeAppVariants } from '../../../../../variants/time.app.variants';

import { ExpressionAppVariants } from '../../../../../variants/expression.app.variants';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { NgOptimizedImage } from '@angular/common';
import { ViewCatalog } from 'src/viewmodels/views/viewcatalog';
import { MatTooltipModule } from '@angular/material/tooltip';

@Component({
  changeDetection: ChangeDetectionStrategy.OnPush,
  selector: 'app-town-add-modal',
  templateUrl: './town-add-modal.component.html',
  styleUrls: ['./town-add-modal.component.scss'],
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
export class TownAddModalComponent implements OnInit {
  // DI
  private stateService = inject(StateService);
  private townService = inject(TownService);
  private formBuilder = inject(FormBuilder);
  dialogRef = inject<MatDialogRef<TownAddModalComponent>>(MatDialogRef);
  private matSnackBar = inject(MatSnackBar);

  public formGroup!: FormGroup;

  public states: ViewCatalog[] = [];

  // Constructor
  constructor() { }


  // Life Cicle
  async ngOnInit(): Promise<void> {
    this.CreateForm();
    await this.FindAllState();
  }

  // Form
  CreateForm(): void {
    this.formGroup = this.formBuilder.group({
      Name: new FormControl<string>(TextAppVariants.AppEmptyCoreText,
        [
          Validators.required,
          Validators.pattern(new RegExp(ExpressionAppVariants.AppNameExpression))
        ]),
      ImageUri: new FormControl<string>(TextAppVariants.AppEmptyCoreText,
        [Validators.required]),
      StateId: new FormControl<number>(0, [Validators.required])
    });
  }

  // Form Actions
  async onSubmit(viewModel: AddTown): Promise<void> {
    let poblacion = await this.townService.AddTown(viewModel);

    if (poblacion) {
      this.matSnackBar.open(
        TextAppVariants.AppOperationSuccessCoreText,
        TextAppVariants.AppOkButtonText,
        { duration: TimeAppVariants.AppToastSecondTicks * TimeAppVariants.AppTimeSecondTicks });
    }

    this.dialogRef.close();
  }

  // Get Data from Service
  public async FindAllState(): Promise<void> {
    this.states = await this.stateService.FindAllState();
  }
}
