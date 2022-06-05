using AutoMapper;
using CAPAS.CAPA.DOMINIO;
using CAPAS.CAPA.DOMINIO.USUARIOS.ABSTRACCIONES;
using CAPAS.CAPA.DOMINIO.USUARIOS.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CAPA.APLICACION.Controllers.Usuarios
{
    /// <summary>
    ///  
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class IniciarSesionController : ControllerBase
    {
        IMapper _mapper;
        IIniciarSesionService _sesionService;
        /// <summary>
        ///  
        /// </summary>
        public IniciarSesionController(IMapper mapper, IIniciarSesionService sesionService)
        {
            _mapper = mapper;
            _sesionService = sesionService;
        }

        /// <summary>
        ///  
        /// </summary>
        [HttpPost]
        public IActionResult ValidarUsuario(ValidarUsuarioDTO user)
        {
            var result = new ServiceResponse<bool>();

            try
            {
                bool response = _sesionService.ValidarUsuario(user.NombreUsuario, user.Clave);

                result.Data = response;
                result.Success = true;
                result.Message = "ok";

                return Ok(result);
            }
            catch (Exception error)
            {
                result.Data = false;
                result.Success = false;
                result.Message = error.Message;

                return BadRequest(result);
            }
        }
    }
}
