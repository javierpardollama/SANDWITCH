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
  selector: 'app-os-update-available-modal',
  imports: [
    MatButtonModule,
    MatDialogTitle,
    MatDialogContent,
    MatDialogActions,
    MatDialogClose
  ],
  templateUrl: './os-update-available-modal.component.html',
  styleUrl: './os-update-available-modal.component.scss',
})
export class OsUpdateAvailableModalComponent {

  readonly dialogRef = inject(MatDialogRef<OsUpdateAvailableModalComponent>);

  public Proceed() {
    this.dialogRef.close(true);
  }

  public Delay() {
    this.dialogRef.close(false);
  }
}
