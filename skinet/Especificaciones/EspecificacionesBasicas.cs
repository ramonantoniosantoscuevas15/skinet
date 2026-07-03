using skinet.Especificaciones;
using skinet.Interfaces;
using System.Linq.Expressions;
using System.Security.Cryptography;

namespace skinet.Especificaciones
{
    public class EspecificacionesBasicas<T>(Expression<Func<T, bool>>? criterio) : IEspecificacion<T>
    {
        protected EspecificacionesBasicas() : this(null)
        {
        }

        public Expression<Func<T, bool>>? Criterio => criterio;

        public Expression<Func<T, object>>? Ordenarpor { get; private set; }

        public Expression<Func<T, object>>? OrdenarporDesc { get; private set; }

        public bool EsDistinto { get; private set; }

        public int Tomar { get; private set; }

        public int Omitir { get; private set; }

        public bool PaginacionHabilitada { get; private set; }

        public IQueryable<T> AplicarCriterio(IQueryable<T> query)
        {
            if(Criterio != null)
            {
                query = query.Where(Criterio);
            }
            return query;
        }

        protected void AgregarOrdenarpor(Expression<Func<T, object>> ordenarporExpresion)
        {
            Ordenarpor = ordenarporExpresion;
        }
        protected void AgregarOrdenarporDesc(Expression<Func<T, object>> ordenarporDescExpresion)
        {
            OrdenarporDesc = ordenarporDescExpresion;
        }
        protected void AplicarDistincion()
        {
            EsDistinto = true;
        }
        protected void AplicarPaginacion(int omitir, int tomar)
        {
            Omitir = omitir;
            Tomar = tomar;
            PaginacionHabilitada = true;
        }
    }
}
public class EspecificacionesBasicas<T, TResult>(Expression<Func<T, bool>> criterio) : EspecificacionesBasicas<T>(criterio),
    IEspecificacion<T, TResult>
{
    protected EspecificacionesBasicas() : this(null!)
    {
    }
    public Expression<Func<T, TResult>>? Seleccionar { get; private set; }

    protected void AgregarSeleccion(Expression<Func<T,TResult>> SeleccionExpresion)
    {
        Seleccionar = SeleccionExpresion;
    }
}
