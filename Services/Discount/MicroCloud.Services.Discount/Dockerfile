FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim as build
WORKDIR /app
EXPOSE 80
COPY Shared/MicroCloud.Shared/*.csproj Shared/MicroCloud.Shared/
COPY Services/Discount/MicroCloud.Services.Discount/*.csproj Services/Discount/MicroCloud.Services.Discount/
RUN dotnet restore Services/Discount/MicroCloud.Services.Discount/*.csproj
COPY . .
RUN dotnet publish Services/Discount/MicroCloud.Services.Discount/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","MicroCloud.Services.Discount.dll" ]