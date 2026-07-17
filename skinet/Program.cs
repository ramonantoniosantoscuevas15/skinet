using Microsoft.EntityFrameworkCore;
using skinet;
using skinet.Interfaces;
using skinet.Middleware;
using skinet.Repositorios;
using skinet.Servicios;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<AplicationDbContext>(opciones => opciones.UseSqlServer("name=DefaultConnection"));
builder.Services.AddScoped<IProductoRepositorio, ProductoRepositorio>();
builder.Services.AddScoped(typeof(IRepositorioGenerico<>), typeof(RepositorioGenrico<>));
builder.Services.AddSingleton<IConnectionMultiplexer>(config =>
{
    var connstring = builder.Configuration.GetConnectionString("Redis") ?? throw new Exception("No se encontro la cadena de conexion para Redis");
    var options = ConfigurationOptions.Parse(connstring, true);
    return ConnectionMultiplexer.Connect(options);
});
builder.Services.AddSingleton<ICarritoServicios, CarritoServicios>();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
var origenesPermitidos = builder.Configuration.GetValue<string>("origenesPermitidos")!.Split(",");
builder.Services.AddCors(opciones => {
    opciones.AddDefaultPolicy(configuracion =>
    {
        configuracion.WithOrigins(origenesPermitidos).AllowAnyMethod().AllowAnyHeader();
        
    });
    opciones.AddPolicy("libre", configuracion =>
    {
        configuracion.WithOrigins(origenesPermitidos).AllowAnyHeader().AllowAnyMethod();
    });
});
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
app.UseMiddleware<ExeceptionMiddleware>();
app.UseCors();

app.MapControllers();

app.Run();
