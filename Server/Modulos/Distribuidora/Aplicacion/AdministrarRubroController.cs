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
    public class AdministrarRubroController : ControllerBase
    {
        IMapper _mapper;
        IAdministrarRubroService _administrarRubroService;
        public AdministrarRubroController(IMapper mapper, IAdministrarRubroService administrarRubroService)
        {
            _mapper = mapper;
            _administrarRubroService = administrarRubroService;
        }

        [HttpGet]
        public IActionResult ObtenerTodosLosRubros()
        {
            ServiceResponse<List<RubroDTO>> result = new ServiceResponse<List<RubroDTO>>();
            try
            { 
                var response = _administrarRubroService.ObtenerTodoRubro();

                result.Data = _mapper.Map<List<RubroDTO>>(response);
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
        public IActionResult InsertarRubro(RubroDTO _RubroDTO)
        {
            ServiceResponse<RubroDTO> result = new ServiceResponse<RubroDTO>();
            try
            {
                Rubro nuevoRubro = _mapper.Map<Rubro>(_RubroDTO);
                var response = _administrarRubroService.GuardarRubro(nuevoRubro);

                result.Data = _mapper.Map<RubroDTO>(response);
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
        public IActionResult ActualizarRubro(RubroDTO RubroDTO)
        {
            ServiceResponse<RubroDTO> result = new ServiceResponse<RubroDTO>();
            try
            {
                Rubro nuevoRubro = _mapper.Map<Rubro>(RubroDTO);
                var response = _administrarRubroService.ActualizarRubro(nuevoRubro);

                result.Data = _mapper.Map<RubroDTO>(response);
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
        public IActionResult EliminarRubro(Guid id)
        {
            ServiceResponse<RubroDTO> result = new ServiceResponse<RubroDTO>();
            try
            {
                _administrarRubroService.EliminarRubro(id);

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
