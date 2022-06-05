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
    [Route("api/[controller]")]
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

    }
}
