# Base
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copia todos os arquivos do projeto
COPY . .

# Restaura dependências
RUN dotnet restore "BeatNationAPI.csproj"

# Build
RUN dotnet build "BeatNationAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publica
RUN dotnet publish "BeatNationAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "BeatNationAPI.dll"]
