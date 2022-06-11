﻿using System;
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