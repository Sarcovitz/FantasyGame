using FantasyGame.Configs;
using FantasyGame.DB;
using FantasyGame.Extensions;
using FantasyGame.Services;
using FantasyGame.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;
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
builder.Services.AddScoped<IAuthService, AuthService>();

//REPOSITORIES

//DATABASE
builder.Services.AddDbContext<AppDbContext>(ServiceLifetime.Scoped);

//AUTHENTICATION
string? jwtSecret = builder.Configuration.GetValue<string>("JwtConfig:Key");
if (string.IsNullOrEmpty(jwtSecret) || jwtSecret.Length != 32)
{
    throw new Exception("JWT Key is null or empty or its length is different that 32 charaters.");
}

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

var app = builder.Build();

//DATABASE INITIALIZATION
if(!app.Services.GetRequiredService<IHost>().InitializeDatabase<AppDbContext>())
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
