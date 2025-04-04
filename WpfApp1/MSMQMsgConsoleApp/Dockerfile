# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy project files and restore dependencies
COPY ["TMSMQMsgConsoleApp.csproj", "./"]
RUN dotnet restore "TMSMQMsgConsoleApp.csproj"

# Copy all source files and build
COPY . .
RUN dotnet build "TMSMQMsgConsoleApp.csproj" -c Release -o /app/build

# Publish application
RUN dotnet publish "TMSMQMsgConsoleApp.csproj" -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS runtime
WORKDIR /app

# Copy published files from the build stage
COPY --from=build /app/publish .
#COPY . .

# Set the entry point
ENTRYPOINT ["dotnet", "TMSMQMsgConsoleApp.dll"]