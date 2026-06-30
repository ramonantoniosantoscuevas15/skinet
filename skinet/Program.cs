using Microsoft.EntityFrameworkCore;
using skinet;
using skinet.Interfaces;
using skinet.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<AplicationDbContext>(opciones => opciones.UseSqlServer("name=DefaultConnection"));
builder.Services.AddScoped<IProductoRepositorio, ProductoRepositorio>();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

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
