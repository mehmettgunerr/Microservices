FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim as build
WORKDIR /app
EXPOSE 80
COPY Shared/MicroCloud.Shared/*.csproj Shared/MicroCloud.Shared/
COPY Services/Order/MicroCloud.Services.Order.Application/*.csproj Services/Order/MicroCloud.Services.Application/
COPY Services/Order/MicroCloud.Services.Order.Domain/*.csproj Services/Order/MicroCloud.Services.Domain/
COPY Services/Order/MicroCloud.Services.Order.Domain.Core/*.csproj Services/Order/MicroCloud.Services.Domain.Core/
COPY Services/Order/MicroCloud.Services.Order.Infrastructure/*.csproj Services/Order/MicroCloud.Services.Infrastructure/
COPY Services/Order/MicroCloud.Services.Order.API/*.csproj Services/Order/MicroCloud.Services.Order.API/
RUN dotnet restore Services/Order/MicroCloud.Services.Order.API/*.csproj
COPY . .
RUN dotnet publish Services/Order/MicroCloud.Services.Order.API/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","MicroCloud.Services.Order.API.dll" ]