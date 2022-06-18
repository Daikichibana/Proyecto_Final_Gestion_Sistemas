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
    public class AdministrarTarjetaClienteController : ControllerBase
    {
        IAdministrarTarjetaClienteService _administrarTarjetaClienteService;
        public AdministrarTarjetaClienteController(IAdministrarTarjetaClienteService administrarTarjetaClienteService)
        {
            _administrarTarjetaClienteService = administrarTarjetaClienteService;
        }

        [HttpGet]
        public IActionResult ObtenerTodasLasTarjetaClientes()
        {
            ServiceResponse<List<TarjetaClienteDTO>> result = new ServiceResponse<List<TarjetaClienteDTO>>();
            try
            {
                var response = _administrarTarjetaClienteService.ObtenerTodoTarjetaCliente().ToList();

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
        public IActionResult InsertarTarjetaCliente(IList<TarjetaClienteDTO> _TarjetaClienteDTO)
        {
            ServiceResponse<IList<TarjetaClienteDTO>> result = new ServiceResponse<IList<TarjetaClienteDTO>>();
            try
            {
                
                var response = _administrarTarjetaClienteService.GuardarTarjetaCliente(_TarjetaClienteDTO).ToList();

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
        public IActionResult ActualizarTarjetaCliente(IList<TarjetaClienteDTO> _TarjetaClienteDTO)
        {
            ServiceResponse<IList<TarjetaClienteDTO>> result = new ServiceResponse<IList<TarjetaClienteDTO>>();
            try
            {
                var response = _administrarTarjetaClienteService.ActualizarTarjetaCliente(_TarjetaClienteDTO);

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
        public IActionResult EliminarTarjetaCliente(Guid id)
        {
            ServiceResponse<TarjetaClienteDTO> result = new ServiceResponse<TarjetaClienteDTO>();
            try
            {
                _administrarTarjetaClienteService.EliminarTarjetaCliente(id);

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
