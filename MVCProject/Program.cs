using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MVCProject.Data;
using MVCProject.Interfaces;
using MVCProject.Repositories;
using System.Globalization;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var clientId = "767081774260-cfjc1v0io5nj8jfs66n85grnbsteem7i.apps.googleusercontent.com";
var clientSecret = "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";
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");


builder.Services.AddDbContextPool<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;//Confirm Email
    //options.SignIn.RequireConfirmedPhoneNumber = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredUniqueChars = 1;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(1);
    options.Lockout.MaxFailedAccessAttempts = 3;
    options.Lockout.AllowedForNewUsers = true;
}).AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddGoogle(googleOptions =>
{
    googleOptions.ClientId = clientId;
    googleOptions.ClientSecret = clientSecret;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration.GetSection("JwtSettings:Issuer").Value,
        ValidAudience = builder.Configuration.GetSection("JwtSettings:Audience").Value,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JwtSettings:Key").Value!)),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});
builder.Services.AddAuthorization();//Enables classification of users


builder.Services.AddMvc();

//Service Lifetime can be controlled using three different methods:
//1. Singleton Service: a single instance will response all the requests
//Lifetime of singleton is till END of program.
builder.Services.AddSingleton<IStudent, StudentRepository>();

//2. Scoped Service: a single instance will response all
//the request arising within its scope,
//and for each scope a new instance is created.
//Lifetime of such service is limited till end of scope.
//builder.Services.AddScoped<IStudent, StudentRepository>();
//3. Transient Service:a separate instance will be created for each request.
//Lifetime of such service is limited till execution of that request.
//builder.Services.AddTransient<IStudent, StudentRepository>();
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddTransient<IEmailSender, MailService>();

builder.Services.AddLocalization(options =>
{
    options.ResourcesPath = "Resources";
});
builder.Services.AddMvc().AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new List<CultureInfo>
    {
        new CultureInfo("en"),
        new CultureInfo("hi"),
        new CultureInfo("mr"),
    };
    options.DefaultRequestCulture = new RequestCulture("en");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});


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

app.UseAuthorization();// its for classification of user


app.UseRequestLocalization(((IApplicationBuilder)app).ApplicationServices.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);


app.MapControllerRoute(
    name: "MyArea",
    pattern: "{area:exists}/{controller=EnquiryHome}/{action=Index}/{id?}");


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
