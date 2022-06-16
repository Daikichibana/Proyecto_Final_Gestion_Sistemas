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
    public class AdministrarTarjetaClienteController : ControllerBase
    {
        IMapper _mapper;
        IAdministrarTarjetaClienteService _administrarTarjetaClienteService;
        public AdministrarTarjetaClienteController(IMapper mapper, IAdministrarTarjetaClienteService administrarTarjetaClienteService)
        {
            _mapper = mapper;
            _administrarTarjetaClienteService = administrarTarjetaClienteService;
        }

        [HttpGet]
        public IActionResult ObtenerTodasLasTarjetaClientes()
        {
            ServiceResponse<List<TarjetaClienteDTO>> result = new ServiceResponse<List<TarjetaClienteDTO>>();
            try
            {
                var response = _administrarTarjetaClienteService.ObtenerTodoTarjetaCliente();

                result.Data = _mapper.Map<List<TarjetaClienteDTO>>(response);
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
        public IActionResult InsertarTarjetaCliente(TarjetaClienteDTO _TarjetaClienteDTO)
        {
            ServiceResponse<TarjetaClienteDTO> result = new ServiceResponse<TarjetaClienteDTO>();
            try
            {
                TarjetaCliente nuevoTarjetaCliente = _mapper.Map<TarjetaCliente>(_TarjetaClienteDTO);
                var response = _administrarTarjetaClienteService.GuardarTarjetaCliente(nuevoTarjetaCliente);

                result.Data = _mapper.Map<TarjetaClienteDTO>(response);
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
        public IActionResult ActualizarTarjetaCliente(TarjetaClienteDTO TarjetaClienteDTO)
        {
            ServiceResponse<TarjetaClienteDTO> result = new ServiceResponse<TarjetaClienteDTO>();
            try
            {
                TarjetaCliente nuevoTarjetaCliente = _mapper.Map<TarjetaCliente>(TarjetaClienteDTO);
                var response = _administrarTarjetaClienteService.ActualizarTarjetaCliente(nuevoTarjetaCliente);

                result.Data = _mapper.Map<TarjetaClienteDTO>(response);
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
