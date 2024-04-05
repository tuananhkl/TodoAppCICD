# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy csproj and restore as distinct layers
COPY ["Todolist.Mvc/Todolist.Mvc.csproj", "Todolist.Mvc/"]
RUN dotnet restore "Todolist.Mvc/Todolist.Mvc.csproj"

# Copy everything else and build the application
COPY . .
WORKDIR "/src/Todolist.Mvc"
RUN dotnet build "Todolist.Mvc.csproj" -c Release -o /app/build

# Stage 2: Publish the application
FROM build AS publish
RUN dotnet publish "Todolist.Mvc.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 3: Final image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Copy published files from previous stage
COPY --from=publish /app/publish .

# Set entry point for the application
ENTRYPOINT ["dotnet", "Todolist.Mvc.dll"]