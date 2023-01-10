using DesignPatterns.EntityFramework.Data;
using DesignPatterns.Repository.Dapper;
using DesignPatterns.Repository.EntityFramework;
using DesignPatterns.Repository.UnicOfWork;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration; // allows both to access and to set up the config

// Add services to the container.
builder.Services.AddInfrastructure();
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DesignPatternsClientContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("Connection"));
});

// AddTransient

// AddScope


builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
// AddSingleton


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
