FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build

WORKDIR /app
WORKDIR /src

ENV ASPNETCORE_APP_RUNNING_ENV=docker

COPY Bookstore.Api/*.csproj ./Bookstore.Api/
COPY Bookstore.Domain/*.csproj ./Bookstore.Domain/
COPY Bookstore.Repository/*.csproj ./Bookstore.Repository/
COPY Bookstore.Repository.Mongo/*.csproj ./Bookstore.Repository.Mongo/
COPY Bookstore.Services/*.csproj ./Bookstore.Services/

RUN dotnet restore "Bookstore.Api/Bookstore.Api.csproj"
COPY . .

# Build Tests
COPY Bookstore.Api.IntegrationTests/*.csproj ./Bookstore.Api.IntegrationTests/
WORKDIR /src/Bookstore.Api.IntegrationTests

RUN dotnet restore "Bookstore.Api.IntegrationTests.csproj"

RUN dotnet build "Bookstore.Api.IntegrationTests.csproj" -c Release --nologo
CMD dotnet test "Bookstore.Api.IntegrationTests.csproj" -c Release --nologo --no-build