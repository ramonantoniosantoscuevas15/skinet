using Microsoft.EntityFrameworkCore;
using skinet.Datos;
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

        public async Task<IReadOnlyList<T>> ListaAsync(IEspecificacion<T> espec)
        {
            return await AplicarSpecificacion(espec).ToListAsync();
        }

        public async Task<IReadOnlyList<TResult>> ListaAsync<TResult>(IEspecificacion<T, TResult> espec)
        {
            return await AplicarSpecificacion(espec).ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListadoAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public Task<IReadOnlyList<T>> ListadotodoAsync()
        {
            throw new NotImplementedException();
        }

        

        public async Task<T?> ObtenerentidadconEspec(IEspecificacion<T> espec)
        {
            return await AplicarSpecificacion(espec).FirstOrDefaultAsync();
        }

        public async Task<TResult?> ObtenerentidadconEspec<TResult>(IEspecificacion<T, TResult> espec)
        {
            return await AplicarSpecificacion(espec).FirstOrDefaultAsync();
        }

        public async Task<T?> ObtenerporidAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<int> TotalAsync(IEspecificacion<T> espec)
        {
            var query = context.Set<T>().AsQueryable();
            query= espec.AplicarCriterio(query);
            return await query.CountAsync();
        }

        private IQueryable<T> AplicarSpecificacion(IEspecificacion<T> espec)
        {
            return EvaluadorEspecificaciones<T>.ObtenerQuery(context.Set<T>().AsQueryable(), espec);
        }
        private IQueryable<TResult> AplicarSpecificacion<TResult>(IEspecificacion<T, TResult> espec)
        {
            return EvaluadorEspecificaciones<T>.ObtenerQuery<T,TResult>(context.Set<T>().AsQueryable(), espec);
        }
    }
}
