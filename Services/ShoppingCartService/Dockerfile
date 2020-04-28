FROM solucaoi9/microservicebase:latest as base
COPY nginx.conf /etc/nginx/sites-available/default

WORKDIR /app
ENV ASPNETCORE_URLS http://+:8083
EXPOSE 8083

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY "ShoppingCartService.csproj" .
RUN dotnet restore
COPY . .
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY supervisord.conf /etc/supervisor/conf.d/supervisord.conf
ENTRYPOINT ["/usr/bin/supervisord"]
