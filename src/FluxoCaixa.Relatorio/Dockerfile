FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["./FluxoCaixa.Relatorio/FluxoCaixa.Relatorio.csproj", "src/FluxoCaixa.Relatorio/"]
COPY ["./FluxoCaixa.Core/FluxoCaixa.Core.csproj", "src/FluxoCaixa.Core/"]
RUN dotnet restore "src/FluxoCaixa.Relatorio/FluxoCaixa.Relatorio.csproj"
COPY . .
WORKDIR "/src/FluxoCaixa.Relatorio"
RUN dotnet build "FluxoCaixa.Relatorio.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FluxoCaixa.Relatorio.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "FluxoCaixa.Relatorio.dll"]