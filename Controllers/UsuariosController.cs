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

        [HttpPost]
        [Route("CrearUsuario")]
        public IActionResult CrearUsuario(Usuario Ob)
        {
            try
            {
                _usuarios.PostCrearUsuario(Ob);
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Se ha creado un nuevo usuario" });
            }
            catch (Exception e)
            {

                throw new Exception(e.Message.ToString());
            }


        }

        [HttpGet]
        [Route("ListaDeUsuarios")]
        public async Task<List<Usuario>> ListaDeUsuarios()
        {
            try
            {
                return await Task.FromResult(_usuarios.GetAllUsuarios());

            }
            catch (Exception)
            {

                throw;
            }


        }

        [HttpPut]
        [Route("EditarUsuario")]
        public IActionResult EditarUsario(Usuario Ob)
        {
            try
            {
                _usuarios.PutEditarUsuario(Ob);
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Se ha editado el usuario correctamente" });
            }
            catch (Exception e)
            {

                throw new Exception(e.Message.ToString());

            }
        }

        [HttpDelete]
        [Route("EliminarUsuario")]
        public IActionResult EliminarUsuario(string mail)
        {
            try
            {
                _usuarios.DeleteUsuario(mail);
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Se ha eliminado el usuario" });
            }
            catch (Exception e)
            {

                throw new Exception(e.Message.ToString());
            }
        }
    }
}
