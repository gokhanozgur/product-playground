#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0-preview AS base
WORKDIR /app
EXPOSE 5010
EXPOSE 5011

FROM mcr.microsoft.com/dotnet/sdk:8.0-preview AS build
WORKDIR /src
COPY ["Presentation/ProductPlayground.Api/ProductPlayground.Api.csproj", "Presentation/ProductPlayground.Api/"]
COPY ["Infrastructure/ProductPlayground.Persistence/ProductPlayground.Persistence.csproj", "Infrastructure/ProductPlayground.Persistence/"]
COPY ["Core/ProductPlayground.Domain/ProductPlayground.Domain.csproj", "Core/ProductPlayground.Domain/"]
RUN dotnet restore "Presentation/ProductPlayground.Api/ProductPlayground.Api.csproj"
COPY . .
WORKDIR "/src/Presentation/ProductPlayground.Api"
RUN dotnet build "ProductPlayground.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProductPlayground.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductPlayground.Api.dll"]
