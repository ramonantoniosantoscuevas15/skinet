using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using skinet.Entidades;
using skinet.Interfaces;

namespace skinet.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductosController(IProductoRepositorio repositorio) : ControllerBase
    {
        
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Producto>>> Get(string? marca,string?tipo,string?orden)
        {
           return Ok(await repositorio.ObtenerProductosAsync(marca,tipo,orden));
        }
        [HttpGet("{id:int}", Name = "obtenerporid")]
        public async Task<ActionResult<Producto>> Get(int id)
        {
            var producto = await repositorio.OptenerProductoporidAsync(id);
            if(producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }
        [HttpPost]
        public async Task<ActionResult<Producto>> Post(Producto producto)
        {
            repositorio.AgregarProducto(producto);
            if(await repositorio.SaveChangesAsync())
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
            repositorio.ActualizarProducto(producto);
            if (await repositorio.SaveChangesAsync())
            {
                return NoContent();
            }
            return BadRequest("Problema al Actualizar el Producto");

        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var producto =  await repositorio.OptenerProductoporidAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            repositorio.BorrarProducto(producto);
            if (await repositorio.SaveChangesAsync())
            {
                return NoContent();
            }
            return BadRequest("Problema al Borrar el Producto");

        }
        [HttpGet("marcas")]
        public async Task<ActionResult<IReadOnlyList<string>>> GetMarcas()
        {
            return Ok(await repositorio.ObtenerMarcaAsync());
        }
        [HttpGet("tipos")]
        public async Task<ActionResult<IReadOnlyList<string>>> GetTipos()
        {
            return Ok(await repositorio.ObtenerTipoAsync());
        }

        private bool ProductoExistente(int id)
        {
            return repositorio.ExisteProducto(id);
        }
    }
}
