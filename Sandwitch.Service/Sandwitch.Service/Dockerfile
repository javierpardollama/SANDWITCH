# Consulte https://aka.ms/customizecontainer para aprender a personalizar su contenedor de depuraci�n y c�mo Visual Studio usa este Dockerfile para compilar sus im�genes para una depuraci�n m�s r�pida.

# Esta fase se usa cuando se ejecuta desde VS en modo r�pido (valor predeterminado para la configuraci�n de depuraci�n)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app

# Usa usuario no root
USER $APP_UID

# Opcional: fija los puertos HTTP/HTTPS expl�citamente (coincide con EXPOSE)
ENV ASPNETCORE_URLS=http://+:8080;https://+:8081

# Expone s�lo los puertos necesarios.
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
COPY ["Sandwitch.Service/nuget.config", "./nuget.config"]

RUN dotnet restore "./Sandwitch.Service/Sandwitch.Service.csproj" --configfile "./nuget.config" --locked-mode

# Ahora copia el resto del c�digo (esto invalida el cach� s�lo si cambian fuentes)
COPY . .

# Compila sin restaurar (ya hicimos restore), salida a una carpeta intermedia
WORKDIR "/src/Sandwitch.Service"
RUN dotnet build "./Sandwitch.Service.csproj" -c $BUILD_CONFIGURATION --no-restore -o /app/build

# Esta fase se usa para publicar el proyecto de servicio que se copiar� en la fase final.
FROM build AS publish
ARG BUILD_CONFIGURATION=Release

# Publica sin restaurar, reduciendo tama�o final
RUN dotnet publish "./Sandwitch.Service.csproj" -c $BUILD_CONFIGURATION --no-restore -o /app/publish

# Esta fase se usa en producci�n o cuando se ejecuta desde VS en modo normal (valor predeterminado cuando no se usa la configuraci�n de depuraci�n)
FROM base AS final
WORKDIR /app

# Copia artefactos de publish
COPY --from=publish /app/publish .

# Entrypoint
ENTRYPOINT ["dotnet", "Sandwitch.Service.dll"]