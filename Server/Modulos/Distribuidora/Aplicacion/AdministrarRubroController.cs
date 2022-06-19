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
    public class AdministrarRubroController : ControllerBase
    {
        IAdministrarRubroService _administrarRubroService;
        public AdministrarRubroController(IAdministrarRubroService administrarRubroService)
        {
            _administrarRubroService = administrarRubroService;
        }

        [HttpGet]
        public IActionResult ObtenerTodosLosRubros()
        {
            ServiceResponse<List<RubroDTO>> result = new ServiceResponse<List<RubroDTO>>();
            try
            { 
                var response = _administrarRubroService.ObtenerTodoRubro().ToList();

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
        public IActionResult InsertarRubro(IList<RubroDTO> _RubroDTO)
        {
            ServiceResponse<IList<RubroDTO>> result = new ServiceResponse<IList<RubroDTO>>();
            try
            {
                var response = _administrarRubroService.GuardarRubro(_RubroDTO).ToList();

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
        public IActionResult ActualizarRubro(IList<RubroDTO> rubroDTO)
        {
            ServiceResponse<IList<RubroDTO>> result = new ServiceResponse<IList<RubroDTO>>();
            try
            {
                
                var response = _administrarRubroService.ActualizarRubro(rubroDTO);

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
