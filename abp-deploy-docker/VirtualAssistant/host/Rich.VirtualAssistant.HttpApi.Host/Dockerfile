#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["NuGet.Config", "."]
COPY ["host/Rich.VirtualAssistant.HttpApi.Host/Rich.VirtualAssistant.HttpApi.Host.csproj", "host/Rich.VirtualAssistant.HttpApi.Host/"]
COPY ["src/Rich.VirtualAssistant.HttpApi/Rich.VirtualAssistant.HttpApi.csproj", "src/Rich.VirtualAssistant.HttpApi/"]
COPY ["src/Rich.VirtualAssistant.Application.Contracts/Rich.VirtualAssistant.Application.Contracts.csproj", "src/Rich.VirtualAssistant.Application.Contracts/"]
COPY ["src/Rich.VirtualAssistant.Domain.Shared/Rich.VirtualAssistant.Domain.Shared.csproj", "src/Rich.VirtualAssistant.Domain.Shared/"]
COPY ["src/Rich.VirtualAssistant.Application/Rich.VirtualAssistant.Application.csproj", "src/Rich.VirtualAssistant.Application/"]
COPY ["src/Rich.VirtualAssistant.Domain/Rich.VirtualAssistant.Domain.csproj", "src/Rich.VirtualAssistant.Domain/"]
COPY ["src/Rich.VirtualAssistant.EntityFrameworkCore/Rich.VirtualAssistant.EntityFrameworkCore.csproj", "src/Rich.VirtualAssistant.EntityFrameworkCore/"]
COPY ["host/Rich.VirtualAssistant.Host.Shared/Rich.VirtualAssistant.Host.Shared.csproj", "host/Rich.VirtualAssistant.Host.Shared/"]
RUN dotnet restore "host/Rich.VirtualAssistant.HttpApi.Host/Rich.VirtualAssistant.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/host/Rich.VirtualAssistant.HttpApi.Host"
RUN dotnet dev-certs https --clean
RUN dotnet dev-certs https -t
RUN dotnet build "Rich.VirtualAssistant.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Rich.VirtualAssistant.HttpApi.Host.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Rich.VirtualAssistant.HttpApi.Host.dll"]