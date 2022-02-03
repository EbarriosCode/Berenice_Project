# Stepts run project 

## Database
1. Create a database called Berenice in SQL Server
2. Configure connection string in appsettings.json file at Backend project in VS
3. Migrations already are created, so you have to run command update-database for run migrations, you will run command in package manager console in VS
4. The backend project runs at https://localhost:5001 you will find the documentation with swagger at https://localhost:5001/swagger/index.html after running the project it will automatically create data to initialize the database, you can check it by doing a select to any of the tables in the database

## Run Backend (Dotnet Core Web Api)
1. Open project in VS and run

## Run Frontend (Angular with TypeScript)
1. Open project client in the follow route Albumes-Project\frontend\albumes.spa.client
2. Run command ng serve

## Architecture in Backend
The backend is built based on clean architecture consisting of 4 important layers Entities, Application Business Rules, Interface and Adapters, Devices or Web or UI
