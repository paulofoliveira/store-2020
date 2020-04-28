FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
RUN apt-get update
RUN apt-get install software-properties-common -y
RUN apt-get install -y gnupg2 -y

RUN add-apt-repository ppa:nginx/stable -y
RUN apt-get update -y; exit 0
RUN apt-get install nginx -y

RUN apt-get install supervisor -y
RUN mkdir -p /var/log/microservice