FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 443

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY Montium.Connect.sln ./
COPY Montrium.Connect.EventBusServiceBus/Montrium.Connect.EventBusServiceBus.csproj Montrium.Connect.EventBusServiceBus/
RUN dotnet restore -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/Montrium.Connect.EventBusServiceBus
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Montrium.Connect.EventBusServiceBus.dll"]
