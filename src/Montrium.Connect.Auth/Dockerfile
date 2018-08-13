FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY ../Montrium.Connect.Auth/Montrium.Connect.Auth.csproj ../Montrium.Connect.Auth/
RUN dotnet restore ../Montrium.Connect.Auth/Montrium.Connect.Auth.csproj
COPY . .
WORKDIR /src/../Montrium.Connect.Auth
RUN dotnet build Montrium.Connect.Auth.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Montrium.Connect.Auth.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Montrium.Connect.Auth.dll"]
