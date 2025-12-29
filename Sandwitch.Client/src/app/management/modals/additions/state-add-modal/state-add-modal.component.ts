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

import { AddState } from '../../../../../viewmodels/additions/addstate';

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
  selector: 'app-state-add-modal',
  templateUrl: './state-add-modal.component.html',
  styleUrls: ['./state-add-modal.component.scss'],
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
export class StateAddModalComponent implements OnInit {
  // DI
  private stateService = inject(StateService);
  private formBuilder = inject(FormBuilder);
  dialogRef = inject<MatDialogRef<StateAddModalComponent>>(MatDialogRef);
  private matSnackBar = inject(MatSnackBar);

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
      Name: new FormControl<string>(TextAppVariants.AppEmptyCoreText,
        [
          Validators.required,
          Validators.pattern(new RegExp(ExpressionAppVariants.AppNameExpression))
        ]),
      ImageUri: new FormControl<string>(TextAppVariants.AppEmptyCoreText, [Validators.required]),
    });
  }

  // Form Actions
  async onSubmit(viewModel: AddState): Promise<void> {
    let provincia = await this.stateService.AddState(viewModel);

    if (provincia) {
      this.matSnackBar.open(
        TextAppVariants.AppOperationSuccessCoreText,
        TextAppVariants.AppOkButtonText,
        { duration: TimeAppVariants.AppToastSecondTicks * TimeAppVariants.AppTimeSecondTicks });
    }

    this.dialogRef.close();
  }
}
