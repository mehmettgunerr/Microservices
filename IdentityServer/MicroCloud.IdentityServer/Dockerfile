FROM mcr.microsoft.com/dotnet/sdk:3.1 as build
WORKDIR /app
EXPOSE 80
COPY Shared/MicroCloud.Shared/*.csproj Shared/MicroCloud.Shared/
COPY IdentityServer/MicroCloud.IdentityServer/*.csproj IdentityServer/MicroCloud.IdentityServer/
RUN dotnet restore IdentityServer/MicroCloud.IdentityServer/*.csproj
COPY . .
RUN dotnet publish IdentityServer/MicroCloud.IdentityServer/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:3.1 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","MicroCloud.IdentityServer.dll" ]