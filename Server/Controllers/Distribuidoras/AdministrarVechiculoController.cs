using AutoMapper;
using CAPAS.CAPA.DOMINIO;
using CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.ABSTRACCIONES;
using CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.ENTIDADES;
using CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.DTO;
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
    public class AdministrarVechiculoController : ControllerBase
    {
        /// <summary>
        ///  
        /// </summary>
        IMapper _mapper;
        IAdministrarVehiculoService _administrarVehiculoService;
        public AdministrarVechiculoController(IMapper mapper, IAdministrarVehiculoService administrarVehiculoService)
        {
            _mapper = mapper;
            _administrarVehiculoService = administrarVehiculoService;           
        }
        /// <summary>
        ///  
        /// </summary>
        [HttpGet]
        public IActionResult ObtenerTodosLosVehiculos()
        {

            var result = new ServiceResponse<List<VehiculoDTO>>();

            try
            {
                IList<Vehiculo> Vehiculos = _administrarVehiculoService.ObtenerTodo();
                List<VehiculoDTO> response = new List<VehiculoDTO>();

                foreach (var Vehiculo in Vehiculos)
                {
                    response.Add(_mapper.Map<VehiculoDTO>(Vehiculo));
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
        public IActionResult InsertarVehiculo(VehiculoDTO vehiculoDTO)
        {

            var result = new ServiceResponse<VehiculoDTO>();

            try
            {
                Vehiculo nuevoVehiculo = _mapper.Map<Vehiculo>(vehiculoDTO);

                var response = _administrarVehiculoService.Guardar(nuevoVehiculo);

                result.Data = _mapper.Map<VehiculoDTO>(response);
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
        public IActionResult ActualizarVehiculo(VehiculoDTO vehiculoDTO)
        {
            var result = new ServiceResponse<VehiculoDTO>();

            try
            {
                Vehiculo nuevoVehiculo = _mapper.Map<Vehiculo>(vehiculoDTO);
                var response = _administrarVehiculoService.Actualizar(nuevoVehiculo);

                result.Data = _mapper.Map<VehiculoDTO>(response);
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
        public IActionResult EliminarVehiculo(Guid id)
        {
            var result = new ServiceResponse<VehiculoDTO>();

            try
            {
                _administrarVehiculoService.Eliminar(id);

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
