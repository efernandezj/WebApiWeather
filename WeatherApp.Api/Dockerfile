# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copiar solo los csproj primero (optimiza cache)
COPY WeatherApp.Api/WeatherApp.Api.csproj WeatherApp.Api/
COPY WeatherApp.Domain/WeatherApp.Domain.csproj WeatherApp.Domain/
COPY WeatherApp.Infrastructure/WeatherApp.Infrastructure.csproj WeatherApp.Infrastructure/
COPY WeatherApp.Application/WeatherApp.Application.csproj WeatherApp.Application/

RUN dotnet restore WeatherApp.Api/WeatherApp.Api.csproj

# Copiar todo el código
COPY . .

WORKDIR /src/WeatherApp.Api
RUN dotnet publish WeatherApp.Api.csproj -c Release -o /app/publish

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "WeatherApp.Api.dll"]
