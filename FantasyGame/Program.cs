var builder = WebApplication.CreateBuilder(args);

//CONTROLLERS
builder.Services.AddControllers();

//SWAGGER
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//SERVICES

//REPOSITORIES

//DATABASE

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
