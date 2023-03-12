#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 1080
EXPOSE 10443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Metrics.Demo.Api/Metrics.Demo.Api.csproj", "Metrics.Demo.Api/"]
RUN dotnet restore "Metrics.Demo.Api/Metrics.Demo.Api.csproj"
COPY . .
WORKDIR "/src/Metrics.Demo.Api"
RUN dotnet build "Metrics.Demo.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Metrics.Demo.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Metrics.Demo.Api.dll"]