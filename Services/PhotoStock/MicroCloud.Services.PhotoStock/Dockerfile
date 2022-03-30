FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim as build
WORKDIR /app
EXPOSE 80
COPY Shared/MicroCloud.Shared/*.csproj Shared/MicroCloud.Shared/
COPY Services/PhotoStock/MicroCloud.Services.PhotoStock/*.csproj Services/PhotoStock/MicroCloud.Services.PhotoStock/
RUN dotnet restore Services/PhotoStock/MicroCloud.Services.PhotoStock/*.csproj
COPY . .
RUN dotnet publish Services/PhotoStock/MicroCloud.Services.PhotoStock/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","MicroCloud.Services.PhotoStock.dll" ]