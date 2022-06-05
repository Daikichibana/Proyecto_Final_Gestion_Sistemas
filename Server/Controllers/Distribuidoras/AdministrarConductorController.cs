using AutoMapper;
using CAPAS.CAPA.DOMINIO;
using CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.ABSTRACCIONES;
using CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.DTO;
using CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.ENTIDADES;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CAPA.APLICACION.Controllers.Distribuidoras
{
    /// <summary>
    ///  
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AdministrarConductorController : ControllerBase
    {
        /// <summary>
        ///  
        /// </summary>
        IMapper _mapper;
        IAdministrarConductorService _administrarConductorService;
        public AdministrarConductorController(IMapper mapper, IAdministrarConductorService administrarConductorService)
        {
            _mapper = mapper;
            _administrarConductorService = administrarConductorService;
        }
        /// <summary>
        ///  
        /// </summary>
        [HttpGet]
        public IActionResult ObtenerTodosLosConductores()
        {

            var result = new ServiceResponse<List<ConductorDTO>>();

            try
            {
                IList<Conductor> Conductores = _administrarConductorService.ObtenerTodo();
                List<ConductorDTO> response = new List<ConductorDTO>();

                foreach (var Conductor in Conductores)
                {
                    response.Add(_mapper.Map<ConductorDTO>(Conductor));
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
        public IActionResult InsertarConductor(ConductorDTO conductorDTO)
        {

            var result = new ServiceResponse<ConductorDTO>();

            try
            {
                Conductor nuevoConductor = _mapper.Map<Conductor>(conductorDTO);

                var response = _administrarConductorService.Guardar(nuevoConductor);

                result.Data = _mapper.Map<ConductorDTO>(response);
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
        public IActionResult ActualizarConductor(ConductorDTO conductorDTO)
        {
            var result = new ServiceResponse<ConductorDTO>();

            try
            {
                Conductor nuevoConductor = _mapper.Map<Conductor>(conductorDTO);
                var response = _administrarConductorService.Actualizar(nuevoConductor);

                result.Data = _mapper.Map<ConductorDTO>(response);
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
        public IActionResult EliminarConductor(Guid id)
        {
            var result = new ServiceResponse<ConductorDTO>();

            try
            {
                _administrarConductorService.Eliminar(id);

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
