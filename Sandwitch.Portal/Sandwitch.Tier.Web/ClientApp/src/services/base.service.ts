import { ViewException } from './../viewmodels/views/viewexception';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { MatSnackBar } from '@angular/material';
import { Observable, of } from 'rxjs';
import { TextAppVariants } from './../variants/text.app.variants';
import { TimeAppVariants } from './../variants/time.app.variants';

export class BaseService {

    public constructor(
        protected httpClient: HttpClient,
        protected matSnackBar: MatSnackBar) {

    }

    public HandleError<T>(operation = 'Operation', result?: T) {
        return (response: HttpErrorResponse): Observable<T> => {

            const exception: ViewException = {
                Message: response.error.Message,
                StatusCode: response.error.StatusCode
            };

            this.matSnackBar.open(
                exception.Message,
                TextAppVariants.AppOkButtonText,
                { duration: TimeAppVariants.AppToastSecondTicks * TimeAppVariants.AppTimeSecondTicks });

            // Let the app keep running by returning an empty result.
            return of(result as T);
        };
    }
}

