# Этап для сборки
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Копируем файл .csproj и восстанавливаем зависимости
COPY SyncRazorForms.csproj ./
RUN dotnet restore

# Копируем все остальные файлы проекта
COPY . ./

# Строим проект
RUN dotnet build "SyncRazorForms.csproj" -c Release -o /app/build

# Этап для публикации
FROM build AS publish
RUN dotnet publish "SyncRazorForms.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Этап для финального образа
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Копируем опубликованные файлы в финальный образ
COPY --from=publish /app/publish .

# Указываем команду запуска
ENTRYPOINT ["dotnet", "SyncRazorForms.dll"]
