using System;
using System.Collections.Generic;
using System.Linq;
using Compartido;
using Compartido.Dto.Personal.General;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Abstracciones;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Aplicacion
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdministrarConductorController : ControllerBase
    {
        IAdministrarConductorService _administrarConductorService;
        public AdministrarConductorController(IAdministrarConductorService administrarConductorService)
        { 
            _administrarConductorService = administrarConductorService;
        }

        [HttpGet]
        public IActionResult ObtenerTodosLosConductores()
        {

            var result = new ServiceResponse<List<ConductorDTO>>();

            try
            {
                var response= _administrarConductorService.ObtenerTodoConductor().ToList();

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
        public IActionResult CrearConductor(List<ConductorDTO> conductorDTO)
        {

            var result = new ServiceResponse<List<ConductorDTO>>();

            try
            {
                var response = _administrarConductorService.GuardarConductor(conductorDTO).ToList();

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
        public IActionResult ActualizarConductor(List<ConductorDTO> conductorDTO)
        {
            var result = new ServiceResponse<List<ConductorDTO>>();

            try
            {
                var response = _administrarConductorService.ActualizarConductor(conductorDTO).ToList();

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
        public IActionResult EliminarConductor(Guid id)
        {
            var result = new ServiceResponse<ConductorDTO>();

            try
            {
                _administrarConductorService.EliminarConductor(id);

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
