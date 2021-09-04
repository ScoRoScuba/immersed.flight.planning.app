FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 as build-env
WORKDIR /app
COPY ./src ./
RUN dotnet restore ./immersed.flight.planning.app.sln
COPY . .
RUN dotnet test immersed.flight.planning.tests -c Release

from build-env AS publish
RUN dotnet publish ./immersed.flight.planning.app.sln -c Release -o /app/publish

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "immersed.flight.planning.app.dll"]
