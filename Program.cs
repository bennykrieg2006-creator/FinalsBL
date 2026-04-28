using FinalsBL.Data;
using FinalsBL.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// EF Core
builder.Services.AddDbContext<DB>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// NSwag
builder.Services.AddOpenApiDocument(config =>
{
    config.Title = "Final Project API";
    config.Version = "v1";
});

var app = builder.Build();

// Apply migrations automatically at startup (prevents “db doesn’t exist” issues)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DB>();
    db.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();