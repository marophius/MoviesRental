using Microsoft.EntityFrameworkCore;
using MoviesRental.Api.Setup;
using MoviesRental.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApiConfig(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetService<MoviesRentalWriteContext>();
    var migrations = await context.Database.GetPendingMigrationsAsync();

    if(migrations is not null)
        await context.Database.MigrateAsync();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
