using FantasyGame.Configs;
using FantasyGame.DB;
using FantasyGame.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

if (!File.Exists("appsettings.json"))
{
    throw new Exception("File appsettings.json not found.");
}

//CONFIGURATION
builder.Configuration.AddJsonFile("appsettings.json", false, true);

builder.Services.Configure<SqlConfig>(builder.Configuration.GetSection("SqlConfig"));

//BASE
builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

//SWAGGER
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//SERVICES

//REPOSITORIES

//DATABASE
builder.Services.AddDbContext<AppDbContext>(ServiceLifetime.Scoped);

var app = builder.Build();

if(!app.Services.GetRequiredService<AppDbContext>().InitializeDatabase())
{
    throw new Exception("Failed to initialize database.");
}

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
