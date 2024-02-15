using DbProjectAsync.Data;
using DbProjectAsync.Interfaces;
using DbProjectAsync.Models;
using DbProjectAsync.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));


var config = (IConfiguration)builder.Configuration;
Log.Logger = new LoggerConfiguration() // initiate the logger configuration
                .ReadFrom.Configuration(config) // connect serilog to our configuration folder
                .Enrich.FromLogContext() //Adds more information to our logs from built in Serilog 
                .WriteTo.Console() // decide where the logs are going to be shown                           
                .CreateLogger(); //initialise the logger
builder.Host.UseSerilog();




builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IStudent, StudentRepository>();
builder.Services.Configure<ComplexObjectClass>(config.GetSection("ComplexObject"));

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
