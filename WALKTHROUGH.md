# Application Walkthrough - Bethany's Pie Shop

This document provides a visual walkthrough of the Bethany's Pie Shop application, showing what users can expect when they run the application.

## Starting the Application

After following the [Getting Started Guide](GETTING_STARTED.md), when you run:

```bash
cd BethanysPieShop
dotnet run
```

You will see output like this in your terminal:

```
Building...
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5000
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: https://localhost:5001
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: /path/to/BethanysPieShop/BethanysPieShop
```

## Application Features Tour

### 1. Homepage

**URL:** `https://localhost:5001/` or `http://localhost:5000/`

**What you'll see:**
- A welcoming header with the Bethany's Pie Shop logo and name
- Navigation menu with links to:
  - Home
  - All Pies
  - Contact
  - Shopping Cart
  - Login/Register
- A hero section showcasing the pie shop
- "Pies of the Week" section featuring 3 special pies:
  - Caramel Popcorn Cheese Cake - $22.95
  - Chocolate Cheese Cake - $19.95
  - Pistache Cheese Cake - $21.95
- Each pie shows:
  - Product image
  - Name
  - Short description
  - Price
  - "Add to cart" button

**Sample Pies Displayed:**
The application comes pre-populated with 15 different pies across three categories:
- **Cheese Cakes**: Caramel Popcorn, Chocolate, Pistache, Blueberry, Plain, Strawberry
- **Fruit Pies**: Pecan, Apple, Cherry, Peach (out of stock), Rhubarb, Strawberry
- **Seasonal Pies**: Birthday, Christmas Apple, Cranberry, Pumpkin

### 2. All Pies Page

**URL:** `https://localhost:5001/Pie/List`

**What you'll see:**
- Complete catalog of all available pies
- Grid layout showing all pies with:
  - Thumbnail images
  - Names
  - Prices
  - Short descriptions
  - "Add to cart" buttons
- Pies grouped by category
- Visual indicator for out-of-stock items

### 3. Pie Details Page

**URL:** `https://localhost:5001/Pie/Details/{pieId}`

**What you'll see:**
- Large product image
- Full pie information:
  - Name
  - Price
  - Category
  - Long description
  - Allergy information (if any)
  - Stock status
- Quantity selector
- "Add to cart" button
- "Back to list" link

**Example: Chocolate Cheese Cake Details**
- **Price:** $19.95
- **Category:** Cheese cakes
- **Description:** "The chocolate lover's dream" with full product description
- **Status:** In Stock

### 4. Shopping Cart

**URL:** `https://localhost:5001/ShoppingCart`

**What you'll see:**
- List of items in your cart with:
  - Pie name
  - Thumbnail image
  - Unit price
  - Quantity
  - Subtotal
  - Remove button
- Total amount at the bottom
- "Clear Cart" button
- "Checkout" button to proceed with order

**Functionality:**
- Adjust quantities for each item
- Remove items from cart
- Clear entire cart
- View running total
- Proceed to checkout

### 5. Checkout Page

**URL:** `https://localhost:5001/Order/Checkout`

**What you'll see:**
- Order form requesting:
  - First Name
  - Last Name
  - Address Line 1
  - Address Line 2 (optional)
  - Zip Code
  - City
  - State (optional)
  - Country
  - Phone Number
  - Email
- Order summary showing:
  - Items being ordered
  - Quantities
  - Total amount
- "Complete Order" button
- Form validation

### 6. Order Confirmation

**After submitting an order:**
- Success message thanking you for your order
- Order details summary
- Order number reference

### 7. Authentication Features

#### Register New Account
**URL:** `https://localhost:5001/Identity/Account/Register`

**Features:**
- Email field
- Password field (with requirements)
- Confirm password field
- Registration button
- Link to login page

#### Login
**URL:** `https://localhost:5001/Identity/Account/Login`

**Features:**
- Email field
- Password field
- "Remember me" checkbox
- Login button
- "Forgot password" link
- "Register as a new user" link

**Once logged in:**
- Personalized greeting in navigation
- Access to user profile
- Logout option

### 8. Additional Pages

#### Contact Page
Information about how to reach Bethany's Pie Shop

#### About Page
Information about the pie shop and its story

## User Workflows

### Workflow 1: Browse and Purchase Pies (Guest User)

1. **Start:** Open `https://localhost:5001`
2. View featured "Pies of the Week" on homepage
3. Click "All Pies" to see complete catalog
4. Click on a pie to see details
5. Select quantity and click "Add to cart"
6. View shopping cart icon (updated with item count)
7. Click shopping cart to review items
8. Click "Checkout"
9. Fill in delivery and contact information
10. Click "Complete Order"
11. See order confirmation

### Workflow 2: Register and Shop (New User)

1. **Start:** Open `https://localhost:5001`
2. Click "Register" in navigation
3. Fill in email and password
4. Submit registration
5. Confirm email (or skip in development mode)
6. Browse pies as authenticated user
7. Add items to cart
8. Checkout (form may be pre-filled with profile data)
9. Complete order

### Workflow 3: Returning Customer

1. **Start:** Open `https://localhost:5001`
2. Click "Login"
3. Enter credentials
4. Browse pies with personalized experience
5. Add to cart and checkout
6. Logout when done

## Technical Features Demonstrated

### 1. ASP.NET Core MVC
- Controller-based routing
- Model binding
- ViewModels for complex views

### 2. Razor Pages
- Checkout page implementation
- Form handling
- Page models

### 3. Blazor Components
- Interactive UI elements
- Real-time updates
- Component-based architecture

### 4. Entity Framework Core
- Database operations
- Migrations
- LINQ queries
- Relationships (One-to-Many, Many-to-Many)

### 5. ASP.NET Core Identity
- User registration
- Login/Logout
- Password hashing
- Cookie authentication

### 6. Session Management
- Shopping cart persistence across pages
- Session state maintenance

### 7. Responsive Design
- Mobile-friendly interface
- Bootstrap components
- Adaptive layouts

## Database Seeding

The application automatically seeds the database with sample data on first run, including:

- **3 Categories**
  - Fruit pies
  - Cheese cakes
  - Seasonal pies

- **15 Pies** with:
  - Names and descriptions
  - Prices ranging from $12.95 to $29.95
  - Stock status
  - "Pie of the Week" flags
  - Product images (hosted externally)

This allows you to immediately start testing the application without manually adding data.

## Development Tips

### Modifying the Application

1. **Add New Pies:**
   - Edit `Models/DbInitializer.cs`
   - Add new pie entries to the seed data
   - Delete database and restart to re-seed

2. **Change Styling:**
   - Edit CSS files in `wwwroot/css/`
   - Modify Bootstrap classes in views

3. **Add New Features:**
   - Create controllers in `Controllers/`
   - Add views in `Views/`
   - Create models in `Models/`

### Testing Changes

1. Stop the application (Ctrl+C)
2. Make your changes
3. Run `dotnet build` to check for errors
4. Run `dotnet run` to start with changes
5. Refresh browser to see updates (Ctrl+F5 for hard refresh)

## API Endpoints (if enabled)

The application structure supports API development:

- **GET /api/pies** - List all pies
- **GET /api/pies/{id}** - Get pie details
- **POST /api/cart** - Add to cart
- **GET /api/cart** - Get cart contents

(Note: API endpoints may need to be enabled/created based on project configuration)

## Browser Compatibility

The application is tested and works with:
- Google Chrome (recommended)
- Mozilla Firefox
- Microsoft Edge
- Safari

## Performance Notes

- **First Load:** May take a few seconds as the database is seeded
- **Subsequent Loads:** Fast, cached resources
- **Image Loading:** Images are hosted externally, load times depend on internet connection

## Stopping the Application

To stop the application:
1. Return to the terminal where `dotnet run` is executing
2. Press `Ctrl+C`
3. Wait for graceful shutdown message

```
info: Microsoft.Hosting.Lifetime[0]
      Application is shutting down...
```

## Next Steps

After exploring the application:

1. **Read the Code:**
   - Examine controller logic
   - Review model relationships
   - Study view implementations

2. **Extend Features:**
   - Add product reviews
   - Implement wishlist
   - Add admin panel
   - Create reporting features

3. **Deploy:**
   - Publish to Azure
   - Deploy to IIS
   - Containerize with Docker

For more advanced topics, refer to the **Guida Completa.pdf** included in the repository.

---

**Enjoy exploring Bethany's Pie Shop! 🥧**
