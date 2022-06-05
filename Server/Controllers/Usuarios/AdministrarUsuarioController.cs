using AutoMapper;
using CAPAS.CAPA.DOMINIO;
using CAPAS.CAPA.DOMINIO.USUARIOS.ABSTRACCIONES;
using CAPAS.CAPA.DOMINIO.USUARIOS.DTO;
using CAPAS.CAPA.DOMINIO.USUARIOS.ENTIDADES;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CAPA.APLICACION.Controllers.Usuarios
{
    /// <summary>
    ///  
    /// </summary>
    //[Route("api/[controller]")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdministrarUsuarioController : ControllerBase
    {
        IMapper _mapper;
        IAdministrarUsuarioService _usuarioService;
        /// <summary>
        ///  
        /// </summary>
        public AdministrarUsuarioController(IMapper mapper, IAdministrarUsuarioService usuarioService)
        {
            _mapper = mapper;
            _usuarioService = usuarioService;
        }

        /// <summary>
        ///  
        /// </summary>
        [HttpGet]
        public IActionResult ObtenerTodoUsuarios()
        {

            var result = new ServiceResponse<List<UsuarioDTO>>();

            try
            {
                IList<Usuario> usuarios = _usuarioService.ObtenerTodo();
                List<UsuarioDTO> response = new List<UsuarioDTO>();

                foreach (var usuario in usuarios)
                {
                    response.Add(_mapper.Map<UsuarioDTO>(usuario));
                }

                result.Data = response;
                result.Message = "Se ha realizado la operacion correctamente.";
                result.Success = true;

                return Ok(result);
            }
            catch (Exception error)
            {
                result.Data = null;
                result.Message = error.Message;
                result.Success = false;

                return BadRequest(result);
            }
        }

        /// <summary>
        ///  
        /// </summary>
        [HttpPost]
        public IActionResult InsertarUsuario(UsuarioDTO usuarioDTO)
        {

            var result = new ServiceResponse<UsuarioDTO>();

            try
            {
                Usuario nuevoUsuario = _mapper.Map<Usuario>(usuarioDTO);

                var response = _usuarioService.Guardar(nuevoUsuario);

                result.Data = _mapper.Map<UsuarioDTO>(response);
                result.Message = "Se ha realizado la operacion correctamente.";
                result.Success = true;

                return Ok(result);
            }
            catch (Exception error)
            {
                result.Data = null;
                result.Message = error.Message;
                result.Success = false;

                return BadRequest(result);
            }
        }

        /// <summary>
        ///  
        /// </summary>
        [HttpPut]
        public IActionResult ActualizarUsuario(UsuarioDTO _usuarioDTO)
        {
            var result = new ServiceResponse<UsuarioDTO>();

            try
            {
                Usuario nuevoUsuario = _mapper.Map<Usuario>(_usuarioDTO);
                var response = _usuarioService.Actualizar(nuevoUsuario);

                result.Data = _mapper.Map<UsuarioDTO>(response);
                result.Message = "Se ha realizado la operacion correctamente.";
                result.Success = true;

                return Ok(result);
            }
            catch (Exception error)
            {
                result.Data = null;
                result.Message = error.Message;
                result.Success = false;

                return BadRequest(result);
            }
        }

        /// <summary>
        ///  
        /// </summary>
        [HttpDelete]
        public IActionResult EliminarUsuario(Guid id)
        {
            var result = new ServiceResponse<UsuarioDTO>();

            try
            {
                _usuarioService.Eliminar(id);

                result.Data = null;
                result.Message = "Se ha realizado la operacion correctamente.";
                result.Success = true;

                return Ok(result);

            }
            catch (Exception error)
            {
                result.Data = null;
                result.Message = error.Message;
                result.Success = false;

                return BadRequest(result);
            }
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
                bool response = _usuarioService.ValidarUsuario(user.NombreUsuario, user.Clave);

                result.Data = response;
                result.Success = true;
                result.Message = "Se ha realizado la operacion correctamente.";

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

        /// <summary>
        ///  
        /// </summary>
        [HttpGet]
        public IActionResult ObtenerUsuarioPorNombre(string nombre)
        {
            var result = new ServiceResponse<UsuarioDTO>();

            try
            {
                Usuario response = _usuarioService.ObtenerUsuarioPorNombre(nombre);

                result.Data = _mapper.Map<UsuarioDTO>(response);
                result.Success = true;
                result.Message = "Se ha realizado la operacion correctamente.";

                return Ok(result);
            }
            catch (Exception error)
            {
                result.Data = null;
                result.Success = false;
                result.Message = error.Message;

                return BadRequest(result);
            }
        }

    }
}
