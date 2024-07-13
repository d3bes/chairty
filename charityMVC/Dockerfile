# Stage 1: Build and publish the ASP.NET Core application
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src

# Copy the project file and restore dependencies
COPY charityMVC.csproj .
RUN dotnet restore

# Copy the entire solution and build the application
COPY . .
RUN dotnet publish -c release -o /app

# Stage 2: Set up EF Core tools and update database schema
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS ef-tools

# Install EF Core tools globally
RUN dotnet tool install --global dotnet-ef --version 7.0.0
ENV PATH="${PATH}:/root/.dotnet/tools"

# Copy published application from previous stage
COPY --from=build /app /app
WORKDIR /app

# Execute EF Core database migrations
RUN dotnet ef database update --project charityMVC.csproj --startup-project charityMVC.csproj --context Context

# Stage 3: Create final runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0

WORKDIR /app
EXPOSE 80

# Copy published application from previous stage
COPY --from=ef-tools /app .

# Define entry point for the container
ENTRYPOINT ["dotnet", "charityMVC.dll"]
