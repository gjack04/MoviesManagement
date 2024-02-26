using Microsoft.EntityFrameworkCore;
using MoviesManagement.Data;
using MoviesManagement.Models;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connStr = builder.Configuration.GetConnectionString("Database");
builder.Services.AddSqlServer<MoviesDbContext>(connStr);
builder.Services.AddSingleton<Mapper>();
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

using(var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetService<MoviesDbContext>();
    ctx.Database.Migrate();

    if(!ctx.Technologies.Any())
    {
        string json = File.ReadAllText("Technologies.json");
        List<TechnologyJson>? techJson = 
            JsonSerializer.Deserialize<List<TechnologyJson>>(json);
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
