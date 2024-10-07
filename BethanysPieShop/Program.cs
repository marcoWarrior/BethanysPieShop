using BethanysPieShop.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICategoryRepository, MockCategoryRepository>();
builder.Services.AddScoped<IPieRepository, MockPieRepository>();

builder.Services.AddControllersWithViews(); // Add MVC services

var app = builder.Build();

app.UseStaticFiles(); // Middleware component: Enable static files

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Middleware component: Enable developer exception page
}

app.MapDefaultControllerRoute(); // Middleware component: Enable default controller route, richieste in arrivo

app.Run();
