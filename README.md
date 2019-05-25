# SANDWITCH

Este proyecto surge como una solución para gestionar el estado actual de las playas españolas, administrando datos como la temperatura del agua y el horario de las mareas, así como el color de la bandera instalada por los socorritas. 

## ARQUITECTURA

Este Proyecto está construido siguiendo el patrón de N capas:

1. [Data Tier](https://github.com/javierpardollama/SANDWITCH/tree/master/Sandwitch.Portal/Sandwitch.Tier.Contexts)

En Esta capa la información es almacenada y redistribuida al sistema de almacenamiento de datos.

2. [Logic Tier](https://github.com/javierpardollama/SANDWITCH/tree/master/Sandwitch.Portal/Sandwitch.Tier.Services)

En esta capa se coordina el envío y/o recepción entre la capa de datos (Data Tier) y la capa de presentación (Presentation Tier). 
Además, toma decisiones lógicas, realiza cálculos y se encarga de procesar órdenes distintas.

3. [Presentation Tier](https://github.com/javierpardollama/SANDWITCH/tree/master/Sandwitch.Portal/Sandwitch.Tier.Web)

En esta capa se traducen las distintas órdenes y resultados a una forma que el usuario pueda comprender.

## BUILD

Para comilar y hacer funcionar este proyecto se recomienda utilizar una serie de herramientas con las cuales este proyecto ha sido construido y probado:

1. [.NET](https://dotnet.microsoft.com/)

Este framework es utilizado para construir todo lo referente a las capas Data Tier y Logic Tier.

2. [Node.js](https://nodejs.org/es/)

Este framework es utilizado para construir el entorno necesario para la capa Presentation Tier.

3. [Angular Cli](https://cli.angular.io/)

Este framework es utilizado para construir todo lo referente a las capa Presentation Tier.

## LICENSE

[MIT](https://github.com/javierpardollama/SANDWITCH/blob/master/LICENSE)
