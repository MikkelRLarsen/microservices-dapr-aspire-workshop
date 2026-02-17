# ----------------------------
# Base image til runtime
# ----------------------------
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080
USER $APP_UID

# ----------------------------
# Build stage
# ----------------------------
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Kopier csproj-filer for at gøre restore mere cache-venlig
COPY ["./PizzaOrder.csproj", "PizzaOrder/"]
COPY ["../DaprWorkshop.ServiceDefaults\DaprWorkshop.ServiceDefaults.csproj", "DaprWorkshop.ServiceDefaults/"]

# Restore dependencies
RUN dotnet restore "./PizzaOrder.csproj"

# Kopier resten af koden
COPY . .

# Skift til projektmappe
WORKDIR "/src/PizzaOrder"

# Build
RUN dotnet build "PizzaOrder.csproj" -c $BUILD_CONFIGURATION -o /app/build

# ----------------------------
# Publish stage
# ----------------------------
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "PizzaOrder.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# ----------------------------
# Final image
# ----------------------------
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PizzaOrder.dll"]
