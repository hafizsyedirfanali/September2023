using APIProject.Interfaces;
using APIProject.Repositories;
using JWTProject;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.RegisterJWTService(builder.Configuration);
builder.Services.AddTransient<IStudentAPI, StudentAPIRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
