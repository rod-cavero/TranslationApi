#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
#ENV ASPNETCORE_ENVIRONMENT=Development
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TranslationApi/TranslationApi.csproj", "."]
RUN dotnet restore "./TranslationApi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "TranslationApi/TranslationApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TranslationApi/TranslationApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TranslationApi.dll"]
