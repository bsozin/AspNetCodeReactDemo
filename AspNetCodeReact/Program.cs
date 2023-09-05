using AspNetCodeReact.Services;
using AspNetCodeReact.Services.Interfaces;
using AspNetCodeReact.Services.Mapping;
using AspNetCodeReact.Services.Validators;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services
    .AddFluentValidation()
    .AddAutoMapper()
    .AddDbContext<AspNetCodeReact.Data.CarsDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CarsDB")))
    .AddScoped<ICarsService, CarsService>();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
