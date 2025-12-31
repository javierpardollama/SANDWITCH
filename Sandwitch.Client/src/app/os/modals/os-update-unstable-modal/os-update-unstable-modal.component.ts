import { Component, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import {
  MatDialogActions,
  MatDialogClose,
  MatDialogContent,
  MatDialogRef,
  MatDialogTitle
} from '@angular/material/dialog';

@Component({
  selector: 'app-os-update-unstable-modal',
  imports: [
    MatButtonModule,
    MatDialogTitle,
    MatDialogContent,
    MatDialogActions,
    MatDialogClose
  ], templateUrl: './os-update-unstable-modal.component.html',
  styleUrl: './os-update-unstable-modal.component.scss',
})
export class OsUpdateUnstableModalComponent {

  readonly dialogRef = inject(MatDialogRef<OsUpdateUnstableModalComponent>);

  public Proceed() {
    this.dialogRef.close(true);
  }

  public Delay() {
    this.dialogRef.close(false);
  }
}
