using Microsoft.EntityFrameworkCore;
using bestillingsformularForBiludlejningsfirmaH3.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<h3_biludlejningContext>(options =>
    options.UseMySql("server=185.252.232.25;user=h3_biludlejning;password=F2FFXx25DD5A8EjT;database=h3_biludlejning", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.14-mariadb")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
