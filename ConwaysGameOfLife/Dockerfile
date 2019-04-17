FROM mcr.microsoft.com/dotnet/core/sdk:2.1.603-alpine3.9 AS build-env
WORKDIR /app

# Copy source code to container
COPY . ./

# Restore, Test and Publish
RUN dotnet restore
RUN dotnet test ./Ozow.GameOfLife.Tests
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-alpine3.9
WORKDIR /app
COPY --from=build-env /app/Ozow.GameOfLife.Web/out/ .
ENTRYPOINT ["dotnet", "Ozow.GameOfLife.Web.dll"]
