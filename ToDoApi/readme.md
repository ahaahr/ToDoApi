Learning project using .NET Core MVC, Entity framework, Docker and MS SQL Server

Repo: https://github.com/ahaahr/ToDoApi

---------- ARCHITECTURE ----------
.NET project exposes api. 
Api can be used to access ToDo items and users.
.NET project connects to Microsoft SQL server DB using Entity
DB is running in a Docker container
Install Docker container: 
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=MangoMango123' -p 1433:1433 -d microsoft/mssql-server-linux:2017-latest
Run Docker contianer if stopped (for example if machine was rebooted):
docker start f6294779f1c8 
Docker guide: https://medium.com/microsoftazure/setting-up-database-servers-for-development-on-mac-os-x-using-docker-b7f2fad056f3