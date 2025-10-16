# Getting Started - Bethany's Pie Shop

This guide will help you clone, configure, and run the Bethany's Pie Shop web application on your local machine.

## Table of Contents
- [Prerequisites](#prerequisites)
- [Clone the Repository](#clone-the-repository)
- [Database Configuration](#database-configuration)
- [Build and Run the Application](#build-and-run-the-application)
- [Access the Application](#access-the-application)
- [Application Features](#application-features)
- [Troubleshooting](#troubleshooting)

## Prerequisites

Before you begin, make sure you have the following installed:

### Required Software
1. **.NET 8.0 SDK** or higher
   - Download from: https://dotnet.microsoft.com/download
   - Verify installation: `dotnet --version`

2. **Git**
   - Download from: https://git-scm.com/downloads
   - Verify installation: `git --version`

3. **Database** (choose one of the following options):
   
   **Option A: SQL Server LocalDB (Recommended for Windows)**
   - Included with Visual Studio 2019/2022
   - Or download SQL Server Express: https://www.microsoft.com/sql-server/sql-server-downloads
   
   **Option B: SQLite (Cross-platform alternative)**
   - No installation required, managed automatically by .NET

### Recommended Editors/IDEs
- **Visual Studio 2022** (Windows/Mac) - Includes everything
- **Visual Studio Code** with C# extension - Lightweight and cross-platform
- **JetBrains Rider** - Full-featured cross-platform IDE

## Clone the Repository

1. Open your terminal (or Command Prompt/PowerShell on Windows)

2. Navigate to the folder where you want to save the project:
   ```bash
   cd C:\Projects  # Windows
   # or
   cd ~/Projects   # macOS/Linux
   ```

3. Clone the repository:
   ```bash
   git clone https://github.com/marcoWarrior/BethanysPieShop.git
   ```

4. Navigate into the project folder:
   ```bash
   cd BethanysPieShop
   ```

## Database Configuration

The project is configured to use SQL Server LocalDB by default. If you prefer to use SQLite, follow these steps:

### Option 1: Use SQL Server LocalDB (Default)

If you're using Windows with SQL Server LocalDB installed, no configuration is needed. The database will be created automatically on first run.

### Option 2: Switch to SQLite

To use SQLite (recommended for macOS/Linux or for ease of use):

1. Open the file `BethanysPieShop/appsettings.json`

2. Modify the connection string:
   ```json
   {
     "ConnectionStrings": {
       "BethanysPieShopDbContextConnection": "Data Source=BethanysPieShop.db"
     }
   }
   ```

3. Open the file `BethanysPieShop/Program.cs`

4. Find this line (around line 14):
   ```csharp
   options.UseSqlServer(connectionString);
   ```

5. Replace it with:
   ```csharp
   options.UseSqlite(connectionString);
   ```

6. Find the second occurrence as well (around line 50) and make the same change.

## Build and Run the Application

### Step 1: Restore NuGet Packages

```bash
dotnet restore
```

### Step 2: Apply Database Migrations

```bash
dotnet ef database update --project BethanysPieShop
```

If the `dotnet ef` command is not installed, first run:
```bash
dotnet tool install --global dotnet-ef
```

### Step 3: Build the Application

```bash
dotnet build
```

### Step 4: Run Tests (Optional)

```bash
dotnet test
```

### Step 5: Start the Application

```bash
cd BethanysPieShop
dotnet run
```

You should see output similar to:
```
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5000
      Now listening on: https://localhost:5001
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
```

## Access the Application

1. Open your preferred web browser

2. Navigate to:
   - **HTTP:** http://localhost:5000
   - **HTTPS:** https://localhost:5001 (recommended)

3. You'll see the Bethany's Pie Shop homepage with available pies!

## Application Features

### What You Can Do

1. **Browse Pies**
   - View all available pies on the homepage
   - See the pies of the week
   - Explore different categories (Fruit Pies, Cheese Cakes, Seasonal Pies)

2. **View Details**
   - Click on a pie to see full details
   - Check price, description, and availability

3. **Manage Shopping Cart**
   - Add pies to your cart
   - View cart contents
   - Modify quantities

4. **Place Orders**
   - Complete checkout with your information
   - Submit your order

5. **Authentication (Optional)**
   - Register a new account
   - Log in
   - Manage your profile

### Technologies Used

- **ASP.NET Core 8.0** - Web framework
- **Entity Framework Core** - ORM for database
- **ASP.NET Core Identity** - Authentication and authorization
- **Razor Pages** - Some UI pages
- **MVC** - Architectural pattern
- **Blazor** - Interactive components
- **Bootstrap** - CSS framework for styling

## Troubleshooting

### Issue: "Connection string not found"

**Solution:** Make sure the `appsettings.json` file contains the correct connection string.

### Issue: "Unable to connect to SQL Server"

**Solution:** 
- Verify that SQL Server LocalDB is installed and running
- Or switch to SQLite following the instructions above

### Issue: "dotnet ef command not found"

**Solution:** Install Entity Framework Core Tools:
```bash
dotnet tool install --global dotnet-ef
```

### Issue: Port already in use

**Solution:** 
- Close other applications using ports 5000/5001
- Or modify the ports in `BethanysPieShop/Properties/launchSettings.json`

### Issue: Build errors

**Solution:**
1. Clean the build: `dotnet clean`
2. Restore packages: `dotnet restore`
3. Rebuild: `dotnet build`

### Issue: Database not populated

**Solution:** The database is automatically populated on startup with sample data. If you don't see any pies:
1. Delete the database (`.db` file for SQLite or LocalDB database)
2. Restart the application

## Additional Support

For more information:
- Check the **Guida Completa.pdf** included in the repository
- Visit the official ASP.NET Core documentation: https://docs.microsoft.com/aspnet/core/
- Open an issue on GitHub for specific problems

---

**Enjoy Bethany's Pie Shop! 🥧**
