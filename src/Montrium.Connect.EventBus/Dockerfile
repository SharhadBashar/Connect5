FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 443

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY Montium.Connect.sln ./
COPY Montrium.Connect.MessageBus/Montrium.Connect.MessageBus.csproj Montrium.Connect.EventBus/
RUN dotnet restore -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/Montrium.Connect.MessageBus
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Montrium.Connect.EventBus.dll"]
