#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["GymManager3.WebAPI/GymManager3.WebAPI.csproj", "GymManager3.WebAPI/"]
COPY ["GymManager3.Model/GymManager3.Model.csproj", "GymManager3.Model/"]
RUN dotnet restore "GymManager3.WebAPI/GymManager3.WebAPI.csproj"
COPY . .
WORKDIR "/src/GymManager3.WebAPI"
RUN dotnet build "GymManager3.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GymManager3.WebAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ADD GymManager3.WebAPI/img img/

ENTRYPOINT ["dotnet", "GymManager3.WebAPI.dll"]