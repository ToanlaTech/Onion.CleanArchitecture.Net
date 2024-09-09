#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["kscl.backend.toananhle/kscl.backend.toananhle.Worker.Employee/kscl.backend.toananhle.Worker.Employee.csproj", "kscl.backend.toananhle/kscl.backend.toananhle.Worker.Employee/"]
COPY ["kscl.backend.toananhle/kscl.backend.toananhle.CoreWorker/kscl.backend.toananhle.CoreWorker.csproj", "kscl.backend.toananhle/kscl.backend.toananhle.CoreWorker/"]
RUN dotnet restore "kscl.backend.toananhle/kscl.backend.toananhle.Worker.Employee/kscl.backend.toananhle.Worker.Employee.csproj"
COPY . .
WORKDIR "/src/kscl.backend.toananhle/kscl.backend.toananhle.Worker.Employee"
RUN dotnet build "kscl.backend.toananhle.Worker.Employee.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "kscl.backend.toananhle.Worker.Employee.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "kscl.backend.toananhle.Worker.Employee.dll"]