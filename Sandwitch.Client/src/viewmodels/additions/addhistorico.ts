import { Time } from "@angular/common";

export interface AddHistorico {
    ArenalId: number;
    BanderaId: number;
    Temperatura: number;
    BajaMarAlba: Time;
    BajaMarOcaso: Time;
    AltaMarAlba: Time;
    AltaMarOcaso: Time;
}
