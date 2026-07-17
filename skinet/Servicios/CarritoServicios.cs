using skinet.Entidades;
using skinet.Interfaces;
using StackExchange.Redis;
using System.Text.Json;

namespace skinet.Servicios
{
    public class CarritoServicios(IConnectionMultiplexer redis) : ICarritoServicios
    {
        private readonly IDatabase _database = redis.GetDatabase();
        public async Task<bool> DeleteCarritoAsync(string key)
        {
            return await _database.KeyDeleteAsync(key);
        }

        public async Task<Carritocompras?> GetCarritoAsync(string key)
        {
            var dato = await _database.StringGetAsync(key);

            return dato.IsNullOrEmpty ? null : JsonSerializer.Deserialize<Carritocompras>(dato!);
        }

        public async Task<Carritocompras?> SetCarritoAsync(Carritocompras carrito)
        {
           var creado = await _database.StringSetAsync(carrito.id,JsonSerializer.Serialize(carrito),TimeSpan.
               FromDays(30));
            if(!creado) return null;
            return await GetCarritoAsync(carrito.id);
        }
    }
}
