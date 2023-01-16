using DomainObjects;
using DomainObjects.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<TiContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("TI4-Race-Draft")));

//builder.Services.AddScoped<IDbRepository<Episode>, DbRepository<Episode>>();\

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

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<TiContext>();
    dbContext.Database.Migrate();
}

app.Run();
