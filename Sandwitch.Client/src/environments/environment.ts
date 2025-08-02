// This file can be replaced during build by using the `fileReplacements` array.
// `ng build ---prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment =
{
  Api:
  {
    Lock: "Peach",
    Key: "T/R4J6eyvNG<6ne!",
    Service:"https://localhost:7297/",
  },
  Otel:
  {
    Exporter:"https://localhost:16175/v1/traces",
    Key:"04adc0ddb20983d0e82b171afdaf2fd8"
  },
  ServiceWorker:
  {
    Enabled: false,
    TimeOut:30000
  },
  production: false
};

/*
 * In development mode, to ignore zone related error stack frames such as
 * `zone.run`, `zoneDelegate.invokeTask` for easier debugging, you can
 * import the following file, but please comment it out in production mode
 * because it will have performance impact when throw error
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
