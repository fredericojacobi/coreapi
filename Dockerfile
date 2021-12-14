#FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
#WORKDIR /src
#COPY Api.csproj .
#RUN dotnet restore
#COPY . .
#RUN dotnet publish -c release -o /app
#
#FROM mcr.microsoft.com/dotnet/aspnet:5.0
#WORKDIR /app
#COPY --from=build /app .
#ENTRYPOINT ["dotnet", "Api.dll"]

#FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
#WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore 
RUN dotnet build --no-restore -c Release -o /app

FROM build AS publish
RUN dotnet publish --no-restore -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
# Padrão de container ASP.NET
ENTRYPOINT ["dotnet", "api.dll"]
# Opção utilizada pelo Heroku
#CMD ASPNETCORE_URLS=http://*:$PORT dotnet firstapp.dll
