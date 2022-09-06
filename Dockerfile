# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS tpt-backend-prod-build
WORKDIR /app

COPY ./tpt-backend.sln ./
COPY ./Application/Application.csproj ./Application/
COPY ./Domain/Domain.csproj ./Domain/
COPY ./Infrastructure/Infrastructure.csproj ./Infrastructure/
COPY ./Persistence/Persistence.csproj ./Persistence/
COPY ./API/API.csproj ./API/
COPY ./DataView/DataView.csproj ./DataView/

RUN dotnet restore

COPY . .

# Build project
WORKDIR /app/API
RUN dotnet publish -c Release -o out


# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS tpt-backend-prod
WORKDIR /app/
EXPOSE 5005
COPY --from=tpt-backend-prod-build /app/API/out .
ENTRYPOINT ["dotnet", "API.dll"]