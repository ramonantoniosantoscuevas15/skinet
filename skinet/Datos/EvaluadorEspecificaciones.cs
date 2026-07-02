using skinet.Entidades;

using skinet.Interfaces;

namespace skinet.Datos
{
    public class EvaluadorEspecificaciones<T> where T : EntidadBasica
    {
        public static IQueryable<T> ObtenerQuery(IQueryable<T> query, IEspecificacion<T> espec)
        {
            if(espec.Criterio != null)
            {
                query = query.Where(espec.Criterio);
            }
            if(espec.Ordenarpor != null)
            {
                query = query.OrderBy(espec.Ordenarpor);
            }
            if(espec.OrdenarporDesc != null)
            {
                query = query.OrderByDescending(espec.OrdenarporDesc);
            }
            if(espec.EsDistinto)
            {
                query = query.Distinct();
            }
            return query;
        }

        public static IQueryable<TResult> ObtenerQuery<TSpec,TResult>(IQueryable<T> query, 
            IEspecificacion<T,TResult> espec)
        {
            if (espec.Criterio != null)
            {
                query = query.Where(espec.Criterio);
            }
            if (espec.Ordenarpor != null)
            {
                query = query.OrderBy(espec.Ordenarpor);
            }
            if (espec.OrdenarporDesc != null)
            {
                query = query.OrderByDescending(espec.OrdenarporDesc);
            }
            var queryseleccionado = query as IQueryable<TResult>;
            if(espec.Seleccionar != null)
            {
                queryseleccionado = query.Select(espec.Seleccionar);
            }
            if(espec.EsDistinto)
            {
                queryseleccionado = queryseleccionado?.Distinct();
            }
            return queryseleccionado ?? query.Cast<TResult>(); 
        }
    }
}
