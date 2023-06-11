using Proyecto1.Models;
using Proyecto1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<List<Plato>>();
//se delara así para no tener que declarar uno por cada `T`
builder.Services.AddScoped(typeof(ICRUDService<>),typeof(CRUDService<>));

var app = builder.Build();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

