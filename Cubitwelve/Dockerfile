
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /App


COPY . ./


RUN dotnet restore

RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /App


COPY --from=build-env /App/out .

COPY --from=build-env /App/Src/Data/DataSeeders ./Src/Data/DataSeeders

ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

ENTRYPOINT ["dotnet", "Cubitwelve.dll"]