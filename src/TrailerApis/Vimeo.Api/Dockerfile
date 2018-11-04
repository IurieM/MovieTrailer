FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 5001

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["src/TrailerApis/Vimeo.Api/Vimeo.Api.csproj", "src/TrailerApis/Vimeo.Api/"]
COPY ["src/BuildingBlocks/Block.Api/Block.Api.csproj", "src/BuildingBlocks/Block.Api/"]
COPY ["src/BuildingBlocks/Block.BackgroudService/Block.BackgroudService.csproj", "src/BuildingBlocks/Block.BackgroudService/"]
COPY ["src/Movie.Data/Movie.Data.csproj", "src/Movie.Data/"]
COPY ["src/BuildingBlocks/Block.Htttp/Block.Http.csproj", "src/BuildingBlocks/Block.Htttp/"]
COPY ["src/Movie.Common/Movie.Common.csproj", "src/Movie.Common/"]
RUN dotnet restore "src/TrailerApis/Vimeo.Api/Vimeo.Api.csproj"
COPY . .
WORKDIR "/src/src/TrailerApis/Vimeo.Api"
RUN dotnet build "Vimeo.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Vimeo.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Vimeo.Api.dll"]