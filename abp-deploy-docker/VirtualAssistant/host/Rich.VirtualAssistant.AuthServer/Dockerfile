#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["NuGet.Config", "."]
COPY ["host/Rich.VirtualAssistant.AuthServer/Rich.VirtualAssistant.AuthServer.csproj", "host/Rich.VirtualAssistant.AuthServer/"]
COPY ["src/Rich.VirtualAssistant.Application.Contracts/Rich.VirtualAssistant.Application.Contracts.csproj", "src/Rich.VirtualAssistant.Application.Contracts/"]
COPY ["src/Rich.VirtualAssistant.Domain.Shared/Rich.VirtualAssistant.Domain.Shared.csproj", "src/Rich.VirtualAssistant.Domain.Shared/"]
COPY ["host/Rich.VirtualAssistant.Host.Shared/Rich.VirtualAssistant.Host.Shared.csproj", "host/Rich.VirtualAssistant.Host.Shared/"]
RUN dotnet restore "host/Rich.VirtualAssistant.AuthServer/Rich.VirtualAssistant.AuthServer.csproj"
COPY . .
WORKDIR "/src/host/Rich.VirtualAssistant.AuthServer"
RUN dotnet build "Rich.VirtualAssistant.AuthServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Rich.VirtualAssistant.AuthServer.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Rich.VirtualAssistant.AuthServer.dll"]