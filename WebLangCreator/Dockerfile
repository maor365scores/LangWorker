FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["WebLangCreator/WebLangCreator.csproj", "WebLangCreator/"]
RUN dotnet restore "WebLangCreator/WebLangCreator.csproj"
COPY . .
WORKDIR "/src/WebLangCreator"
RUN dotnet build "WebLangCreator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebLangCreator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebLangCreator.dll"]
