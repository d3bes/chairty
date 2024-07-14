
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS Build 

WORKDIR /src

COPY *.csproj   .


RUN dotnet restore  

# RUN dotnet clean

# RUN dotnet build -c release


COPY . .

RUN dotnet publish -c release -o /App

FROM mcr.microsoft.com/dotnet/aspnet:7.0

WORKDIR /app

EXPOSE 80

COPY --from=build /App .

ENTRYPOINT [ "dotnet","charityMVC.dll" ]




