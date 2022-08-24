using ADOAPI.Models;
using ADOAPI.Services.Interfaces;
using ADOAPI.Services.Logica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ADOAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinoController : ControllerBase
    {
        private readonly IDestinos _destino;

        public DestinoController(IDestinos destino)
        {
            _destino = destino;
        }

        [HttpPost]
        [Route("CrearDestino")]
        public IActionResult CrearDestino(Destino Ob)
        {
            try
            {
                _destino.PostCrearDestino(Ob);
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Se ha creado un nuevo destino" });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = e.Message });
                //throw new Exception(e.Message.ToString());
            }


        }

        [HttpGet]
        [Route("ListaDeDestinos")]
        public async Task<List<Destino>> ListaDeDestinos()
        {
            try
            {
                return await Task.FromResult(_destino.GetAllDestino());

            }
            catch (Exception e)
            {

                throw new Exception(e.Message.ToString());
            }


        }

        [HttpPut]
        [Route("EditarDestino")]
        public IActionResult EditarDestino(Destino Ob)
        {
            try
            {
                _destino.PutEditarDestino(Ob);
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Se ha editado el destino correctamente" });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = e.Message });
                //throw new Exception(e.Message.ToString());

            }
        }

        [HttpDelete]
        [Route("EliminarUsuario")]
        public IActionResult EliminarDestino(int id)
        {
            try
            {
                _destino.DeleteDestino(id);
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Se ha eliminado el destino" });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = e.Message });
                //throw new Exception(e.Message.ToString());
            }
        }
    }
}
