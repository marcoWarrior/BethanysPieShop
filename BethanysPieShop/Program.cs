using BethanysPieShop.App;
using BethanysPieShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Recupero della stringa di connessione al database dal file di configurazione (appsettings.json)
var connectionString = builder.Configuration.GetConnectionString("BethanysPieShopDbContextConnection")
    ?? throw new InvalidOperationException("Connection string 'BethanysPieShopDbContextConnection' not found.");

// Configurazione del DbContext per l'uso di SQL Server
builder.Services.AddDbContext<BethanysPieShopDbContext>(options =>
    options.UseSqlServer(connectionString)); // Servizio per il database, componente MVC

// Aggiunta del servizio per l'autenticazione con Identity (per gestione utenti)
builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<BethanysPieShopDbContext>(); // Servizio di Identity, parte del sistema di autenticazione

// Aggiunta dei controller e delle viste per l'applicazione MVC
builder.Services.AddControllersWithViews(); // Servizio MVC


// builder.Services.AddScoped<ICategoryRepository, MockCategoryRepository>();
// builder.Services.AddScoped<IPieRepository, MockPieRepository>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>(); // Servizio per la gestione delle categorie
builder.Services.AddScoped<IPieRepository, PieRepository>(); // Servizio per la gestione delle torte
builder.Services.AddScoped<IOrderRepository, OrderRepository>(); // Servizio per la gestione degli ordini

// Aggiunta del servizio per il carrello della spesa
builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp)); // Servizio per il carrello

// Aggiunta della sessione per la gestione dello stato tra le richieste
builder.Services.AddSession(); // Middleware di sessione

// Aggiunta del supporto per l'accesso al contesto HTTP (utile per sessione, carrello, etc.)
builder.Services.AddHttpContextAccessor(); // Servizio per ottenere informazioni sulla richiesta corrente

// Aggiunta della possibilità di usare Razor Pages nell'applicazione
builder.Services.AddRazorPages(); // Supporto per Razor Pages

// builder.Services.AddServerSideBlazor(); // Per abilitare Blazor Server (commentato nel codice originale)
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents(); // Servizio per l'interazione lato server con Razor Components

// Configurazione di nuovo il DbContext per l'uso di SQL Server (questa riga � ridondante rispetto alla prima configurazione)
builder.Services.AddDbContext<BethanysPieShopDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:BethanysPieShopDbContextConnection"]); // Nuova configurazione del DbContext
});


// builder.Services.AddDefaultIdentity<IdentityUser>()
// .AddEntityFrameworkStores<BethanysPieShopDbContext>(); // Commentato poich� � gi� stato gestito prima

var app = builder.Build();

// Verifica se l'applicazione � in modalit� di sviluppo
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Middleware di gestione degli errori in modalit� di sviluppo
}

app.UseStaticFiles(); // Middleware per i file statici
app.UseSession(); // Middleware di sessione
app.UseAuthentication(); // Middleware di autenticazione
app.UseAuthorization(); // Middleware di autorizzazione

// Configurazione della route predefinita per il controller e l'azione
// La struttura prevede che la rotta sia: /{controller=Home}/{action=Index}/{id?}
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // Routing MVC

// Abilitazione della protezione contro i CSRF (Cross-Site Request Forgery)
app.UseAntiforgery(); // Middleware di protezione CSRF

// Aggiungi le pagine Razor all'applicazione
app.MapRazorPages(); // Routing per Razor Pages

// Aggiungi i componenti Razor all'applicazione (per la gestione dei Razor Components)
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode(); // Aggiunta di Razor Components all'applicazione

// Seeding del database (inizializzazione dei dati di esempio)
DbInitializer.Seed(app); // Funzione che inizializza i dati nel database, utile durante lo sviluppo

// Avvio dell'applicazione
app.Run(); // Avvio dell'applicazione
