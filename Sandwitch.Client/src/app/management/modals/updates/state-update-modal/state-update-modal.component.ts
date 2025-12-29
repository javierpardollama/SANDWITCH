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

import { ViewState } from '../../../../../viewmodels/views/viewstate';

import { UpdateState } from '../../../../../viewmodels/updates/updatestate';

import { StateService } from '../../../../../services/state.service';

import { TextAppVariants } from '../../../../../variants/text.app.variants';

import { TimeAppVariants } from '../../../../../variants/time.app.variants';

import { ExpressionAppVariants } from '../../../../../variants/expression.app.variants';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatTooltipModule } from '@angular/material/tooltip';


@Component({
  changeDetection: ChangeDetectionStrategy.OnPush,
  selector: 'app-state-update-modal',
  templateUrl: './state-update-modal.component.html',
  styleUrls: ['./state-update-modal.component.scss'],
  imports: [
    MatDialogModule,
    MatButtonModule,
    FormsModule,
    MatTooltipModule,
    MatSnackBarModule,
    MatSelectModule,
    MatInputModule,
    MatFormFieldModule,
    ReactiveFormsModule
  ]
})
export class StateUpdateModalComponent implements OnInit {
  // DI
  private stateService = inject(StateService);
  private formBuilder = inject(FormBuilder);
  dialogRef = inject<MatDialogRef<StateUpdateModalComponent>>(MatDialogRef);
  private matSnackBar = inject(MatSnackBar);
  data = inject<ViewState>(MAT_DIALOG_DATA);

  public formGroup!: FormGroup;

  // Constructor
  constructor() { }


  // Life Cicle
  ngOnInit(): void {
    this.CreateForm();
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
      ImageUri: new FormControl<string>(this.data.ImageUri, [Validators.required]),
    });
  }

  // Form Actions
  async onSubmit(viewModel: UpdateState): Promise<void> {
    let provincia = await this.stateService.UpdateState(viewModel)

    if (provincia) {
      this.matSnackBar.open(
        TextAppVariants.AppOperationSuccessCoreText,
        TextAppVariants.AppOkButtonText,
        { duration: TimeAppVariants.AppToastSecondTicks * TimeAppVariants.AppTimeSecondTicks });
    }

    this.dialogRef.close();
  }

  async onDelete(viewModel: UpdateState): Promise<void> {
    await this.stateService.RemoveStateById(viewModel.Id);

    this.matSnackBar.open(
      TextAppVariants.AppOperationSuccessCoreText,
      TextAppVariants.AppOkButtonText,
      { duration: TimeAppVariants.AppToastSecondTicks * TimeAppVariants.AppTimeSecondTicks }
    );

    this.dialogRef.close();
  }
}
