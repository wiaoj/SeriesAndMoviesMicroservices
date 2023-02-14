#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0.0-alpine3.16 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0.0-alpine3.16 AS build
WORKDIR /src
COPY ["src/Services/CategoryService/CategoryService.WebAPI/CategoryService.WebAPI.csproj", "src/Services/CategoryService/CategoryService.WebAPI/"]
COPY ["src/Services/CategoryService/CategoryService.Application/CategoryService.Application.csproj", "src/Services/CategoryService/CategoryService.Application/"]
COPY ["src/BuildingBlocks/Core/BuildingBlocks.Core.Abstractions/BuildingBlocks.Core.Abstractions.csproj", "src/BuildingBlocks/Core/BuildingBlocks.Core.Abstractions/"]
COPY ["src/BuildingBlocks/Core/BuildingBlocks.Core.Application/BuildingBlocks.Core.Application.csproj", "src/BuildingBlocks/Core/BuildingBlocks.Core.Application/"]
COPY ["src/BuildingBlocks/EventBus/EventBus.Base/EventBus.Base.csproj", "src/BuildingBlocks/EventBus/EventBus.Base/"]
COPY ["src/BuildingBlocks/EventBus/EventBus.Factory/EventBus.Factory.csproj", "src/BuildingBlocks/EventBus/EventBus.Factory/"]
COPY ["src/BuildingBlocks/EventBus/EventBus.AzureServiceBus/EventBus.AzureServiceBus.csproj", "src/BuildingBlocks/EventBus/EventBus.AzureServiceBus/"]
COPY ["src/BuildingBlocks/EventBus/EventBus.RabbitMQ/EventBus.RabbitMQ.csproj", "src/BuildingBlocks/EventBus/EventBus.RabbitMQ/"]
COPY ["src/Services/CategoryService/CategoryService.Contracts/CategoryService.Contracts.csproj", "src/Services/CategoryService/CategoryService.Contracts/"]
COPY ["src/Services/CategoryService/CategoryService.Domain/CategoryService.Domain.csproj", "src/Services/CategoryService/CategoryService.Domain/"]
COPY ["src/BuildingBlocks/Core/BuildingBlocks.Core.Domain/BuildingBlocks.Core.Domain.csproj", "src/BuildingBlocks/Core/BuildingBlocks.Core.Domain/"]
COPY ["src/BuildingBlocks/Core/BuildingBlocks.Core.Exceptions/BuildingBlocks.Core.Exceptions.csproj", "src/BuildingBlocks/Core/BuildingBlocks.Core.Exceptions/"]
COPY ["src/Services/CategoryService/CategoryService.Infrastructure/CategoryService.Infrastructure.csproj", "src/Services/CategoryService/CategoryService.Infrastructure/"]
COPY ["src/Services/CategoryService/CategoryService.Persistence/CategoryService.Persistence.csproj", "src/Services/CategoryService/CategoryService.Persistence/"]
COPY ["src/BuildingBlocks/Core/BuildingBlocks.Core.Persistence/BuildingBlocks.Core.Persistence.csproj", "src/BuildingBlocks/Core/BuildingBlocks.Core.Persistence/"]
RUN dotnet restore "src/Services/CategoryService/CategoryService.WebAPI/CategoryService.WebAPI.csproj"
COPY . .
WORKDIR "/src/src/Services/CategoryService/CategoryService.WebAPI"
RUN dotnet build "CategoryService.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CategoryService.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CategoryService.WebAPI.dll"]