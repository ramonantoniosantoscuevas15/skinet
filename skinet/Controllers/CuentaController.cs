using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using skinet.DTOs;
using skinet.Entidades;
using System.Security.Claims;
using skinet.Extensiones;

namespace skinet.Controllers
{
    public class CuentaController(SignInManager<AppUsusario> signInManager) : BaseApiController
    {
        [HttpPost("registro")]
        public async Task<ActionResult> Registro(RegistroDto registroDto)
        {
            var usuario = new AppUsusario
            {
                nombre = registroDto.nombre,
                apellido = registroDto.apellido,
                Email = registroDto.Email,
                UserName = registroDto.Email,

            };
            var resultado = await signInManager.UserManager.CreateAsync(usuario, registroDto.Password);
            if(!resultado.Succeeded)
            {
                foreach (var  error in resultado.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return ValidationProblem();
            }
            return Ok();
        }
        [Authorize]
        [HttpPost("logout")]
        public async Task<ActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return NoContent();
        }
        
        [HttpGet("usuario-info")]
        public async Task<ActionResult> GetUsuarioInfo() 
        { 
            if(User.Identity?.IsAuthenticated == false) return NoContent();

            var usuario = await signInManager.UserManager.GetUsuarioporEmailConDireccion(User);
            

            return Ok(new
            {
                usuario.nombre,
                usuario.apellido,
                usuario.Email,
                direccion = usuario.direccion?.ADto()

            });
        }
        [HttpGet]
        public ActionResult GetEstadoAutorizado() 
        { 
            return Ok(new {EstaAutorizado = User.Identity?.IsAuthenticated ?? false});
        }
        [Authorize]
        [HttpPost("direccion")]
        public async Task<ActionResult<Direccion>> CrearoActualizarDireccion(DireccionDto direccionDto)
        {
            var usuario = await signInManager.UserManager.GetUsuarioporEmailConDireccion(User);

            if(usuario.direccion == null)
            {
                usuario.direccion = direccionDto.AEntidad();
            }
            else
            {
                usuario.direccion.ActualizarDeDto(direccionDto);
            }
            var resultado = await signInManager.UserManager.UpdateAsync(usuario);

            if (!resultado.Succeeded) return BadRequest("Problema Actualizando la direccion del usuario");

            return Ok(usuario.direccion.ADto());
        }

    }
}
