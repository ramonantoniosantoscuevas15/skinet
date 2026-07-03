using System.Linq.Expressions;

namespace skinet.Interfaces
{
    public interface IEspecificacion<T>
    {
        Expression<Func<T,bool>>? Criterio { get; }
        Expression<Func<T,object>>? Ordenarpor { get; }
        Expression<Func<T, object>>? OrdenarporDesc { get; }
        bool EsDistinto { get; }
        int Tomar { get; }
        int Omitir { get; }
        bool PaginacionHabilitada { get; }
        IQueryable<T> AplicarCriterio(IQueryable<T> query);
    }
    public interface IEspecificacion<T, TResult> : IEspecificacion<T>
    {
        Expression<Func<T,TResult>>? Seleccionar { get; }
    }
}
