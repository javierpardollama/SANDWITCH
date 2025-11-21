# Consulte https://aka.ms/customizecontainer para aprender a personalizar su contenedor de depuración y cómo Visual Studio usa este Dockerfile para compilar sus imágenes para una depuración más rápida.

# Esta fase se usa cuando se ejecuta desde VS en modo rápido (valor predeterminado para la configuración de depuración)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Esta fase se usa para compilar el proyecto de servicio
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Sandwitch.Service/Sandwitch.Service.csproj", "Sandwitch.Service/"]
COPY ["Sandwitch.Application/Sandwitch.Application.csproj", "Sandwitch.Application/"]
COPY ["Sandwitch.Domain/Sandwitch.Domain.csproj", "Sandwitch.Domain/"]
COPY ["Sandwitch.Infrastructure/Sandwitch.Infrastructure.csproj", "Sandwitch.Infrastructure/"]
RUN dotnet restore "./Sandwitch.Service/Sandwitch.Service.csproj"
COPY . .
WORKDIR "/src/Sandwitch.Service"
RUN dotnet build "./Sandwitch.Service.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Esta fase se usa para publicar el proyecto de servicio que se copiará en la fase final.
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Sandwitch.Service.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Esta fase se usa en producción o cuando se ejecuta desde VS en modo normal (valor predeterminado cuando no se usa la configuración de depuración)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sandwitch.Service.dll"]