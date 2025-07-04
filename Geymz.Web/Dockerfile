FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0@sha256:35792ea4ad1db051981f62b313f1be3b46b1f45cadbaa3c288cd0d3056eefb83 AS build
WORKDIR /src
COPY ["Geymz.Web/Geymz.Web.csproj", "Geymz.Web/"]
RUN dotnet restore "Geymz.Web/Geymz.Web.csproj"
COPY . .
WORKDIR "/src/Geymz.Web"
RUN dotnet build "Geymz.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Geymz.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Geymz.Web.dll"]