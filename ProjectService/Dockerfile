# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY ProjectService/*.csproj ./ProjectService/
RUN dotnet restore ./ProjectService/ProjectService.csproj

# Copy all files
COPY . .
RUN dotnet publish ./ProjectService/ProjectService.csproj -c Release -o /app

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .
EXPOSE 80
ENTRYPOINT ["dotnet", "ProjectService.dll"]