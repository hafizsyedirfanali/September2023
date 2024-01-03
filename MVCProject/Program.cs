using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVCProject.Data;

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

var app = builder.Build();

// Configure the HTTP request pipeline. FIFO
//in pipeline sequence of operation is very important. Operations must be in correct sequence.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
