FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY Document.API/Document.API.csproj Document.API/
RUN dotnet restore Document.API/Document.API.csproj
COPY . .
WORKDIR /src/Document.API
RUN dotnet build Document.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Document.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Document.API.dll"]
