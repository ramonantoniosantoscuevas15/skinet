using Microsoft.AspNetCore.Mvc;
using skinet.Entidades;
using skinet.Interfaces;
using skinet.Migrations;
using skinet.RequestHelpers;

namespace skinet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        protected async Task<ActionResult> CrearPaginaResult<T>(IRepositorioGenerico<T> repositorio,
            IEspecificacion<T> espec,int paginaIndex, int cantidadPagina) where T: EntidadBasica
        {
            var objetos = await repositorio.ListaAsync(espec);
            var total = await repositorio.TotalAsync(espec);
            var paginacion = new Paginacion<T>(paginaIndex,cantidadPagina, total, objetos);
            return Ok(paginacion);
        }
    }
}
