#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["OnlineShop/OnlineShop.csproj", "OnlineShop/"]
COPY ["OnlineShop.Infrastructore/OnlineShop.Infrastructore.csproj", "OnlineShop.Infrastructore/"]
COPY ["OnlineShop.Infrastructure.Abstractions/OnlineShop.Infrastructure.Abstractions.csproj", "OnlineShop.Infrastructure.Abstractions/"]
COPY ["OnlineShop.Domain/OnlineShop.Domain.csproj", "OnlineShop.Domain/"]
COPY ["OnlineShop.Infrastructure.DataAccess/OnlineShop.Infrastructure.DataAccess.csproj", "OnlineShop.Infrastructure.DataAccess/"]
COPY ["OnlineShop.UseCases/OnlineShop.UseCases.csproj", "OnlineShop.UseCases/"]
COPY ["OnlineShop.Infrastructure.Common/OnlineShop.Infrastructure.Common.csproj", "OnlineShop.Infrastructure.Common/"]
COPY ["OnlineShop.UseCases.Shared/OnlineShop.UseCases.Shared.csproj", "OnlineShop.UseCases.Shared/"]
RUN dotnet restore "OnlineShop/OnlineShop.csproj"
COPY . .
WORKDIR "/src/OnlineShop"
RUN dotnet build "OnlineShop.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OnlineShop.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OnlineShop.dll"]