# Configure timezone
#RUN unlink /etc/localtime
#RUN ln -s /usr/share/zoneinfo/Brazil/East /etc/localtime

#FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
#USER app
#WORKDIR /app

#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#ARG BUILD_CONFIGURATION=Release
#WORKDIR /src
#COPY ["src/SqlServerClient/SqlServerClient.csproj", "src/SqlServerClient/"]
#RUN dotnet restore "./src/SqlServerClient/SqlServerClient.csproj"
#COPY . .
#WORKDIR "/src/src/SqlServerClient"
#RUN dotnet build "./SqlServerClient.csproj" -c $BUILD_CONFIGURATION -o /app/build

#FROM build AS publish
#ARG BUILD_CONFIGURATION=Release
#RUN dotnet publish "./SqlServerClient.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "SqlServerClient.dll"]



# Use the official .NET Core SDK image as the base image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the .csproj and restore as distinct layers
COPY ["SqlServerClient/SqlServerClient.csproj", "./"]
RUN dotnet restore "SqlServerClient.csproj"

# Copy the remaining source code and build the application
COPY . .
WORKDIR "/src/."
RUN dotnet build "SqlServerClient.csproj" -c Release -o /app/build

# Build the runtime image
FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /app
COPY --from=build /app/out .

# Entry point when the container starts
ENTRYPOINT ["dotnet", "SqlServerClient.dll"]

