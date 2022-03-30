FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim as build
WORKDIR /app
EXPOSE 80
COPY Shared/MicroCloud.Shared/*.csproj Shared/MicroCloud.Shared/
COPY Services/Catalog/MicroCloud.Services.Catalog/*.csproj Services/Catalog/MicroCloud.Services.Catalog/
RUN dotnet restore Services/Catalog/MicroCloud.Services.Catalog/*.csproj
COPY . .
RUN dotnet publish Services/Catalog/MicroCloud.Services.Catalog/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","MicroCloud.Services.Catalog.dll" ]