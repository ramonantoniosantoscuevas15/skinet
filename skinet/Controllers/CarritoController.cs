using Microsoft.AspNetCore.Mvc;
using skinet.Entidades;
using skinet.Interfaces;

namespace skinet.Controllers
{
    public class CarritoController(ICarritoServicios carritoServicios):BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<Carritocompras>> Obtenercarritoporid( string id)
        {
             var carrito = await carritoServicios.GetCarritoAsync(id);
            return Ok(carrito ?? new Carritocompras { id = id});

        }
        [HttpPost]
        public async Task<ActionResult<Carritocompras>> AptualizarCarrito(Carritocompras carrito)
        {
            var carritoActualizo = await carritoServicios.SetCarritoAsync(carrito);
            if (carritoActualizo == null) return BadRequest("Problema en el Carrito");
            return carritoActualizo;
        }
        [HttpDelete]
        public async Task<ActionResult> BorrarCarrito([FromQuery] string id)
        {
            var resultado = await carritoServicios.DeleteCarritoAsync(id);
            if(!resultado) return BadRequest("Problema al Borrar el Carrito");
            return Ok();
        }
    }
}
