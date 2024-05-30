#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AcmeCorp.CustomerManagement.Api/AcmeCorp.CustomerManagement.API.csproj", "AcmeCorp.CustomerManagement.Api/"]
COPY ["AcmeCorp.CustomerManagement/AcmeCorp.CustomerManagement.csproj", "AcmeCorp.CustomerManagement/"]
COPY ["AcmeCorp.Core/AcmeCorp.Core.csproj", "AcmeCorp.Core/"]
RUN dotnet restore "./AcmeCorp.CustomerManagement.Api/AcmeCorp.CustomerManagement.API.csproj"
COPY . .
WORKDIR "/src/AcmeCorp.CustomerManagement.Api"
RUN dotnet build "./AcmeCorp.CustomerManagement.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AcmeCorp.CustomerManagement.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AcmeCorp.CustomerManagement.API.dll"]