#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://*:8080

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ProjectAPI00001.csproj", "./"]
RUN dotnet restore "./ProjectAPI00001.csproj"
COPY . .
WORKDIR /src/.
RUN dotnet build "ProjectAPI00001.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProjectAPI00001.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProjectAPI00001.dll"]