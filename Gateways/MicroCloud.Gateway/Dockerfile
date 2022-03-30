FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim as build
WORKDIR /app
EXPOSE 80
COPY Gateways/MicroCloud.Gateway/*.csproj Gateways/MicroCloud.Gateway/
RUN dotnet restore Gateways/MicroCloud.Gateway/*.csproj
COPY . .
RUN dotnet publish Gateways/MicroCloud.Gateway/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","MicroCloud.Gateway.dll" ]