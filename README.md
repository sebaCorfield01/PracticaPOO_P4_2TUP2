# PracticaPOO_P4_2TUP2

# Create project
dotnet new gitignore
dotnet new sln -n "PracticaPOO_P4_2TUP2"
mkdir src
cd src
dotnet new webapi -f net8.0 -controllers -n Web
dotnet new classlib -n "Core" -f net8.0
cd ..
dotnet sln PracticaPOO_P4_2TUP2.sln add src/**/*.csproj
cd src
dotnet add Web/Web.csproj reference Core/Core.csproj
rm -r **/Class1.cs
cd Core
mkdir Entities

cd ..
dotnet new classlib -f net8.0 -n "Infrastructure"
cd ..
$ dotnet sln PracticaPOO_P4_2TUP2.sln add src/Infrastructure/Infrastructure.csproj
$ dotnet add src/Web/Web.csproj reference src/Infrastructure/Infrastructure.csproj
$ dotnet add src/Infrastructure/Infrastructure.csproj reference src/Core/Core.csproj


# Entity Framework
## Install Entity framework libraries
On Web project
dotnet add package Microsoft.EntityFrameworkCore.Design

On Infrastructure project
dotnet add package Microsoft.EntityFrameworkCore.Sqlite

## Install dotnet ef command line tool
dotnet tool update --global dotnet-ef

## Create migrations
dotnet ef migrations add InitialMigration --context ApplicationContext --startup-project src/Web --project src/Infrastructure -o Data/Migrations

## Update database
dotnet ef database update --context ApplicationDbContext --startup-project src/Web --project src/Infrastructure
