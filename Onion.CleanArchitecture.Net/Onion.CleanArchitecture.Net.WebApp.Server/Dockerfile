#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Onion.CleanArchitecture.Net/Onion.CleanArchitecture.Net.WebApp.Client/nuget.config", "Onion.CleanArchitecture.Net/Onion.CleanArchitecture.Net.WebApp.Client/"]
COPY ["Onion.CleanArchitecture.Net/Onion.CleanArchitecture.Net.WebApp.Server/Onion.CleanArchitecture.Net.WebApp.Server.csproj", "Onion.CleanArchitecture.Net/Onion.CleanArchitecture.Net.WebApp.Server/"]
COPY ["Onion.CleanArchitecture.Net/Onion.CleanArchitecture.Net.Infrastructure.Identity/Onion.CleanArchitecture.Net.Infrastructure.Identity.csproj", "Onion.CleanArchitecture.Net/Onion.CleanArchitecture.Net.Infrastructure.Identity/"]
COPY ["Onion.CleanArchitecture.Net/Onion.CleanArchitecture.Net.Infrastructure.Shared/Onion.CleanArchitecture.Net.Infrastructure.Shared.csproj", "Onion.CleanArchitecture.Net/Onion.CleanArchitecture.Net.Infrastructure.Shared/"]
COPY ["Onion.CleanArchitecture.Net/Onion.CleanArchitecture.Net.Application/Onion.CleanArchitecture.Net.Application.csproj", "Onion.CleanArchitecture.Net/Onion.CleanArchitecture.Net.Application/"]
COPY ["Onion.CleanArchitecture.Net/Onion.CleanArchitecture.Net.Domain/Onion.CleanArchitecture.Net.Domain.csproj", "Onion.CleanArchitecture.Net/Onion.CleanArchitecture.Net.Domain/"]
COPY ["Onion.CleanArchitecture.Net/Onion.CleanArchitecture.Net.Infrastructure.Persistence/Onion.CleanArchitecture.Net.Infrastructure.Persistence.csproj", "Onion.CleanArchitecture.Net/Onion.CleanArchitecture.Net.Infrastructure.Persistence/"]
COPY ["Onion.CleanArchitecture.Net/Onion.CleanArchitecture.Net.WebApp.Client/Onion.CleanArchitecture.Net.WebApp.Client.esproj", "Onion.CleanArchitecture.Net/Onion.CleanArchitecture.Net.WebApp.Client/"]
RUN curl -fsSL https://deb.nodesource.com/setup_18.x | bash -
RUN apt install -y nodejs
RUN dotnet restore "./Onion.CleanArchitecture.Net/Onion.CleanArchitecture.Net.WebApp.Server/Onion.CleanArchitecture.Net.WebApp.Server.csproj"
COPY . .
WORKDIR "/src/Onion.CleanArchitecture.Net/Onion.CleanArchitecture.Net.WebApp.Server"
RUN dotnet build "./Onion.CleanArchitecture.Net.WebApp.Server.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Onion.CleanArchitecture.Net.WebApp.Server.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Onion.CleanArchitecture.Net.WebApp.Server.dll"]