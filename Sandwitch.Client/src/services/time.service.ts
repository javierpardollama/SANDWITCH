import { Time } from '@angular/common';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root',
})

export class TimeService {

    public static Now(): Time {
        return {
            hours: new Date().getHours(),
            minutes: new Date().getMinutes(),
        };
    }
}
