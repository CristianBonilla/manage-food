#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

ARG DOTNET_RUNTIME=mcr.microsoft.com/dotnet/aspnet:8.0
ARG DOTNET_SDK=mcr.microsoft.com/dotnet/sdk:8.0

FROM $DOTNET_RUNTIME AS base
USER app
WORKDIR /app
EXPOSE 910
EXPOSE 577

FROM $DOTNET_SDK AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ManageFood.API/ManageFood.API.csproj", "ManageFood.API/"]
COPY ["ManageFood.Contracts/ManageFood.Contracts.csproj", "ManageFood.Contracts/"]
COPY ["ManageFood.Domain.Entities/ManageFood.Domain.Entities.csproj", "ManageFood.Domain.Entities/"]
COPY ["ManageFood.Domain.Helpers/ManageFood.Domain.Helpers.csproj", "ManageFood.Domain.Helpers/"]
COPY ["ManageFood.Domain/ManageFood.Domain.csproj", "ManageFood.Domain/"]
COPY ["ManageFood.Infrastructure/ManageFood.Infrastructure.csproj", "ManageFood.Infrastructure/"]

COPY ["ManageFood.Tests/ManageFood.Tests.csproj", "ManageFood.Tests/"]

RUN dotnet restore "./ManageFood.API/ManageFood.API.csproj"
COPY . .
WORKDIR "/src/ManageFood.API"
RUN dotnet build "./ManageFood.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ManageFood.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ManageFood.API.dll"]
