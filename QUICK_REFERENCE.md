# Quick Reference - Bethany's Pie Shop

## Quick Commands

### Clone and Setup
```bash
git clone https://github.com/marcoWarrior/BethanysPieShop.git
cd BethanysPieShop
dotnet restore
```

### Build and Run
```bash
dotnet build
cd BethanysPieShop
dotnet run
```

### Database Commands
```bash
# Install EF tools (first time only)
dotnet tool install --global dotnet-ef

# Apply migrations
dotnet ef database update --project BethanysPieShop

# Create new migration
dotnet ef migrations add MigrationName --project BethanysPieShop

# Remove last migration
dotnet ef migrations remove --project BethanysPieShop
```

### Testing
```bash
# Run all tests
dotnet test

# Run tests with detailed output
dotnet test --verbosity normal
```

### Clean and Rebuild
```bash
dotnet clean
dotnet restore
dotnet build
```

## URLs

| Page | URL |
|------|-----|
| Homepage | https://localhost:5001 |
| All Pies | https://localhost:5001/Pie/List |
| Shopping Cart | https://localhost:5001/ShoppingCart |
| Checkout | https://localhost:5001/Order/Checkout |
| Login | https://localhost:5001/Identity/Account/Login |
| Register | https://localhost:5001/Identity/Account/Register |

## File Locations

### Configuration
- `BethanysPieShop/appsettings.json` - Main configuration
- `BethanysPieShop/appsettings.Development.json` - Dev settings
- `BethanysPieShop/Program.cs` - Application startup

### Controllers
- `BethanysPieShop/Controllers/HomeController.cs` - Homepage
- `BethanysPieShop/Controllers/PieController.cs` - Pie listing/details
- `BethanysPieShop/Controllers/ShoppingCartController.cs` - Cart
- `BethanysPieShop/Controllers/OrderController.cs` - Orders

### Models
- `BethanysPieShop/Models/Pie.cs` - Pie entity
- `BethanysPieShop/Models/Category.cs` - Category entity
- `BethanysPieShop/Models/Order.cs` - Order entity
- `BethanysPieShop/Models/BethanysPieShopDbContext.cs` - Database context
- `BethanysPieShop/Models/DbInitializer.cs` - Seed data

### Views
- `BethanysPieShop/Views/Home/Index.cshtml` - Homepage
- `BethanysPieShop/Views/Pie/List.cshtml` - Pie list
- `BethanysPieShop/Views/Pie/Details.cshtml` - Pie details
- `BethanysPieShop/Views/Shared/_Layout.cshtml` - Main layout

### Pages (Razor Pages)
- `BethanysPieShop/Pages/CheckoutPage.cshtml` - Checkout

## Default Sample Data

### Categories (3)
- Fruit pies
- Cheese cakes
- Seasonal pies

### Pies (15)
| Name | Price | Category | In Stock |
|------|-------|----------|----------|
| Apple Pie | $12.95 | Fruit pies | Yes |
| Pumpkin Pie | $12.95 | Seasonal pies | Yes |
| Christmas Apple Pie | $13.95 | Seasonal pies | Yes |
| Cherry Pie | $15.95 | Fruit pies | Yes |
| Peach Pie | $15.95 | Fruit pies | No |
| Rhubarb Pie | $15.95 | Fruit pies | Yes |
| Strawberry Pie | $15.95 | Fruit pies | Yes |
| Cranberry Pie | $17.95 | Seasonal pies | Yes |
| Blueberry Cheese Cake | $18.95 | Cheese cakes | Yes |
| Cheese Cake | $18.95 | Cheese cakes | Yes |
| Strawberry Cheese Cake | $18.95 | Cheese cakes | No |
| Chocolate Cheese Cake | $19.95 | Cheese cakes | Yes |
| Pecan Pie | $21.95 | Fruit pies | Yes |
| Pistache Cheese Cake | $21.95 | Cheese cakes | Yes |
| Caramel Popcorn Cheese Cake | $22.95 | Cheese cakes | Yes |
| Birthday Pie | $29.95 | Seasonal pies | Yes |

### Pies of the Week (3)
- Caramel Popcorn Cheese Cake
- Chocolate Cheese Cake
- Pistache Cheese Cake

## Common Tasks

### Add a New Pie (Code)
```csharp
// In DbInitializer.cs
new Pie 
{ 
    Name = "Lemon Meringue Pie", 
    Price = 16.95M, 
    ShortDescription = "Tangy and sweet!", 
    LongDescription = "...",
    Category = Categories["Fruit pies"], 
    ImageUrl = "https://...", 
    InStock = true, 
    IsPieOfTheWeek = false,
    ImageThumbnailUrl = "https://...", 
    AllergyInformation = "" 
}
```

### Change Port Numbers
Edit `BethanysPieShop/Properties/launchSettings.json`:
```json
"applicationUrl": "https://localhost:7001;http://localhost:7000"
```

### Switch to SQLite (for macOS/Linux)

1. Edit `appsettings.json`:
```json
"ConnectionStrings": {
  "BethanysPieShopDbContextConnection": "Data Source=BethanysPieShop.db"
}
```

2. Edit `Program.cs` (2 locations):
```csharp
// Change from:
options.UseSqlServer(connectionString);
// To:
options.UseSqlite(connectionString);
```

3. Remove database and migrations:
```bash
rm -rf BethanysPieShop/Migrations
rm -f BethanysPieShop/*.db
```

4. Create new migrations:
```bash
dotnet ef migrations add InitialCreate --project BethanysPieShop
dotnet ef database update --project BethanysPieShop
```

## Troubleshooting

### Issue: Port already in use
```bash
# Find process using port (Windows)
netstat -ano | findstr :5001

# Kill process (Windows)
taskkill /PID <process_id> /F

# Find process using port (macOS/Linux)
lsof -i :5001

# Kill process (macOS/Linux)
kill -9 <process_id>
```

### Issue: Database connection error
```bash
# Delete database and recreate
rm BethanysPieShop/BethanysPieShop.db  # SQLite
# or drop database in SQL Server Management Studio

# Recreate
dotnet ef database update --project BethanysPieShop
```

### Issue: Compilation errors
```bash
# Clean and rebuild
dotnet clean
rm -rf BethanysPieShop/bin BethanysPieShop/obj
rm -rf BethanysPieShopTests/bin BethanysPieShopTests/obj
dotnet restore
dotnet build
```

### Issue: Missing packages
```bash
# Restore NuGet packages
dotnet restore

# Clear NuGet cache
dotnet nuget locals all --clear
dotnet restore
```

## Keyboard Shortcuts (Visual Studio Code)

| Shortcut | Action |
|----------|--------|
| `Ctrl+F5` | Run without debugging |
| `F5` | Run with debugging |
| `Ctrl+C` | Stop application (in terminal) |
| `Ctrl+Shift+B` | Build |
| `Ctrl+Shift+T` | Run tests |
| `Ctrl+.` | Quick fixes |
| `F12` | Go to definition |
| `Shift+F12` | Find references |

## Environment Variables

```bash
# Set to Development
export ASPNETCORE_ENVIRONMENT=Development  # macOS/Linux
set ASPNETCORE_ENVIRONMENT=Development     # Windows

# Set to Production
export ASPNETCORE_ENVIRONMENT=Production   # macOS/Linux
set ASPNETCORE_ENVIRONMENT=Production      # Windows
```

## Useful Git Commands

```bash
# Check status
git status

# View changes
git diff

# Discard changes
git checkout -- <file>

# Create branch
git checkout -b feature-name

# Commit changes
git add .
git commit -m "Description"

# Push changes
git push origin branch-name
```

## NuGet Package Commands

```bash
# Add package
dotnet add package <PackageName>

# Remove package
dotnet remove package <PackageName>

# Update package
dotnet add package <PackageName> --version <Version>

# List packages
dotnet list package
```

## Project Structure Quick Reference

```
BethanysPieShop/
├── BethanysPieShop/              # Main web application
│   ├── Controllers/              # MVC controllers
│   ├── Models/                   # Data models
│   ├── Views/                    # Razor views
│   ├── Pages/                    # Razor pages
│   ├── Components/               # Blazor components
│   ├── wwwroot/                  # Static files (CSS, JS, images)
│   ├── Areas/                    # Identity UI
│   ├── Migrations/               # EF Core migrations
│   ├── Program.cs                # Application startup
│   └── appsettings.json          # Configuration
├── BethanysPieShopTests/         # Unit tests
└── README.md                     # This file
```

## Resources

- [ASP.NET Core Documentation](https://docs.microsoft.com/aspnet/core/)
- [Entity Framework Core](https://docs.microsoft.com/ef/core/)
- [C# Documentation](https://docs.microsoft.com/dotnet/csharp/)
- [Bootstrap Documentation](https://getbootstrap.com/docs/)

## Support

For issues or questions:
1. Check [GETTING_STARTED.md](GETTING_STARTED.md) for detailed setup
2. Review [WALKTHROUGH.md](WALKTHROUGH.md) for feature tour
3. See [ARCHITECTURE.md](ARCHITECTURE.md) for technical details
4. Open an issue on GitHub

---

**Quick tip:** Bookmark this page for easy reference! 📌
