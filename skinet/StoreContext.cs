using skinet.Entidades;
using System.Text.Json;

namespace skinet
{
    public class StoreContext
    {
        public static async Task SeedAsync( AplicationDbContext context)
        {
            if (!context.Productos.Any())
            {
                var datosproductos = await File.ReadAllTextAsync("../Datos/products.json");

                var productos = JsonSerializer.Deserialize<List<Producto>>(datosproductos);
                if (productos == null) return;
                context.Productos.AddRange(productos);

                await context.SaveChangesAsync();
            }
        }
    }
}
