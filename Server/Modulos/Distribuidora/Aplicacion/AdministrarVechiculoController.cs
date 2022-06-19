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
    public class AdministrarVechiculoController : ControllerBase
    {
       
        IAdministrarVehiculoService _administrarVehiculoService;
        public AdministrarVechiculoController(IAdministrarVehiculoService administrarVehiculoService)
        {
            _administrarVehiculoService = administrarVehiculoService;           
        }

        [HttpGet]
        public IActionResult ObtenerTodosLosVehiculos()
        {
            ServiceResponse<List<VehiculoDTO>> result = new ServiceResponse<List<VehiculoDTO>>();
           

            try
            {
                var response = _administrarVehiculoService.ObtenerTodoVehiculo().ToList();

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
        public IActionResult CrearVehiculo(IList<VehiculoDTO> vehiculoDTO)
        {

            ServiceResponse<IList<VehiculoDTO>> result = new ServiceResponse<IList<VehiculoDTO>>();

            try
            {

                var response = _administrarVehiculoService.GuardarVehiculo(vehiculoDTO).ToList();

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
        public IActionResult ActualizarVehiculo(IList<VehiculoDTO> vehiculoDTO)
        {
            ServiceResponse<IList<VehiculoDTO>> result = new ServiceResponse<IList<VehiculoDTO>>();

            try
            {
                var response = _administrarVehiculoService.ActualizarVehiculo(vehiculoDTO);

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
        public IActionResult EliminarVehiculo(Guid id)
        {

            ServiceResponse<IList<VehiculoDTO>> result = new ServiceResponse<IList<VehiculoDTO>>();

            try
            {
                _administrarVehiculoService.EliminarVehiculo(id);

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

        
        [HttpPost]
        public IActionResult AsignarVehiculoAConductor(AsignacionVechiculoConductorDTO vehiculoDTO)
        {

            ServiceResponse<IList<AsignacionVechiculoConductor>> result = new ServiceResponse<IList<AsignacionVechiculoConductor>>();

            try
            {
                
                _administrarVehiculoService.AsignarVehiculoAConductor(vehiculoDTO);   

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

        [HttpGet]
        public IActionResult ObtenerTodoVehiculoConductor()
        {

            ServiceResponse<List<AsignacionVechiculoConductorDTO>> result = new ServiceResponse<List<AsignacionVechiculoConductorDTO>>();

            try
            {
                var response = _administrarVehiculoService.ObtenerTodoAsignacionVechiculo().ToList();

                result.Data =response;
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
