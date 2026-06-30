using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using skinet.Entidades;

namespace skinet.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductosController : ControllerBase
    {
        private readonly AplicationDbContext context;

        public ProductosController(AplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> Get()
        {
            return await context.Productos.ToListAsync();
        }
    }
}
