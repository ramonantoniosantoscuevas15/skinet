using System.Linq.Expressions;

namespace skinet.Interfaces
{
    public interface IEspecificacion<T>
    {
        Expression<Func<T,bool>>? Criterio { get; }
        Expression<Func<T,object>>? Ordenarpor { get; }
        Expression<Func<T, object>>? OrdenarporDesc { get; }
        bool EsDistinto { get; }
    }
    public interface IEspecificacion<T, TResult> : IEspecificacion<T>
    {
        Expression<Func<T,TResult>>? Seleccionar { get; }
    }
}
