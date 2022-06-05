using AutoMapper;
using CAPAS.CAPA.DOMINIO;
using CAPAS.CAPA.DOMINIO.CLIENTES.ABSTRACCIONES;
using CAPAS.CAPA.DOMINIO.CLIENTES.DTO;
using CAPAS.CAPA.DOMINIO.CLIENTES.ENTIDADES;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Proyecto_Final_Gestion_Sistemas.Server.Controllers.Clientes
{
    /// <summary>
    ///  
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AdministrarEmpresaClienteController : ControllerBase
    {
        IMapper _mapper;
        IAdministrarEmpresaClienteService _administrarEmpresaClienteService;
        /// <summary>
        ///  
        /// </summary>
        public AdministrarEmpresaClienteController(IMapper mapper, IAdministrarEmpresaClienteService administrarEmpresaClienteService)
        {
            _mapper = mapper;
            _administrarEmpresaClienteService = administrarEmpresaClienteService;
        }

        [HttpGet]
        public IActionResult ObtenerTodasLasEmpresaClientes()
        {
            ServiceResponse<List<EmpresaClienteDTO>> result = new ServiceResponse<List<EmpresaClienteDTO>>();
            try
            {
                var response = _administrarEmpresaClienteService.ObtenerTodo();

                result.Data = _mapper.Map<List<EmpresaClienteDTO>>(response);
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
        public IActionResult InsertarEmpresaCliente(EmpresaClienteDTO _EmpresaClienteDTO)
        {
            ServiceResponse<EmpresaClienteDTO> result = new ServiceResponse<EmpresaClienteDTO>();
            try
            {
                EmpresaCliente nuevoEmpresaCliente = _mapper.Map<EmpresaCliente>(_EmpresaClienteDTO);
                var response = _administrarEmpresaClienteService.Guardar(nuevoEmpresaCliente);

                result.Data = _mapper.Map<EmpresaClienteDTO>(response);
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
        public IActionResult ActualizarEmpresaCliente(EmpresaClienteDTO EmpresaClienteDTO)
        {
            ServiceResponse<EmpresaClienteDTO> result = new ServiceResponse<EmpresaClienteDTO>();
            try
            {
                EmpresaCliente nuevoEmpresaCliente = _mapper.Map<EmpresaCliente>(EmpresaClienteDTO);
                var response = _administrarEmpresaClienteService.Actualizar(nuevoEmpresaCliente);

                result.Data = _mapper.Map<EmpresaClienteDTO>(response);
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
        public IActionResult EliminarEmpresaCliente(Guid id)
        {
            ServiceResponse<EmpresaClienteDTO> result = new ServiceResponse<EmpresaClienteDTO>();
            try
            {
                _administrarEmpresaClienteService.Eliminar(id);

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
