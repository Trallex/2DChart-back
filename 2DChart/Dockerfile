FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["2DChart.csproj", "2DChart/"]
RUN dotnet restore "2DChart/2DChart.csproj"
COPY . 2DChart/
WORKDIR "/src/2DChart"
RUN dotnet build "2DChart.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "2DChart.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet 2DChart.dll
# ENTRYPOINT ["dotnet", "2DChart.dll"]