using Microsoft.EntityFrameworkCore;
using Networm.Infrastructure.Persistence;
using Networm.Infrastructure.Extensions;
using Networm.Infrastructure.Seeders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Find and pass connection string to database
builder.Services.AddInfrastructure(builder.Configuration);


var app = builder.Build();
var scope = app.Services.CreateScope(); //invoke dependency with scoped lifetime 
var seeder = scope.ServiceProvider.GetRequiredService<NetwormSeeder>();
await seeder.Seed();

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
