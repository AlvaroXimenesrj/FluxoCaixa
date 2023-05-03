FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["./FluxoCaixa.Transacao.Api/FluxoCaixa.Api.csproj", "src/FluxoCaixa.Transacao.Api/"]
COPY ["./FluxoCaixa.Core/FluxoCaixa.Core.csproj", "src/FluxoCaixa.Core/"]
RUN dotnet restore "src/FluxoCaixa.Transacao.Api/FluxoCaixa.Api.csproj"
COPY . .
WORKDIR "/src/FluxoCaixa.Transacao.Api"
RUN dotnet build "FluxoCaixa.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FluxoCaixa.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "FluxoCaixa.Api.dll"]