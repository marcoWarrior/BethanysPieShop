using BethanysPieShop.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp)); // Add shopping cart services
builder.Services.AddSession(); // Add session services
builder.Services.AddHttpContextAccessor(); // Add HTTP context accessor services

builder.Services.AddControllersWithViews(); // Add MVC services
builder.Services.AddRazorPages(); // Add Razor pages services
builder.Services.AddDbContext<BethanysPieShopDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:BethanysPieShopDbContextConnection"]);
});

var app = builder.Build();

app.UseStaticFiles(); // Middleware component: Enable static files
app.UseSession(); // Middleware component: Enable session

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Middleware component: Enable developer exception page
}

//"{controller=Home}/{action=Index}/{id?}" is the default route template
app.MapDefaultControllerRoute(); // Middleware component: Enable default controller route, richieste in arrivo

//Se avessimo voluto personalizzare la rotta o il pattern
//app.MapControllerRoute(
//    name: "defaulte",
//    pattern: "{controller=Home}/{action=Index}/{id?}"); 

app.MapRazorPages(); // Middleware component: Enable Razor pages
DbInitializer.Seed(app); // Seed the database

app.Run();
