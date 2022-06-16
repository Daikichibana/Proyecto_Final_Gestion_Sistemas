using System;
using System.Collections.Generic;
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
        IMapper _mapper;
        IAdministrarNITService _NITService;

        public AdministrarNITController(IMapper mapper, IAdministrarNITService nITService)
        {
            _mapper = mapper;
            _NITService = nITService;
        }

        [HttpGet]
        public IActionResult ObtenerTodosLosNIT()
        {
            ServiceResponse<List<NITDTO>> result = new ServiceResponse<List<NITDTO>>();
            try
            {
                var response = _NITService.ObtenerTodoNIT();

                result.Data = _mapper.Map<List<NITDTO>>(response);
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
            ServiceResponse<NITDTO> result = new ServiceResponse<NITDTO>();
            try
            {
                NIT nuevoNIT = _mapper.Map<NIT>(_NITDTO);
                var response = _NITService.GuardarNIT(nuevoNIT);

                result.Data = _mapper.Map<NITDTO>(response);
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
            ServiceResponse<NITDTO> result = new ServiceResponse<NITDTO>();
            try
            {
                NIT nuevoNIT = _mapper.Map<NIT>(NITDTO);
                var response = _NITService.ActualizarNIT(nuevoNIT);

                result.Data = _mapper.Map<NITDTO>(response);
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
            ServiceResponse<NITDTO> result = new ServiceResponse<NITDTO>();
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
