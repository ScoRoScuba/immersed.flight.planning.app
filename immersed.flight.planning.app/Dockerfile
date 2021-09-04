#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["immsered.flight.planning.app/immsered.flight.planning.app.csproj", "immsered.flight.planning.app/"]
RUN dotnet restore "immsered.flight.planning.app/immsered.flight.planning.app.csproj"
COPY . .
WORKDIR "/src/immsered.flight.planning.app"
RUN dotnet build "immsered.flight.planning.app.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "immsered.flight.planning.app.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "immsered.flight.planning.app.dll"]