using ADOAPI.Models;
using ADOAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ADOAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarios _usuarios;

        public UsuariosController(IUsuarios usuarios)
        {
            _usuarios = usuarios;
        }

        [HttpPost("CrearUsuario")]
        public async Task<ActionResult<string>> CrearUsuario([FromBody] Usuario Ob)
        {
            try
            {
                var response = await _usuarios.PostCrearUsuario(Ob);

                return Ok(response);

                //return StatusCode(StatusCodes.Status200OK, new { mensaje = "Se ha creado un nuevo usuario" });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
                //throw new Exception(e.Message.ToString());
            }

          
        }

        [HttpGet("ListaDeUsuarios")]
        public async Task<ActionResult<List<Usuario>>>  ListaDeUsuarios()
        {
            try
            {
               var userList =  await _usuarios.GetAllUsuarios();

                return Ok(userList);

            }
            catch (Exception e)
            {

                throw new Exception(e.Message.ToString());
            }


        }

        [HttpPut("EditarUsuario")]
        public async Task<ActionResult<string>> EditarUsario([FromBody] Usuario Ob)
        {
            try
            {
                var response = await _usuarios.PutEditarUsuario(Ob);
                return Ok(response);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        [HttpDelete("EliminarUsuario")]
        public async Task<ActionResult<string>> EliminarUsuario([FromBody] string mail)
        {
            try
            {
                var response = await _usuarios.DeleteUsuario(mail);
                return Ok(response);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }
    }
}
