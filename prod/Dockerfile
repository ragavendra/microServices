FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS build
ADD . /src
WORKDIR /src
COPY prod.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "prod.dll"]
