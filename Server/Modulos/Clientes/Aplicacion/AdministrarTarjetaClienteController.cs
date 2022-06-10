using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Clientes.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Clientes.Dominio.Entidades;
using Compartido;
using Compartido.Modulos.Clientes.Dto;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Clientes.Aplicacion
{
    /// <summary>
    ///  
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AdministrarTarjetaClienteController : ControllerBase
    {
        IMapper _mapper;
        IAdministrarTarjetaClienteService _administrarTarjetaClienteService;
        /// <summary>
        ///  
        /// </summary>
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
                var response = _administrarTarjetaClienteService.ObtenerTodo();

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
                var response = _administrarTarjetaClienteService.Guardar(nuevoTarjetaCliente);

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
                var response = _administrarTarjetaClienteService.Actualizar(nuevoTarjetaCliente);

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
                _administrarTarjetaClienteService.Eliminar(id);

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
