FROM mcr.microsoft.com/dotnet/core/sdk:2.1.603-alpine3.9 AS build-env
WORKDIR /app

# Copy source code to container
COPY . ./

# Restore, Test and Publish
RUN dotnet restore
RUN dotnet test ./Ozow.Sorting.Tests
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/runtime:2.1-alpine3.9
WORKDIR /app
COPY --from=build-env  /app/Ozow.Sorting.Console/out .
ENTRYPOINT ["dotnet", "/app/Ozow.Sorting.Console.dll"]