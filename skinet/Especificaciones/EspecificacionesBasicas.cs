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

        protected void AgregarOrdenarpor(Expression<Func<T,object>> ordenarporExpresion)
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
