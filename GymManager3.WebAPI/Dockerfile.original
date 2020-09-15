#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-nanoserver-1903 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-nanoserver-1903 AS build
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
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GymManager3.WebAPI.dll"]