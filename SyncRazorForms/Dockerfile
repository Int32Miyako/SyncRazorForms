FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SyncRazorForms/SyncRazorForms.csproj", "./"]
RUN dotnet restore "SyncRazorForms.csproj"

COPY SyncRazorForms ./SyncRazorForms
WORKDIR /src/SyncRazorForms
RUN dotnet build "SyncRazorForms.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SyncRazorForms.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SyncRazorForms.dll"]
