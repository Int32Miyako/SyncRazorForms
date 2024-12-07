# Use .NET runtime as a base image for running the application
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use the .NET SDK for building the application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SyncRazorForms/SyncRazorForms.csproj", "SyncRazorForms/"]
RUN dotnet restore "SyncRazorForms/SyncRazorForms.csproj"

COPY . .
WORKDIR "/src/SyncRazorForms"
RUN dotnet build "SyncRazorForms.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "SyncRazorForms.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final image for running the application
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SyncRazorForms.dll"]
