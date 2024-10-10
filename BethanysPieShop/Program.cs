using BethanysPieShop.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();

builder.Services.AddControllersWithViews(); // Add MVC services
builder.Services.AddDbContext<BethanysPieShopDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:BethanysPieShopDbContextConnection"]);
});

var app = builder.Build();

app.UseStaticFiles(); // Middleware component: Enable static files

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

DbInitializer.Seed(app); // Seed the database

app.Run();
