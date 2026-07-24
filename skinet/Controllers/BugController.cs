using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using skinet.DTOs;
using skinet.Entidades;
using System.Security.Claims;

namespace skinet.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BugController: BaseApiController
    {
        [AllowAnonymous]
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

        [HttpGet("secreto")]
        public IActionResult GetSecreto()
        {
            var nombre = User.FindFirst(ClaimTypes.Name)?.Value;
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Ok(" Hola " + nombre + " Con el id " +  id);

        }


    }
}
