# Use the official .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the solution file and restore dependencies
COPY *.sln ./
COPY SchoolworkOrganizerServer/SchoolworkOrganizerServer.csproj SchoolworkOrganizerServer/
COPY SchoolworkOrganizerUtils/SchoolworkOrganizerUtils.csproj SchoolworkOrganizerUtils/
COPY SchoolworkOrganizer/SchoolworkOrganizer.csproj SchoolworkOrganizer/
COPY Tester/Tester.csproj Tester/
RUN dotnet restore /p:EnableWindowsTargeting=true

# Copy the remaining source code and publish the application
COPY . .
WORKDIR /src/SchoolworkOrganizerServer
RUN dotnet publish -c Release -o /app/publish /p:EnableWindowsTargeting=true

# Use the official .NET runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "SchoolworkOrganizerServer.dll"]