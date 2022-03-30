FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim as build
WORKDIR /app
EXPOSE 80
COPY Shared/MicroCloud.Shared/*.csproj Shared/MicroCloud.Shared/
COPY Services/FakePayment/MicroCloud.Services.FakePayment/*.csproj Services/FakePayment/MicroCloud.Services.FakePayment/
RUN dotnet restore Services/FakePayment/MicroCloud.Services.FakePayment/*.csproj
COPY . .
RUN dotnet publish Services/FakePayment/MicroCloud.Services.FakePayment/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","MicroCloud.Services.FakePayment.dll" ]