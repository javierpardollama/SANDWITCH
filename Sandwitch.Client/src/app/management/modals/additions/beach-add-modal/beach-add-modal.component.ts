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


import { AddBeach } from '../../../../../viewmodels/additions/addbeach';

import { BeachService } from '../../../../../services/beach.service';


import { TextAppVariants } from '../../../../../variants/text.app.variants';

import { TimeAppVariants } from '../../../../../variants/time.app.variants';

import { ExpressionAppVariants } from '../../../../../variants/expression.app.variants';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { TownService } from 'src/services/town.service';
import { ViewCatalog } from 'src/viewmodels/views/viewcatalog';
import { MatTooltipModule } from '@angular/material/tooltip';
import { NgOptimizedImage } from '@angular/common';

@Component({
  changeDetection: ChangeDetectionStrategy.OnPush,
  selector: 'app-beach-add-modal',
  templateUrl: './beach-add-modal.component.html',
  styleUrls: ['./beach-add-modal.component.scss'],
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
export class BeachAddModalComponent implements OnInit {
  // DI
  private beachService = inject(BeachService);
  private townService = inject(TownService);
  private formBuilder = inject(FormBuilder);
  dialogRef = inject<MatDialogRef<BeachAddModalComponent>>(MatDialogRef);
  private matSnackBar = inject(MatSnackBar);

  public formGroup!: FormGroup;

  public towns: ViewCatalog[] = [];

  // Constructor
  constructor() { }


  // Life Cicle
  async ngOnInit(): Promise<void> {
    this.CreateForm();
    await this.FindAllTown();
  }

  // Form
  CreateForm(): void {
    this.formGroup = this.formBuilder.group({
      Name: new FormControl<string>(TextAppVariants.AppEmptyCoreText,
        [
          Validators.required,
          Validators.pattern(new RegExp(ExpressionAppVariants.AppNameExpression))
        ]),
      TownsId: new FormControl<number[]>([], [Validators.required])
    });
  }

  // Form Actions
  async onSubmit(viewModel: AddBeach): Promise<void> {
    let arenal = await this.beachService.AddBeach(viewModel);

    if (arenal) {
      this.matSnackBar.open(
        TextAppVariants.AppOperationSuccessCoreText,
        TextAppVariants.AppOkButtonText,
        { duration: TimeAppVariants.AppToastSecondTicks * TimeAppVariants.AppTimeSecondTicks });
    }

    this.dialogRef.close();

  }

  // Get Data from Service
  public async FindAllTown(): Promise<void> {
    this.towns = await this.townService.FindAllTown();
  }
}
