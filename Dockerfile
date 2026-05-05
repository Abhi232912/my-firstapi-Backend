# 1. Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# Project files ni copy chestunnam
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app

# 2. Run Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .

# Port configuration for Render
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

# Ikkada me project .dll name ivvali
ENTRYPOINT ["dotnet", "MyFirstWebApi.dll"]