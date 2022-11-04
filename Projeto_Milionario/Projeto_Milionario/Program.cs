using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Projeto_Milionario.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Projeto_MilionarioContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Projeto_MilionarioContext") ?? throw new InvalidOperationException("Connection string 'Projeto_MilionarioContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

// Permite criar utilizador sem foto
builder.Services.AddControllers(
    options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

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

app.Run();
