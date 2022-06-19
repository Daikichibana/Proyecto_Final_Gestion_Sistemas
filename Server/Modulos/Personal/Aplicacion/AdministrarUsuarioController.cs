using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Compartido;
using Compartido.Dto.Personal;
using Compartido.Dto.Personal.General;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Aplicacion
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdministrarUsuarioController : ControllerBase
    {
        IAdministrarUsuarioService _usuarioService;

        public AdministrarUsuarioController( IAdministrarUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult ObtenerTodoUsuarios()
        {

            var result = new ServiceResponse<List<UsuarioDTO>>();

            try
            {
                var response = _usuarioService.ObtenerTodoUsuario().ToList();

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

        [HttpPost]
        public IActionResult InsertarUsuario(UsuarioDTO usuarioDTO)
        {

            var result = new ServiceResponse<UsuarioDTO>();

            try
            {

                var response = _usuarioService.GuardarUsuario(usuarioDTO);

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

        [HttpPut]
        public IActionResult ActualizarUsuario(UsuarioDTO _usuarioDTO)
        {
            var result = new ServiceResponse<UsuarioDTO>();

            try
            {
                var response = _usuarioService.ActualizarUsuario(_usuarioDTO);

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

        [HttpDelete]
        public IActionResult EliminarUsuario(Guid id)
        {
            var result = new ServiceResponse<UsuarioDTO>();

            try
            {
                _usuarioService.EliminarUsuario(id);

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

        [HttpPost]
        public IActionResult AsignarRolesAUsuario(List<UsuariosRolesDTO> UsuarioRoles)
        {
            var result = new ServiceResponse<List<UsuariosRolesDTO>>();

            try
            {
                var response = _usuarioService.AsignarRolesAUsuario(UsuarioRoles);

                result.Data = (List<UsuariosRolesDTO>)response;
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

        [HttpPost]
        public IActionResult IniciarSesion(UsuarioDTO user)
        {
            var result = new ServiceResponse<IniciarSesionDTO>();

            try
            {
               var response = _usuarioService.IniciarSesion(user);

                result.Data = response;
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
