
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS Build 

FROM mcr.microsoft.com/mssql/server:2022-latest

WORKDIR /src

COPY *.csproj   .


RUN dotnet restore  

# RUN dotnet clean

# RUN dotnet build -c release


COPY . .

RUN dotnet publish -c release -o /App
RUN sudo docker run -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=GYR2hu76#3d' \
   --name 'sql1' -p 1401:1433 \
   -v sql1data:/var/opt/mssql \
   -d mcr.microsoft.com/mssql/server:2022-latest

FROM mcr.microsoft.com/dotnet/aspnet:7.0

WORKDIR /App

COPY --from=build /App .

ENTRYPOINT [ "dotnet","charityMVC.dll" ]




