#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Microservices/Banking/Banking.Api/Banking.Api.csproj", "src/Microservices/Banking/Banking.Api/"]
COPY ["src/Core/Infrastructure.IoC/Infrastructure.IoC.csproj", "src/Core/Infrastructure.IoC/"]
COPY ["src/Microservices/Transfer/Transfer.Data/Transfer.Data.csproj", "src/Microservices/Transfer/Transfer.Data/"]
COPY ["src/Microservices/Transfer/Transfer.Domain/Transfer.Domain.csproj", "src/Microservices/Transfer/Transfer.Domain/"]
COPY ["src/Core/Domain.Core/Domain.Core.csproj", "src/Core/Domain.Core/"]
COPY ["src/Microservices/Banking/Banking.Application/Banking.Application.csproj", "src/Microservices/Banking/Banking.Application/"]
COPY ["src/Microservices/Banking/Banking.Domain/Banking.Domain.csproj", "src/Microservices/Banking/Banking.Domain/"]
COPY ["src/Core/Infrastructure.Bus/Infrastructure.Bus.csproj", "src/Core/Infrastructure.Bus/"]
COPY ["src/Microservices/Banking/Banking.Data/Banking.Data.csproj", "src/Microservices/Banking/Banking.Data/"]
COPY ["src/Microservices/Transfer/Transfer.Application/Transfer.Application.csproj", "src/Microservices/Transfer/Transfer.Application/"]
RUN dotnet restore "src/Microservices/Banking/Banking.Api/Banking.Api.csproj"
COPY . .
WORKDIR "/src/src/Microservices/Banking/Banking.Api"
RUN dotnet build "Banking.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Banking.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Banking.Api.dll"]