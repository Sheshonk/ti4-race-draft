using DomainObjects;
using DomainObjects.Entities;
using DomainObjects.Repositories;
using Microsoft.EntityFrameworkCore;
using ti4_race_draft_api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<TiContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("TI4-Race-Draft")));

builder.Services.AddScoped<IDbRepository<Draft>, DbRepository<Draft>>();
builder.Services.AddScoped<IDbRepository<Game>, DbRepository<Game>>();
builder.Services.AddScoped<IDbRepository<Group>, DbRepository<Group>>();
builder.Services.AddScoped<IDbRepository<Player>, DbRepository<Player>>();
builder.Services.AddScoped<IDbRepository<Race>, DbRepository<Race>>();
builder.Services.AddScoped<IDraftService, DraftService>();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IPlayerService, PlayerService>();

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
