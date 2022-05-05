#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["HotChocolateGraphQL/HotChocolateGraphQL.csproj", "HotChocolateGraphQL/"]
RUN dotnet restore "HotChocolateGraphQL/HotChocolateGraphQL.csproj"
COPY . .
WORKDIR "/src/HotChocolateGraphQL"
RUN dotnet build "HotChocolateGraphQL.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HotChocolateGraphQL.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HotChocolateGraphQL.dll"]
