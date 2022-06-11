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
