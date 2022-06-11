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
    /// <summary>
    ///  
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AdministrarRubroController : ControllerBase
    {
        IMapper _mapper;
        IAdministrarRubroService _administrarRubroService;
        /// <summary>
        ///  
        /// </summary>
        public AdministrarRubroController(IMapper mapper, IAdministrarRubroService administrarRubroService)
        {
            _mapper = mapper;
            _administrarRubroService = administrarRubroService;
        }

        /// <summary>
        ///  
        /// </summary>
        [HttpGet]
        public IActionResult ObtenerTodosLosRubros()
        {
            ServiceResponse<List<RubroDTO>> result = new ServiceResponse<List<RubroDTO>>();
            try
            { 
                var response = _administrarRubroService.ObtenerTodo();

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

        /// <summary>
        ///  
        /// </summary>
        [HttpPost]
        public IActionResult InsertarRubro(RubroDTO _RubroDTO)
        {
            ServiceResponse<RubroDTO> result = new ServiceResponse<RubroDTO>();
            try
            {
                Rubro nuevoRubro = _mapper.Map<Rubro>(_RubroDTO);
                var response = _administrarRubroService.Guardar(nuevoRubro);

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

        /// <summary>
        ///  
        /// </summary>
        [HttpPut]
        public IActionResult ActualizarRubro(RubroDTO RubroDTO)
        {
            ServiceResponse<RubroDTO> result = new ServiceResponse<RubroDTO>();
            try
            {
                Rubro nuevoRubro = _mapper.Map<Rubro>(RubroDTO);
                var response = _administrarRubroService.Actualizar(nuevoRubro);

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

        /// <summary>
        ///  
        /// </summary>
        [HttpDelete]
        public IActionResult EliminarRubro(Guid id)
        {
            ServiceResponse<RubroDTO> result = new ServiceResponse<RubroDTO>();
            try
            {
                _administrarRubroService.Eliminar(id);

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
