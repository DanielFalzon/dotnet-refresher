global using SuperHeroAPI.Models;
global using Microsoft.EntityFrameworkCore;
global using SuperHeroAPI.Data;
using SuperHeroAPI.Services.SuperHeroService;
using SuperHeroAPI.Controllers;
using Microsoft.Extensions.Azure;
using SuperHeroAPI.Services.WeaponService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddScoped<ISuperHeroService, SuperHeroService>();
builder.Services.AddScoped<IWeaponService, WeaponService>();
//AddTransient and AddSingleton Available as well. Above can be used to replace which service and interface implements.

// Setup database connection

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    
//}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

