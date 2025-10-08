# SANDWITCH

[![Build & Test .NET API](https://github.com/javierpardollama/SANDWITCH/actions/workflows/dotnet-desktop.yml/badge.svg)](https://github.com/javierpardollama/SANDWITCH/actions/workflows/dotnet-desktop.yml) [![Build Angular App](https://github.com/javierpardollama/SANDWITCH/actions/workflows/node.js.yml/badge.svg)](https://github.com/javierpardollama/SANDWITCH/actions/workflows/node.js.yml)

Este proyecto surge como una solución para gestionar el estado actual de las playas españolas, administrando datos como la temperatura del agua y el horario de las mareas, así como el color de la bandera instalada por los socorristas. 

## ARQUITECTURA

Este Proyecto está construido en capas siguiendo el diseño guiado por dominio:

1. [Domain](https://github.com/javierpardollama/SANDWITCH/tree/main/Sandwitch.Service/Sandwitch.Domain)

En esta capa se modelan las reglas de negocio y se definen las entidades, objetos de valor, etc.

2. [Infrastructure](https://github.com/javierpardollama/SANDWITCH/tree/main/Sandwitch.Service/Sandwitch.Infrastructure)

En esta capa la información es almacenada y redistribuida al sistema de almacenamiento de datos.

3. [Application](https://github.com/javierpardollama/SANDWITCH/tree/main/Sandwitch.Service/Sandwitch.Application)

En esta capa se coordina el envío y/o recepción entre la capa de dominio (Domain) y la capa de infrastructura (Infrastrucure).


## BUILD

Para compilar y hacer funcionar este proyecto se recomienda utilizar una serie de herramientas con las cuales este proyecto ha sido construido y probado:

1. [.NET](https://dotnet.microsoft.com/)

Este framework es utilizado para construir todo lo referente a las capas Data Tier y Logic Tier.

2. [Node.js](https://nodejs.org/es/)

Este framework es utilizado para construir el entorno necesario para la capa Presentation Tier.

3. [Angular Cli](https://cli.angular.io/)

Este framework es utilizado para construir todo lo referente a la capa Presentation Tier.

## LICENSE

[MIT](https://github.com/javierpardollama/SANDWITCH/blob/master/LICENSE)
