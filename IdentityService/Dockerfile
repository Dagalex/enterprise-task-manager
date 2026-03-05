# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY IdentityService/*.csproj ./IdentityService/
RUN dotnet restore ./IdentityService/IdentityService.csproj

# Copy all files
COPY . .
RUN dotnet publish ./IdentityService/IdentityService.csproj -c Release -o /app

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .
EXPOSE 80
ENTRYPOINT ["dotnet", "IdentityService.dll"]