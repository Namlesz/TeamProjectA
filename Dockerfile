FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM node:18-alpine AS node-build
WORKDIR src/web
COPY TeamProjectA.Web/package*.json .
RUN npm install
COPY TeamProjectA.Web/ .
RUN npm run build

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY TeamProjectA.Api/TeamProjectA.Api.csproj TeamProjectA.Api/

RUN dotnet restore TeamProjectA.Api/TeamProjectA.Api.csproj
COPY . .

WORKDIR /src/TeamProjectA.Api
RUN dotnet build TeamProjectA.Api.csproj -c Release -o /app/build

COPY --from=node-build /src/web/build/ wwwroot/

FROM build AS publish
RUN dotnet publish TeamProjectA.Api.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TeamProjectA.Api.dll"]
