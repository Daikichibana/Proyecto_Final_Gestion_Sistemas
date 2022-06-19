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
    public class AdministrarRolesController : ControllerBase
    {
        IAdministrarRolService _rolService;

        public AdministrarRolesController(IAdministrarRolService rolService)
        {
            _rolService = rolService;
        }

        [HttpGet]
        public IActionResult ObtenerTodoRoles()
        {

            var result = new ServiceResponse<List<RolDTO>>();

            try
            {
                var response = _rolService.ObtenerTodoRol().ToList();

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
        public IActionResult InsertarRol(RolDTO _rolDTO)
        {

            var result = new ServiceResponse<RolDTO>();

            try
            {

                var response = _rolService.GuardarRol(_rolDTO);

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
        public IActionResult ActualizarRol(RolDTO _rolDTO)
        {
            var result = new ServiceResponse<RolDTO>();

            try
            {
                var response = _rolService.ActualizarRol(_rolDTO);

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
        public IActionResult EliminarRol(Guid id)
        {
            var result = new ServiceResponse<RolDTO>();

            try
            {
                _rolService.EliminarRol(id);

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
