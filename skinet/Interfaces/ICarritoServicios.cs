using skinet.Entidades;

namespace skinet.Interfaces
{
    public interface ICarritoServicios
    {
        Task<Carritocompras?> GetCarritoAsync(string key);
        Task<Carritocompras?> SetCarritoAsync(Carritocompras carrito);
        Task<bool> DeleteCarritoAsync(string key);
    }
}
