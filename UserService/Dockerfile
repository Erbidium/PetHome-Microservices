FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["UserService.WebAPI/UserService.WebAPI.csproj", "UserService.WebAPI/"]
RUN dotnet restore "UserService.WebAPI/UserService.WebAPI.csproj"
COPY . .
WORKDIR "/src/UserService.WebAPI"
RUN dotnet build "UserService.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserService.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS http://*:8080
ENTRYPOINT ["dotnet", "UserService.WebAPI.dll"]
