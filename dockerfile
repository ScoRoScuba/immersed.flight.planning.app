FROM mcr.microsoft.com/dotnet/sdk:5.0 as build-env
WORKDIR /app

COPY ./src ./
RUN dotnet restore ./immersed.flight.planning.app.sln

COPY . ./
RUN dotnet test immersed.flight.planning.tests -c Release
RUN dotnet publish ./immersed.flight.planning.app.sln -c Release -o output

FROM mcr.microsoft.com/dotnet/runtime:5.0
WORKDIR /app
COPY --from=build-env /app/output .

ENTRYPOINT ["dotnet", "immersed.flight.planning.app.dll"]