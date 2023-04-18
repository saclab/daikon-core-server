# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS daikon_core_server_ce-build
WORKDIR /app

COPY ./tpt-backend.sln ./
COPY ./Application/Application.csproj ./Application/
COPY ./Domain/Domain.csproj ./Domain/
COPY ./Infrastructure/Infrastructure.csproj ./Infrastructure/
COPY ./Persistence/Persistence.csproj ./Persistence/
COPY ./API/API.csproj ./API/
COPY ./DataView/DataView.csproj ./DataView/
COPY ./Adapter/Adapter.csproj ./Adapter/

RUN dotnet restore

COPY . .

# Build project
WORKDIR /app/API
RUN dotnet publish -c Release -o out


# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS daikon_core_server_ce
WORKDIR /daikon-server/
EXPOSE 5005
COPY ./Data /app/Data/
COPY --from=daikon_core_server_ce-build /app/API/out .
ENTRYPOINT ["dotnet", "API.dll"]