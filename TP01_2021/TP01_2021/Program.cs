using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DB_al73891;
using TP01_2021.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TP01Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TP01Context") ?? throw new InvalidOperationException("Connection string 'TP01Context' not found.")));

// DbInitializer
builder.Services.AddTransient<DbInitializer>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// DbInitializer
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

var initializer = services.GetRequiredService<DbInitializer>();

initializer.Run();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "filtered",
    pattern: "Amigos",
    defaults: new { Controller = "Contactos", Action = "Lista2" });

app.Run();
