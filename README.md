# Bearcat Bites
Food and Drink recommendation for around the UC area built on ASP.NET Core MVC

## Features
* **Daily Spotlight** - Random daily food/drink recommendation from Cincinnati's best
* **Explore Bites** - Browse all food recommendations
* **Explore Sips** - Browse all drink recommendations  
* **Admin Panel** - Secure admin interface to manage entries (add, edit, delete)
* **Database Persistence** - SQL Server LocalDB with Entity Framework Core
* **Image Upload** - Support for food/drink images
* **Responsive Design** - Bootstrap 5 with custom Cincinnati-themed styling

## Tech Stack
* **Framework:** ASP.NET Core 8.0 MVC
* **Language:** C# 12.0
* **Database:** SQL Server LocalDB
* **ORM:** Entity Framework Core 8.0
* **Frontend:** Bootstrap 5, HTML, CSS
* **Authentication:** Session-based admin authentication

## Prerequisites
* .NET 8 SDK - [Download here](https://dotnet.microsoft.com/download/dotnet/8.0)
* Visual Studio 2022 (recommended) or VS Code
* SQL Server LocalDB (included with Visual Studio)

## How to Run the Application

### 1. Clone the Repository
```bash
git clone https://github.com/VaiVuong/BearcatBites.git
cd BearcatBites
```

### 2. Restore NuGet Packages
```bash
dotnet restore
```

### 3. Apply Database Migrations
```bash
dotnet ef database update --project BearcatBites
```

This will:
- Create the SQL Server LocalDB database
- Create the `FoodItems` table
- Seed initial sample data

### 4. Run the Application
```bash
dotnet run --project BearcatBites
```

Or press `F5` in Visual Studio to run in debug mode.

### 5. Access the Application
- **Home:** `https://localhost:5001` or `http://localhost:5000`
- **Admin Login:** Navigate to `/Admin/Login`
  - Username: `admin`
  - Password: `admin`

## Database Management

### Create a New Migration
```bash
dotnet ef migrations add MigrationName --project BearcatBites
```

### Update Database
```bash
dotnet ef database update --project BearcatBites
```

### Remove Last Migration (if not applied)
```bash
dotnet ef migrations remove --project BearcatBites
```

### Drop Database (reset)
```bash
dotnet ef database drop --project BearcatBites
```

## Project Structure
```
BearcatBites/
├── Controllers/         # MVC Controllers
├── Models/             # Data models
├── Views/              # Razor views
├── Data/               # DbContext and seeding
├── Migrations/         # EF Core migrations
├── wwwroot/            # Static files (CSS, JS, images)
└── Program.cs          # Application entry point
```

## Development Team
* **Chris Vu** - Developer
* **Pranish Adhikari** - Developer
