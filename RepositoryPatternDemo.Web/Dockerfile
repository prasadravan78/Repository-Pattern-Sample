#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["RepositoryPatternDemo.Web/RepositoryPatternDemo.Web.csproj", "RepositoryPatternDemo.Web/"]
RUN dotnet restore "RepositoryPatternDemo.Web/RepositoryPatternDemo.Web.csproj"
COPY . .
WORKDIR "/src/RepositoryPatternDemo.Web"
RUN dotnet build "RepositoryPatternDemo.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RepositoryPatternDemo.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RepositoryPatternDemo.Web.dll"]