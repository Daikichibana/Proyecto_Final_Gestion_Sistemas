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
                IList<Vechiculo> Vehiculos = _administrarVehiculoService.ObtenerTodo();
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
        public IActionResult CrearVehiculo(VehiculoDTO vehiculoDTO)
        {

            var result = new ServiceResponse<VehiculoDTO>();

            try
            {
                Vechiculo nuevoVehiculo = _mapper.Map<Vechiculo>(vehiculoDTO);

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
                Vechiculo nuevoVehiculo = _mapper.Map<Vechiculo>(vehiculoDTO);
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
