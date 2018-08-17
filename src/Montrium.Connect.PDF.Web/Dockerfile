FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 55574
EXPOSE 44370

FROM microsoft/dotnet:2.1-sdk-nanoserver-1709 AS build
WORKDIR /src
COPY Montrium.Connect.PDF.Web/Montrium.Connect.PDF.Web.csproj Montrium.Connect.PDF.Web/
RUN dotnet restore Montrium.Connect.PDF.Web/Montrium.Connect.PDF.Web.csproj
COPY . .
WORKDIR /src/Montrium.Connect.PDF.Web
RUN dotnet build Montrium.Connect.PDF.Web.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Montrium.Connect.PDF.Web.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Montrium.Connect.PDF.Web.dll"]
