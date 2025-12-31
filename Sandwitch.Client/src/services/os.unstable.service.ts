import { inject, Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { SwUpdate } from '@angular/service-worker';
import { OsUpdateUnstableModalComponent } from 'src/app/os/modals/os-update-unstable-modal/os-update-unstable-modal.component';


@Injectable({ providedIn: 'root' })
export class OsUnstableService {

  private updates = inject(SwUpdate);
  private matDialog = inject(MatDialog);

  constructor() {
    this.updates.unrecoverable.subscribe(() => {

      const dialogRef = this.matDialog.open(OsUpdateUnstableModalComponent, {
        width: '450px'
      });

      dialogRef.afterClosed().subscribe(async (res) => {
        if (res) { location.reload(); }
      });
    });
  }
}