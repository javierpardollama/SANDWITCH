import { ChangeDetectionStrategy, Component, OnInit, inject } from '@angular/core';

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

import { UpdateBeach } from '../../../../../viewmodels/updates/updatebeach';

import { BeachService } from '../../../../../services/beach.service';

import { TextAppVariants } from '../../../../../variants/text.app.variants';

import { TimeAppVariants } from '../../../../../variants/time.app.variants';

import { ExpressionAppVariants } from '../../../../../variants/expression.app.variants';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { NgOptimizedImage } from '@angular/common';
import { ViewCatalog } from 'src/viewmodels/views/viewcatalog';
import { TownService } from 'src/services/town.service';
import { MatTooltipModule } from '@angular/material/tooltip';

@Component({
  changeDetection: ChangeDetectionStrategy.OnPush,
  selector: 'app-beach-update-modal',
  templateUrl: './beach-update-modal.component.html',
  styleUrls: ['./beach-update-modal.component.scss'],
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
export class BeachUpdateModalComponent implements OnInit {
  // DI
  private beachService = inject(BeachService);
  private townService = inject(TownService);
  private formBuilder = inject(FormBuilder);
  dialogRef = inject<MatDialogRef<BeachUpdateModalComponent>>(MatDialogRef);
  private matSnackBar = inject(MatSnackBar);
  data = inject<ViewBeach>(MAT_DIALOG_DATA);

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
      Id: new FormControl<number>(this.data.Id, [Validators.required]),
      Name: new FormControl<string>(this.data.Name,
        [
          Validators.required,
          Validators.pattern(new RegExp(ExpressionAppVariants.AppNameExpression))
        ]),
      TownsId: new FormControl<number[]>(this.data.Towns.map(({ Id }) => Id), [Validators.required])
    });
  }

  // Form Actions
  async onSubmit(viewModel: UpdateBeach): Promise<void> {
    let arenal = await this.beachService.UpdateBeach(viewModel);

    if (arenal) {
      this.matSnackBar.open(
        TextAppVariants.AppOperationSuccessCoreText,
        TextAppVariants.AppOkButtonText,
        { duration: TimeAppVariants.AppToastSecondTicks * TimeAppVariants.AppTimeSecondTicks });
    }

    this.dialogRef.close();
  }

  async onDelete(viewModel: UpdateBeach): Promise<void> {
    await this.beachService.RemoveBeachById(viewModel.Id);

    this.matSnackBar.open(
      TextAppVariants.AppOperationSuccessCoreText,
      TextAppVariants.AppOkButtonText,
      { duration: TimeAppVariants.AppToastSecondTicks * TimeAppVariants.AppTimeSecondTicks });

    this.dialogRef.close();

  }

  // Get Data from Service
  public async FindAllTown(): Promise<void> {
    this.towns = await this.townService.FindAllTown();
  }
}
