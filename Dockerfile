#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["tienda-electronica-api-server.csproj", "."]
RUN dotnet restore "./tienda-electronica-api-server.csproj"
COPY . .
WORKDIR "/src/."

RUN dotnet build "tienda-electronica-api-server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "tienda-electronica-api-server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "tienda-electronica-api-server.dll"]