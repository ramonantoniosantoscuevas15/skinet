using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using skinet.Entidades;
using skinet.Especificaciones;
using skinet.Interfaces;


namespace skinet.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductosController(IRepositorioGenerico<Producto>repositorio) : ControllerBase
    {
        
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Producto>>> Get(string? marca,string?tipo,string orden)
        {
            var espec = new ProductoEspecificacion(marca,tipo,orden);
            var productos = await repositorio.ListaAsync(espec);
            return Ok(productos);
        }
        [HttpGet("{id:int}", Name = "obtenerporid")]
        public async Task<ActionResult<Producto>> Get(int id)
        {
            var producto = await repositorio.ObtenerporidAsync(id);
            if(producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }
        [HttpPost]
        public async Task<ActionResult<Producto>> Post(Producto producto)
        {
            repositorio.Agregar(producto);
            if(await repositorio.GuardarCambiosAsync())
            {
                return CreatedAtRoute("obtenerporid", new {id = producto.id},producto);
            }
            return BadRequest("Problema al Crear un Producto");
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id,Producto producto)
        {
            if(producto.id != id || !ProductoExistente(id))
            {
                return BadRequest("No se Puede Actualizar este Producto");
            }
            repositorio.Actualizar(producto);
            if (await repositorio.GuardarCambiosAsync())
            {
                return NoContent();
            }
            return BadRequest("Problema al Actualizar el Producto");

        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var producto =  await repositorio.ObtenerporidAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            repositorio.Borrar(producto);
            if (await repositorio.GuardarCambiosAsync())
            {
                return NoContent();
            }
            return BadRequest("Problema al Borrar el Producto");

        }
        [HttpGet("marcas")]
        public async Task<ActionResult<IReadOnlyList<string>>> GetMarcas()
        {
            var espec = new MarcaListEspecificacion();
            return Ok(await repositorio.ListaAsync(espec));
        }
        [HttpGet("tipos")]
        public async Task<ActionResult<IReadOnlyList<string>>> GetTipos()
        {
            var espec = new TipoListEspecificacion();
            return Ok(await repositorio.ListaAsync(espec));
        }

        private bool ProductoExistente(int id)
        {
            return repositorio.Existe(id);
        }
    }
}
