using Microsoft.AspNetCore.Mvc;
using skinet.DTOs;
using skinet.Entidades;

namespace skinet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BugController: BaseApiController
    {
        [HttpGet("noautorizado")]
        public IActionResult GetNoAutorizado()
        {
            return Unauthorized();
        }
        [HttpGet("badrequest")]
        public IActionResult GetBadrequest()
        {
            return BadRequest("No es un good request");
        }

        [HttpGet("notfound")]
        public IActionResult GetNotfoundt()
        {
            return NotFound();
        }
        [HttpGet("internalerror")]
        public IActionResult GetInternalError()
        {
            throw new Exception("this is an internal error");
        }
        [HttpPost("validationerror")]
        public IActionResult GetValidationError([FromBody] CrearProductoDto producto)
        {
            return Ok();
        }

    }
}
