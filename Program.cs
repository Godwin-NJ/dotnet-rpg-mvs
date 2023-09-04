global using dotnet_rpg_nd.Models;
global using dotnet_rpg_nd.Services.CharacterService;
global using AutoMapper;
global using Microsoft.EntityFrameworkCore;
global using dotnet_rpg_nd.Data;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DataContext>(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); //connection with Db
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);//registering auto-mapper for usage
builder.Services.AddScoped<ICharacterService, CharacterService>(); 
//the abv will direct all controllers using IcharacterService to impliment with characterService class 

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
