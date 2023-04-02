#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src
COPY ["AdvertService/AdvertService.csproj", "AdvertService/"]
RUN dotnet restore "AdvertService/AdvertService.csproj"
COPY . .
WORKDIR "/src/AdvertService"
RUN dotnet build "AdvertService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AdvertService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final

ENV \
    DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false \
    LC_ALL=en_US.UTF-8 \
    LANG=en_US.UTF-8
RUN apk add --no-cache \
    icu-data-full \
    icu-libs

WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS http://*:8080
ENTRYPOINT ["dotnet", "AdvertService.dll"]