# ===== BUILD STAGE =====
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY TaskManager/TaskManager.csproj TaskManager/
RUN dotnet restore TaskManager/TaskManager.csproj

COPY . .
WORKDIR /src/TaskManager
RUN dotnet publish -c Release -o /app/publish

# ===== RUNTIME STAGE =====
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "TaskManager.dll"]
