using System;
using System.Collections.Generic;
using AutoMapper;
using Compartido;
using Compartido.Dto.Personal;
using Compartido.Dto.Personal.General;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Aplicacion
{
    /// <summary>
    ///  
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AdministrarRolesController : ControllerBase
    {
        IMapper _mapper;
        IAdministrarRolService _rolService;

        /// <summary>
        ///  
        /// </summary>
        public AdministrarRolesController(IMapper mapper, IAdministrarRolService rolService)
        {
            _mapper = mapper;
            _rolService = rolService;
        }

        /// <summary>
        ///  
        /// </summary>
        [HttpGet]
        public IActionResult ObtenerTodoRoles()
        {

            var result = new ServiceResponse<List<RolDTO>>();

            try
            {
                IList<Rol> roles = _rolService.ObtenerTodo();
                List<RolDTO> response = new List<RolDTO>();

                foreach (var rol in roles)
                {
                    response.Add(_mapper.Map<RolDTO>(rol));
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
        public IActionResult InsertarUsuario(RolDTO _rolDTO)
        {

            var result = new ServiceResponse<RolDTO>();

            try
            {
                Rol nuevoRol = _mapper.Map<Rol>(_rolDTO);

                var response = _rolService.Guardar(nuevoRol);

                result.Data = _mapper.Map<RolDTO>(response);
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
        public IActionResult ActualizarUsuario(RolDTO _rolDTO)
        {
            var result = new ServiceResponse<RolDTO>();

            try
            {
                Rol nuevoRol = _mapper.Map<Rol>(_rolDTO);
                var response = _rolService.Actualizar(nuevoRol);

                result.Data = _mapper.Map<RolDTO>(response);
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
                _rolService.Eliminar(id);

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
