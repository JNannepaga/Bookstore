# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
    
EXPOSE 80
EXPOSE 443

# Copy csproj and restore as distinct layers
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY *.sln .
COPY Bookstore.Api/*.csproj ./Bookstore.Api/
COPY Bookstore.Domain/*.csproj ./Bookstore.Domain/
COPY Bookstore.Repository/*.csproj ./Bookstore.Repository/
COPY Bookstore.Repository.Mongo/*.csproj ./Bookstore.Repository.Mongo/
COPY Bookstore.Services/*.csproj ./Bookstore.Services/

RUN dotnet restore "Bookstore.Api"

# Copy everything else and build
COPY . .

# Build runtime image
WORKDIR /src/Bookstore.Api
RUN dotnet build "Bookstore.Api.csproj" -c Release -o /app/build

# Publish runtime image
FROM build As publish
RUN dotnet publish "Bookstore.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bookstore.Api.dll"]