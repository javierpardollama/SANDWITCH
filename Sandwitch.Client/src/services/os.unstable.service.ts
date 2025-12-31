import { inject, Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { SwUpdate } from '@angular/service-worker';
import { OsUpdateUnstableModalComponent } from 'src/app/os/modals/os-update-unstable-modal/os-update-unstable-modal.component';


@Injectable({ providedIn: 'root' })
export class OsUnstableService {

  private swUpdate = inject(SwUpdate);
  private matDialog = inject(MatDialog);

  constructor() {
    if (!this.swUpdate.isEnabled) {
      console.info('[Update] Service worker updates are disabled.');
      return;
    }

    this.swUpdate.unrecoverable.subscribe(() => {

      const dialogRef = this.matDialog.open(OsUpdateUnstableModalComponent, {
        width: '450px'
      });

      dialogRef.afterClosed().subscribe(async (res) => {
        if (res) { location.reload(); }
      });
    });
  }
}