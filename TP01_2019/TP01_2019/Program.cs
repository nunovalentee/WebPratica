using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TP01_2019.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TP01_2019Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TP01_2019Context") ?? throw new InvalidOperationException("Connection string 'TP01_2019Context' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

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
    pattern: "Classificacao",
    defaults: new { Controller="Home", Action="Index"});

app.Run();
