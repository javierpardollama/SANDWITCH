FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
USER $APP_UID

ENV ASPNETCORE_URLS=http://+:8080;https://+:8081

EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release

WORKDIR /src

COPY Sandwitch.Service/Sandwitch.Service/Sandwitch.Service.csproj, Sandwitch.Service/
COPY Sandwitch.Service/Sandwitch.Application/Sandwitch.Application.csproj, Sandwitch.Application/
COPY Sandwitch.Service/Sandwitch.Domain/Sandwitch.Domain.csproj, Sandwitch.Domain/
COPY Sandwitch.Service/Sandwitch.Infrastructure/Sandwitch.Infrastructure.csproj, Sandwitch.Infrastructure/
COPY Sandwitch.Service/nuget.config nuget.config

RUN dotnet restore "Sandwitch.Service/Sandwitch.Service.csproj" --configfile "./nuget.config" --locked-mode

COPY . .

WORKDIR /src/Sandwitch.Service/Sandwitch.Service
RUN dotnet build "Sandwitch.Service.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Sandwitch.Service.csproj" -c $BUILD_CONFIGURATION --no-restore -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sandwitch.Service.dll"]