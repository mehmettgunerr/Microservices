FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim as build
WORKDIR /app
EXPOSE 80
COPY Shared/MicroCloud.Shared/*.csproj Shared/MicroCloud.Shared/
COPY Frontends/MicroCloud.Web/*.csproj Frontends/MicroCloud.Web/
RUN dotnet restore Frontends/MicroCloud.Web/*.csproj
COPY . .
RUN dotnet publish Frontends/MicroCloud.Web/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","MicroCloud.Web.dll" ]