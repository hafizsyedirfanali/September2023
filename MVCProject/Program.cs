using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVCProject.Data;
using MVCProject.Interfaces;
using MVCProject.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");


builder.Services.AddDbContextPool<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    //options.SignIn.RequireConfirmedAccount = true;
    //options.SignIn.RequireConfirmedPhoneNumber = true;
    //options.Password.RequiredLength = 3;
    //options.Password.RequireNonAlphanumeric = false;
    //options.Password.RequireDigit = false;
    //options.Password.RequireLowercase = false;
    //options.Password.RequireUppercase = false;
    //options.Password.RequiredUniqueChars = 0;
    //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(1);
    //options.Lockout.MaxFailedAccessAttempts = 3;
    //options.Lockout.AllowedForNewUsers = false;
}).AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();


builder.Services.AddMvc();

//Service Lifetime can be controlled using three different methods:
//1. Singleton Service: a single instance will response all the requests
//Lifetime of singleton is till END of program.
//builder.Services.AddSingleton<IStudent, StudentRepository>();
//2. Scoped Service: a single instance will response all
//the request arising within its scope,
//and for each scope a new instance is created.
//Lifetime of such service is limited till end of scope.
//builder.Services.AddScoped<IStudent, StudentRepository>();
//3. Transient Service:a seperate instance will be created for each request.
//Lifetime of such service is limited till execution of that request.
//builder.Services.AddTransient<IStudent, StudentRepository>();




var app = builder.Build();

// Configure the HTTP request pipeline. FIFO
//in pipeline sequence of operation is very important. Operations must be in correct sequence.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    //this is a development environment and it will show detailed errors
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//Middlewares
app.UseHttpsRedirection();//it redirects to Https from Http

app.UseStaticFiles();//It enables use of files using url

app.UseRouting();//Endpoint / Path

app.UseAuthentication();//It is a login process

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
