FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 55335
EXPOSE 44373

FROM microsoft/dotnet:2.1-sdk-nanoserver-1709 AS build
WORKDIR /src
COPY Montrium.Connect.Tasks/Montrium.Connect.Tasks.csproj Montrium.Connect.Tasks/
RUN dotnet restore Montrium.Connect.Tasks/Montrium.Connect.Tasks.csproj
COPY . .
WORKDIR /src/Montrium.Connect.Tasks
RUN dotnet build Montrium.Connect.Tasks.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Montrium.Connect.Tasks.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Montrium.Connect.Tasks.dll"]
