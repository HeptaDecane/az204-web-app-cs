FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
COPY bin/publish/ .
ENTRYPOINT ["dotnet", "Az204WebApp.dll"]