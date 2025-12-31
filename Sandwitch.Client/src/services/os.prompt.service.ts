import { inject, Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { SwUpdate, VersionReadyEvent } from '@angular/service-worker';
import { filter } from 'rxjs/operators';
import { OsUpdateAvailableModalComponent } from 'src/app/os/modals/os-update-available-modal/os-update-available-modal.component';


@Injectable({ providedIn: 'root' })
export class OsPromptService {

    private matDialog = inject(MatDialog);
    private swUpdate = inject(SwUpdate);

    constructor() {

        if (!this.swUpdate.isEnabled) {
            console.info('[Update] Service worker updates are disabled.');
            return;
        }

        this.swUpdate.versionUpdates
            .pipe(filter((evt): evt is VersionReadyEvent => evt.type === 'VERSION_READY'))
            .subscribe(() => {
                const dialogRef = this.matDialog.open(OsUpdateAvailableModalComponent, {
                    width: '450px'
                });

                dialogRef.afterClosed().subscribe(async (res) => {
                    if (res) { location.reload(); }
                });
            });
    }
}