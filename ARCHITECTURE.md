# Architecture Overview - Bethany's Pie Shop

## Application Architecture

```
┌─────────────────────────────────────────────────────────────────┐
│                         USER INTERFACE                           │
│  ┌────────────────────────────────────────────────────────────┐ │
│  │  Browser (https://localhost:5001)                          │ │
│  │  - HTML/CSS/JavaScript                                     │ │
│  │  - Bootstrap for styling                                   │ │
│  │  - Blazor components for interactivity                     │ │
│  └────────────────────────────────────────────────────────────┘ │
└─────────────────────────────────────────────────────────────────┘
                              │
                              ▼
┌─────────────────────────────────────────────────────────────────┐
│                      ASP.NET CORE 8.0                            │
│  ┌──────────────┐  ┌──────────────┐  ┌────────────────────┐   │
│  │   MVC        │  │ Razor Pages  │  │  Blazor Server     │   │
│  │ Controllers  │  │              │  │  Components        │   │
│  │   & Views    │  │  Checkout    │  │                    │   │
│  └──────────────┘  └──────────────┘  └────────────────────┘   │
│         │                  │                    │               │
│         └──────────────────┼────────────────────┘               │
│                            ▼                                    │
│  ┌────────────────────────────────────────────────────────┐   │
│  │              BUSINESS LOGIC LAYER                       │   │
│  │                                                          │   │
│  │  ┌──────────────┐  ┌──────────────┐  ┌──────────────┐ │   │
│  │  │   Services   │  │  Repositories│  │  ViewModels  │ │   │
│  │  │              │  │              │  │              │ │   │
│  │  │  Shopping    │  │  Pie Repo    │  │  Pie Lists   │ │   │
│  │  │  Cart        │  │  Order Repo  │  │  Cart View   │ │   │
│  │  │  Session Mgmt│  │  Category    │  │  Checkout    │ │   │
│  │  └──────────────┘  └──────────────┘  └──────────────┘ │   │
│  └────────────────────────────────────────────────────────┘   │
│                            ▼                                    │
│  ┌────────────────────────────────────────────────────────┐   │
│  │                  DATA ACCESS LAYER                      │   │
│  │              Entity Framework Core 8.0                  │   │
│  │                                                          │   │
│  │  ┌──────────────┐  ┌──────────────┐  ┌──────────────┐ │   │
│  │  │   Models     │  │   DbContext  │  │  Migrations  │ │   │
│  │  │              │  │              │  │              │ │   │
│  │  │  Pie         │  │  Bethany's   │  │  Initial     │ │   │
│  │  │  Category    │  │  PieShop     │  │  Shopping    │ │   │
│  │  │  Order       │  │  DbContext   │  │  Cart        │ │   │
│  │  │  ShoppingCart│  │              │  │  Orders      │ │   │
│  │  └──────────────┘  └──────────────┘  └──────────────┘ │   │
│  └────────────────────────────────────────────────────────┘   │
└─────────────────────────────────────────────────────────────────┘
                              │
                              ▼
┌─────────────────────────────────────────────────────────────────┐
│                     DATABASE LAYER                               │
│  ┌────────────────────────────────────────────────────────┐    │
│  │  SQL Server LocalDB / SQLite                           │    │
│  │                                                          │    │
│  │  Tables:                                                │    │
│  │  - Categories                                           │    │
│  │  - Pies                                                 │    │
│  │  - Orders                                               │    │
│  │  - OrderDetails                                         │    │
│  │  - ShoppingCartItems                                    │    │
│  │  - AspNetUsers (Identity)                              │    │
│  │  - AspNetRoles (Identity)                              │    │
│  └────────────────────────────────────────────────────────┘    │
└─────────────────────────────────────────────────────────────────┘
```

## Component Details

### Presentation Layer

#### MVC Pattern
```
Controllers/
├── HomeController.cs          # Homepage, displays pies of the week
├── PieController.cs           # Pie listing and details
├── ShoppingCartController.cs  # Cart management
└── OrderController.cs         # Order placement

Views/
├── Home/
│   └── Index.cshtml          # Homepage view
├── Pie/
│   ├── List.cshtml           # All pies listing
│   └── Details.cshtml        # Pie details
├── ShoppingCart/
│   └── Index.cshtml          # Cart view
└── Shared/
    ├── _Layout.cshtml        # Main layout
    └── Components/           # View components
```

#### Razor Pages
```
Pages/
├── CheckoutPage.cshtml        # Checkout form
├── CheckoutPage.cshtml.cs     # Checkout page model
└── Shared/
```

#### Blazor Components
```
Components/
└── Interactive server components for dynamic updates
```

### Business Logic Layer

#### Repositories (Data Access Abstraction)
```
Models/
├── ICategoryRepository.cs     # Interface
├── CategoryRepository.cs      # Implementation
├── IPieRepository.cs          # Interface
├── PieRepository.cs           # Implementation
├── IOrderRepository.cs        # Interface
├── OrderRepository.cs         # Implementation
├── IShoppingCart.cs           # Interface
└── ShoppingCart.cs            # Implementation
```

#### Services
- **Shopping Cart Service**: Session-based cart management
- **Seeding Service**: Database initialization with sample data

### Data Access Layer

#### Entity Models
```
Models/
├── Pie.cs                     # Pie entity
├── Category.cs                # Category entity
├── Order.cs                   # Order entity
├── OrderDetail.cs             # Order line items
└── ShoppingCartItem.cs        # Cart items
```

#### DbContext
```
Models/
└── BethanysPieShopDbContext.cs
    - Configures entity relationships
    - Manages database connections
    - Handles migrations
```

### Cross-Cutting Concerns

#### Authentication & Authorization
```
ASP.NET Core Identity:
- User registration
- Login/Logout
- Password management
- Role-based access
- Cookie authentication
```

#### Configuration
```
appsettings.json              # App settings
appsettings.Development.json  # Dev-specific settings
- Connection strings
- Logging configuration
- Environment-specific settings
```

#### Static Files
```
wwwroot/
├── css/
│   └── site.css              # Custom styles
├── js/
│   └── site.js               # Custom JavaScript
└── lib/
    ├── bootstrap/            # Bootstrap framework
    └── jquery/               # jQuery library
```

## Data Flow

### 1. Viewing Pies
```
User Request → HomeController.Index()
             → PieRepository.GetPiesOfTheWeek()
             → EF Core Query → Database
             → Results → ViewModel
             → View Rendering → HTML Response
```

### 2. Adding to Cart
```
User Click "Add to Cart"
           → ShoppingCartController.AddToShoppingCart()
           → ShoppingCart.AddToCart(pie, quantity)
           → Create/Update ShoppingCartItem
           → Save to Database & Session
           → Redirect to Cart View
```

### 3. Placing Order
```
User Submit Checkout Form
           → CheckoutPage.OnPost()
           → Validate Model
           → OrderRepository.CreateOrder()
           → Save Order & OrderDetails
           → Clear Shopping Cart
           → Redirect to Confirmation
```

## Database Schema

### Core Tables

#### Categories
```sql
CategoryId (PK)
CategoryName
Description
```

#### Pies
```sql
PieId (PK)
Name
ShortDescription
LongDescription
Price
ImageUrl
ImageThumbnailUrl
IsPieOfTheWeek
InStock
CategoryId (FK)
AllergyInformation
```

#### Orders
```sql
OrderId (PK)
FirstName
LastName
AddressLine1
AddressLine2
ZipCode
City
State
Country
PhoneNumber
Email
OrderTotal
OrderPlaced (DateTime)
```

#### OrderDetails
```sql
OrderDetailId (PK)
OrderId (FK)
PieId (FK)
Amount
Price
```

#### ShoppingCartItems
```sql
ShoppingCartItemId (PK)
PieId (FK)
Amount
ShoppingCartId
```

## Key Design Patterns

### 1. Repository Pattern
- Abstracts data access logic
- Provides testable interface
- Centralizes query logic

### 2. Dependency Injection
- Services registered in Program.cs
- Constructor injection in controllers
- Promotes loose coupling

### 3. Model-View-ViewModel (MVVM)
- Separation of concerns
- ViewModels for complex views
- Clean data binding

### 4. Session State Pattern
- Shopping cart persistence
- User-specific data storage
- Maintained across requests

## Security Features

### Authentication
- ASP.NET Core Identity integration
- Secure password hashing (PBKDF2)
- Email confirmation support
- Account lockout on failed attempts

### Authorization
- Role-based access control ready
- Policy-based authorization support
- Antiforgery tokens on forms

### Data Protection
- HTTPS enforcement in production
- Secure cookie handling
- SQL injection prevention (EF parameterization)
- XSS protection (Razor encoding)

## Performance Optimizations

### Caching
- Static file caching
- Browser caching headers
- Session state caching

### Database
- Efficient LINQ queries
- Eager loading with `.Include()`
- Indexed primary/foreign keys

### Response
- Response compression
- Minified CSS/JS
- CDN for external libraries

## Extensibility Points

### Adding New Features

1. **New Entity Type:**
   - Add model class
   - Update DbContext
   - Create migration
   - Implement repository

2. **New Page:**
   - Create controller + actions
   - Create views
   - Update navigation

3. **New API Endpoint:**
   - Add API controller
   - Define DTOs
   - Implement endpoints

4. **New Authentication Provider:**
   - Configure external login
   - Update Identity configuration
   - Add UI for external login

## Development Workflow

```
1. Make Changes
   └─ Edit code files

2. Build
   └─ dotnet build

3. Run Tests
   └─ dotnet test

4. Run Application
   └─ dotnet run

5. Test in Browser
   └─ Navigate to localhost:5001

6. Commit Changes
   └─ git commit -m "message"
```

## Deployment Considerations

### Production Settings
- Change connection string to production database
- Disable developer exception page
- Enable HTTPS redirection
- Configure logging
- Set production environment variable

### Hosting Options
- **Azure App Service**: Managed hosting
- **IIS**: Windows Server hosting
- **Docker**: Container-based deployment
- **Linux**: Kestrel with reverse proxy (nginx/Apache)

---

This architecture provides a solid foundation for building, maintaining, and extending the Bethany's Pie Shop application.
