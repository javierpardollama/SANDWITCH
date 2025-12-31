import { ApplicationRef, DestroyRef, inject, Injectable } from '@angular/core';
import { SwUpdate } from '@angular/service-worker';
import { concat, interval, of } from 'rxjs';
import { catchError, first, switchMap, tap } from 'rxjs/operators';
import { TimeAppVariants } from 'src/variants/time.app.variants';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';

@Injectable({ providedIn: 'root' })
export class OsUpdateService {

    private appRef = inject(ApplicationRef);
    private updates = inject(SwUpdate);
    private destroyRef = inject(DestroyRef);

    constructor() {

        // Allow the app to stabilize first, before starting
        // polling for updates with `interval()`.
        const IsStable = this.appRef.isStable.pipe(first((isStable) => isStable === true));

        const DayInterval = interval(TimeAppVariants.AppUpdateSecondTicks);

        const StartPolling = concat(IsStable, DayInterval);

        StartPolling
            .pipe(
                takeUntilDestroyed(this.destroyRef),
                switchMap(() => this.updates.checkForUpdate()),
                tap((updateFound) => {
                    if (updateFound) {
                        console.info('[Update] A new version is available.');
                    } else {
                        console.debug('[Update] Already on the latest version.');
                    }
                }),
                catchError((err) => {
                    console.error('[Update] Failed to check for updates:', err);
                    // Swallow error to keep polling alive
                    return of(null);
                })
            )
            .pipe()
            .subscribe({
                // Ensure cleanup on destroy (Angular 16 takeUntilDestroyed)
            });

    }
}