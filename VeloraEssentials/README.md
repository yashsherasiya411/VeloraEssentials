# Velora Essentials (ASP.NET Core MVC)

A product catalogue and product-management website for a period-care startup.

## Features
- Shop page showing active products (responsive Bootstrap layout)
- Manage Products: list, search, filter by category, add, edit, delete
- SQL Server database through Entity Framework Core (database is created automatically)
- Server-side and client-side form validation

## Requirements
- Visual Studio 2022 (ASP.NET workload) or the .NET 8 SDK
- SQL Server LocalDB (installed with Visual Studio) or any SQL Server

## Run
1. Open `VeloraEssentials.csproj` in Visual Studio 2022 (or run `dotnet run` in this folder).
2. Check the connection string in `appsettings.json`. Change the server name if you use full SQL Server.
3. Press F5. The database `VeloraEssentialsDb` and sample products are created on first run.
4. Open SSMS and connect to `(localdb)\MSSQLLocalDB` to see the `Products` table.

## Folder guide
- `Models/Product.cs` - data model and validation rules
- `Data/AppDbContext.cs` - EF Core database context
- `Controllers/` - Home (shop) and Products (CRUD)
- `Views/` - Razor pages
- `Database/VeloraEssentialsDb.sql` - optional manual SQL script
