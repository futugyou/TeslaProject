FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 5000

ENV HONEYCOMB__APIKEY=your_api_key_value2
ENV ASPNETCORE_URLS=http://+:5000

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["src/Web/TeslaApi.Web/TeslaApi.Web.csproj", "src/Web/TeslaApi.Web/"]
COPY ["Directory.Build.props", "./"]
COPY ["Directory.Packages.props", "./"]
RUN dotnet restore "src/Web/TeslaApi.Web/TeslaApi.Web.csproj"
COPY . .
WORKDIR "/src/src/Web/TeslaApi.Web"
RUN dotnet build "TeslaApi.Web.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "TeslaApi.Web.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TeslaApi.Web.dll"]
