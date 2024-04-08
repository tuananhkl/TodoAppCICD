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

# Set environment variables for connecting to SQL Server
ENV ConnectionStrings__DefaultConnection "Server=192.168.31.84:1443;Database=git ad;User=sa;Password=Tuananh123.;"

# Set entry point for the application
ENTRYPOINT ["dotnet", "Todolist.Mvc.dll"]

#https://chat.openai.com/c/400363ff-a506-47b8-88fb-60c8010bd527
