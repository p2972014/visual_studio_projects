#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AspNetCoreWebApi_from_empty/AspNetCoreWebApi_from_empty.csproj", "AspNetCoreWebApi_from_empty/"]
RUN dotnet restore "AspNetCoreWebApi_from_empty/AspNetCoreWebApi_from_empty.csproj"
COPY . .
WORKDIR "/src/AspNetCoreWebApi_from_empty"
RUN dotnet build "AspNetCoreWebApi_from_empty.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AspNetCoreWebApi_from_empty.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AspNetCoreWebApi_from_empty.dll"]