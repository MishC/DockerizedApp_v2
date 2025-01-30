# Use official .NET runtime as base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# Use SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy everything and restore dependencies
COPY ["./TodosApi.csproj", "TodosApi/"]
WORKDIR "/src/TodosApi"
RUN dotnet restore

# Copy the entire project and publish
COPY . .
RUN dotnet publish -c Release -o /app/publish

# Final stage: Run the application
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

# Expose port (inside Docker network)
ENV ASPNETCORE_URLS=http://0.0.0.0:8080

# Start the application
ENTRYPOINT ["dotnet", "TodosApi.dll"]
