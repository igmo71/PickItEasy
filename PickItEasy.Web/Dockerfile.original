#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["PickItEasy.Web/PickItEasy.Web.csproj", "PickItEasy.Web/"]
RUN dotnet restore "PickItEasy.Web/PickItEasy.Web.csproj"
COPY . .
WORKDIR "/src/PickItEasy.Web"
RUN dotnet build "PickItEasy.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PickItEasy.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PickItEasy.Web.dll"]