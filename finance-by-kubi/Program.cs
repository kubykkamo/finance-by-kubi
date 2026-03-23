using finance_by_kubi.Components;
using finance_by_kubi.Data;
using finance_by_kubi.Models;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
// Všimni si toho slova "Factory" na konci
builder.Services.AddDbContextFactory<AppDbContext>(options =>
    options.UseSqlite("Data Source=finance.db")); // Tady nech svůj stávající connection string

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    // 1. Ujistíme se, že databáze existuje a jsou v ní tabulky
    context.Database.EnsureCreated();

    // 2. Pokud v tabulce Accounts nic není, přidáme testovací účet
    if (!context.Accounts.Any())
    {
        var testAccount = new Account
        {
            Name = "Test",
            Surname = "Account"
            // Tady doplň vlastnosti podle tvého modelu Account (např. Name)
            // Name = "Hlavní bankovní účet" 
        };

        context.Accounts.Add(testAccount);
        context.SaveChanges();
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();
app.UseStaticFiles();
app.MapStaticAssets(); 
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
