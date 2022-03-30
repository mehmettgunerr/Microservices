FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim as build
WORKDIR /app
EXPOSE 80
COPY Shared/MicroCloud.Shared/*.csproj Shared/MicroCloud.Shared/
COPY Services/Basket/MicroCloud.Services.Basket/*.csproj Services/Basket/MicroCloud.Services.Basket/
RUN dotnet restore Services/Basket/MicroCloud.Services.Basket/*.csproj
COPY . .
RUN dotnet publish Services/Basket/MicroCloud.Services.Basket/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","MicroCloud.Services.Basket.dll" ]