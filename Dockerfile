﻿# Prepare the build environment
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Build the web app
FROM node:18-alpine AS node-build
WORKDIR src/web

COPY src/TeamProjectA.Web/package*.json ./
RUN npm install

COPY src/TeamProjectA.Web/ ./
RUN npm run build

RUN npm run lint

# Build the API
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

COPY src/TeamProjectA.Api/TeamProjectA.Api.csproj src/TeamProjectA.Api/
COPY src/TeamProjectA.Application/TeamProjectA.Application.csproj src/TeamProjectA.Application/
COPY src/TeamProjectA.Domain/TeamProjectA.Domain.csproj src/TeamProjectA.Domain/
COPY src/TeamProjectA.Infrastructure/TeamProjectA.Infrastructure.csproj src/TeamProjectA.Infrastructure/

WORKDIR /src/TeamProjectA.Api

RUN dotnet restore TeamProjectA.Api.csproj
COPY src/TeamProjectA.Api .
COPY src/TeamProjectA.Application .
COPY src/TeamProjectA.Domain .
COPY src/TeamProjectA.Infrastructure .

RUN dotnet build TeamProjectA.Api.csproj -c Release -o /app/build

COPY --from=node-build /src/web/build/ wwwroot/

# Publish the API
FROM build AS publish
RUN dotnet publish TeamProjectA.Api.csproj -c Release -o /app/publish

# Run the API
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TeamProjectA.Api.dll"]
