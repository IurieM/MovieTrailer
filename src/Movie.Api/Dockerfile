FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 5000

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["src/Movie.Api/Movie.Api.csproj", "src/Movie.Api/"]
COPY ["src/Movie.Data/Movie.Data.csproj", "src/Movie.Data/"]
COPY ["src/BuildingBlocks/Block.Htttp/Block.Http.csproj", "src/BuildingBlocks/Block.Htttp/"]
COPY ["src/Movie.Common/Movie.Common.csproj", "src/Movie.Common/"]
COPY ["src/BuildingBlocks/Block.Api/Block.Api.csproj", "src/BuildingBlocks/Block.Api/"]
RUN dotnet restore "src/Movie.Api/Movie.Api.csproj"
COPY . .
WORKDIR "/src/src/Movie.Api"
RUN dotnet build "Movie.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Movie.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Movie.Api.dll"]