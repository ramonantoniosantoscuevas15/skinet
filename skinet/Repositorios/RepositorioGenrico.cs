using Microsoft.EntityFrameworkCore;
using skinet.Entidades;
using skinet.Interfaces;

namespace skinet.Repositorios
{
    public class RepositorioGenrico<T>(AplicationDbContext context) : IRepositorioGenerico<T> where T : EntidadBasica
    {
        public void Actualizar(T entidad)
        {
            context.Set<T>().Attach(entidad);
            context.Entry(entidad).State = EntityState.Modified;
        }

        public void Agregar(T entidad)
        {
            context.Set<T>().Add(entidad);
        }

        public void Borrar(T entidad)
        {
            context.Set<T>().Remove(entidad);
        }

        public bool Existe(int id)
        {
            return context.Set<T>().Any(e => e.id == id);
        }

        public async Task<bool> GuardarCambiosAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<IReadOnlyList<T>> ListadoAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T?> ObtenerporidAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }
    }
}
