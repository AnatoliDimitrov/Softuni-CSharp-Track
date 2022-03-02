#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Claudi.Web/Claudi.Web.csproj", "Claudi.Web/"]
RUN dotnet restore "Claudi.Web/Claudi.Web.csproj"
COPY . .
WORKDIR "/src/Claudi.Web"
RUN dotnet build "Claudi.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Claudi.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Claudi.Web.dll"]