using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Compartido;
using Compartido.Dto.Distribuidora;
using Compartido.Dto.Distribuidora.General;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Aplicacion
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdministrarNITController : ControllerBase
    {
        IAdministrarNITService _NITService;

        public AdministrarNITController(IAdministrarNITService nITService)
        {
            _NITService = nITService;
        }

        [HttpGet]
        public IActionResult ObtenerTodosLosNIT()
        {
            var result = new ServiceResponse<List<NITDTO>>();
            try
            {
                var response = _NITService.ObtenerTodoNIT().ToList();

                result.Data = response;
                result.Message = "Ok";
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
        public IActionResult InsertarNIT(NITDTO _NITDTO)
        {
            var result = new ServiceResponse<NITDTO>();
            try
            {
                var response = _NITService.GuardarNIT(_NITDTO);
                                
                result.Data = response;
                result.Message = "Ok";
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
        public IActionResult ActualizarNIT(NITDTO NITDTO)
        {
            var result = new ServiceResponse<NITDTO>();
            try
            {
                var response = _NITService.ActualizarNIT(NITDTO);

                result.Data = response;
                result.Message = "Ok";
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
        public IActionResult EliminarNIT(Guid id)
        {
            var result = new ServiceResponse<NITDTO>();
            try
            {
                _NITService.EliminarNIT(id);

                result.Data = null;
                result.Message = "Ok";
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
