Thesis Prototype
========================

This project is a very simple prototype of an MVC web application, using both MySQL and the Redis KV-store for rapid storage and retrieval of many batches of sensor data. This prototype was made to showcase the results of my bachelor's thesis, providing the client with a practical example of what their application might look like when the findings of my thesis would be implemented.

> __Note__
> Since this is a very simple prototype which should only be ran locally, it contains some flaws. The gravest of which are the usage of unencrypted connection strings and password-less databases. 

Pre-requisites
-----------------------------------------
1. DotNet Core 2.1
2. SQL Server Local DB
3. Docker v. 18.06.1-ce (Other versions are most likely fine as well, but only this version was tested)
4. Bash shell

Steps for running this application
-----------------------------------------
1. `./Scripts/start-redis.sh create`
2. Edit the value of "RedisConnectionString" in appsettings.json to "&lt;ip of the redis-manager0 docker-machine&gt;:7000". You can find this ip by running `docker-machine ip redis-manager0`
3. Create a new database in the SQL Server LocalDB using `CREATE DATABASE PrototypeDb;` in the SQL shell.
4. `dotnet restore`
5. `dotnet ef database update`
6. `dotnet run`
7. Log in: default available users are User1, User2 or User3, with password 'password'. User2  already has some ships (without data).

You can use the ImportFileCreator project at https://github.com/robertkraaijeveld/ImportFileCreator to generate fake import files that this prototype can import. 
