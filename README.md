# SANDWITCH

This project arose as a solution to manage the current state of Spanish beaches, administering data such as water temperature and opening hours, tides, as well as the color of the flag set up by the lifeguards.

## ARCHITECTURE

This project is constructed using a micro-services oriented architecture:

- SERVICE

[![Service - Test .NET Infrastructure](https://github.com/javierpardollama/SANDWITCH/actions/workflows/dotnet-infrastructure.yml/badge.svg)](https://github.com/javierpardollama/SANDWITCH/actions/workflows/dotnet-infrastructure.yml)
[![Service - Build .NET Service](https://github.com/javierpardollama/SANDWITCH/actions/workflows/dotnet-service.yml/badge.svg)](https://github.com/javierpardollama/SANDWITCH/actions/workflows/dotnet-service.yml) 

.NET MVC Api. In this service, operations related to the beaches' flag status are performed

- CLIENT

[![Build Angular App](https://github.com/javierpardollama/HYPERDRIVE/actions/workflows/node.js.yml/badge.svg)](https://github.com/javierpardollama/HYPERDRIVE/actions/workflows/node.js.yml)

Angular Web Application. Provides a unified User Interface to perform all the operations.

## GETTING STARTED

To compile and run this project, it is recommended to use the following tools, which were used to build and test this project:

1. [.NET](https://dotnet.microsoft.com/)

This framework is used to build everything related to the Data Tier and Logic Tier layers.

2. [Node.js](https://nodejs.org/es/)

This framework is used to build the necessary environment for the Presentation Tier.

3. [Angular Cli](https://cli.angular.io/)

This framework is used to build everything related to the Presentation Tier.

## CONTRIBUTING

If you are interested in reporting/fixing issues and contributing directly to the code base, please see [CONTRIBUTING.md](https://github.com/javierpardollama/SANDWITCH/blob/main/CONTRIBUTING.md) for more information on what we're looking for and how to get started.

## LICENSE

[MIT](https://github.com/javierpardollama/SANDWITCH/blob/main/LICENSE)
