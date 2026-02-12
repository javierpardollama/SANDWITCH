# SANDWITCH

[![Test .NET Infrastructure](https://github.com/javierpardollama/SANDWITCH/actions/workflows/dotnet-infrastructure.yml/badge.svg)](https://github.com/javierpardollama/SANDWITCH/actions/workflows/dotnet-infrastructure.yml) [![Build .NET Service](https://github.com/javierpardollama/SANDWITCH/actions/workflows/dotnet-service.yml/badge.svg)](https://github.com/javierpardollama/SANDWITCH/actions/workflows/dotnet-service.yml) [![Build Angular App](https://github.com/javierpardollama/SANDWITCH/actions/workflows/node.js.yml/badge.svg)](https://github.com/javierpardollama/SANDWITCH/actions/workflows/node.js.yml)[![GitHub License](https://img.shields.io/github/license/javierpardollama/SANDWITCH)


This project arose as a solution to manage the current state of Spanish beaches, administering data such as water temperature and opening hours, tides, as well as the color of the flag set up by the lifeguards.

## ARCHITECTURE

This project is built in n layers, following a hexagonal structure (ports - adapters), under a domain-driven design:

1. [Domain](https://github.com/javierpardollama/SANDWITCH/tree/main/Sandwitch.Service/Sandwitch.Domain)

In this layer, the business rules are modeled and the entities, value objects, etc., are defined.

2. [Infrastructure](https://github.com/javierpardollama/SANDWITCH/tree/main/Sandwitch.Service/Sandwitch.Infrastructure)

In this layer, information is stored and redistributed to the data storage system.

3. [Application](https://github.com/javierpardollama/SANDWITCH/tree/main/Sandwitch.Service/Sandwitch.Application)

This layer coordinates the sending and/or receiving of data between the Domain layer and the Infrastructure layer.

## BUILD

To compile and run this project, it is recommended to use the following tools, which were used to build and test this project:

1. [.NET](https://dotnet.microsoft.com/)

This framework is used to build everything related to the Data Tier and Logic Tier layers.

2. [Node.js](https://nodejs.org/es/)

This framework is used to build the necessary environment for the Presentation Tier.

3. [Angular Cli](https://cli.angular.io/)

This framework is used to build everything related to the Presentation Tier.

## LICENSE

[MIT](https://github.com/javierpardollama/SANDWITCH/blob/master/LICENSE)
