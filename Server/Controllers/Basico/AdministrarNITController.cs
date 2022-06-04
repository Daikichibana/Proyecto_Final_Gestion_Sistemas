using AutoMapper;
using CAPAS.CAPA.DOMINIO;
using CAPAS.CAPA.DOMINIO.BASICO.ABSTRACCIONES;
using CAPAS.CAPA.DOMINIO.BASICO.DTO;
using CAPAS.CAPA.DOMINIO.BASICO.ENTIDADES;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Proyecto_Final_Gestion_Sistemas.Server.Controllers.Basico
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministrarNITController : ControllerBase
    {
        IMapper _mapper;
        INITService _NITService;

        public AdministrarNITController(IMapper mapper, INITService nITService)
        {
            _mapper = mapper;
            _NITService = nITService;
        }

        [HttpGet]
        public IActionResult ObtenerTodosLosNIT()
        {
            ServiceResponse<NITDTO> result = new ServiceResponse<NITDTO>();
            try
            {
                var response = _NITService.ObtenerTodo();

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
        [HttpPost]
        public IActionResult InsertarNIT(NITDTO _NITDTO)
        {
            ServiceResponse<NITDTO> result = new ServiceResponse<NITDTO>();
            try
            {
                NIT nuevoNIT = _mapper.Map<NIT>(_NITDTO);
                var response = _NITService.Guardar(nuevoNIT);

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
                var response = _NITService.Actualizar(nuevoNIT);

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
                _NITService.Eliminar(id);

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
