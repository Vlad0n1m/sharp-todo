# Use the .NET SDK for building the application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy solution and restore dependencies
COPY ProductionReadyArrayListAPI.sln ./
COPY Project.Api/Project.Api.csproj Project.Api/
COPY Project.Domain/Project.Domain.csproj Project.Domain/
COPY Project.Infrastructure/Project.Infrastructure.csproj Project.Infrastructure/
COPY ProductionReadyArrayListAPI/ProductionReadyArrayListAPI.csproj ProductionReadyArrayListAPI/
COPY Project.tests/Project.tests.csproj Project.tests/
RUN dotnet restore

# Copy the entire project and build it
COPY . .
RUN dotnet publish Project.Api -c Release -o /out

# Use the ASP.NET Core runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /out .

EXPOSE 5208
EXPOSE 5209

# Start the application
ENTRYPOINT ["dotnet", "Project.Api.dll"]
