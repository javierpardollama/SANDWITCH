import { Time } from "@angular/common";

export interface AddHistoric {
    BeachId: number;
    FlagId: number;
    WindId: number;
    Speed: number;
    Temperature: number;
    LowSeaDawn: Time;
    LowSeaSunset: Time;
    HighSeaDawn: Time;
    HighSeaSunset: Time;
}
