using AutoMapper;
using Compartido;
using Compartido.Dto.Distribuidora;
using Compartido.Dto.Distribuidora.General;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Aplicacion
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdministrarClienteController : ControllerBase
    {
        IAdministrarClienteService _administrarClienteService;

        public AdministrarClienteController(IAdministrarClienteService administrarClienteService)
        {
            _administrarClienteService = administrarClienteService;
        }
        
        [HttpGet]
        public IActionResult ObtenerTodasLasEmpresaClientes()
        {
            var result = new ServiceResponse<List<EmpresaClienteDTO>>();
            try
            {
                var response = _administrarClienteService.ObtenerTodoCliente().ToList();

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
        public IActionResult InsertarEmpresaCliente(EmpresaClienteDTO _EmpresaClienteDTO)
        {
            var result = new ServiceResponse<EmpresaClienteDTO>();
            try
            {
                var response = _administrarClienteService.GuardarCliente(_EmpresaClienteDTO);

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
        public IActionResult ActualizarEmpresaCliente(EmpresaClienteDTO EmpresaClienteDTO)
        {
            var result = new ServiceResponse<EmpresaClienteDTO>();
            try
            {
                var response = _administrarClienteService.ActualizarCliente(EmpresaClienteDTO);

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
        public IActionResult EliminarEmpresaCliente(Guid id)
        {
            ServiceResponse<EmpresaClienteDTO> result = new ServiceResponse<EmpresaClienteDTO>();
            try
            {
                _administrarClienteService.EliminarCliente(id);

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


        [HttpGet]
        public IActionResult ObtenerDistribuidorasDeCliente(Guid id)
        {

            var result = new ServiceResponse<List<ClientesDistribuidoraDTO>>();

            try
            {
                var response = _administrarClienteService.ObtenerDistribuidorasDeCliente(id).ToList();

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
        public IActionResult InsertarDistribuidorasDeCliente(ClientesDistribuidoraDTO clienteDistribuidora)
        {

            var result = new ServiceResponse<ClientesDistribuidoraDTO>();

            try
            {
                var response = _administrarClienteService.InsertarDistribuidorasDeCliente(clienteDistribuidora);

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
        public IActionResult EliminarDistribuidorasDeCliente(Guid Id)
        {

            var result = new ServiceResponse<List<ClientesDistribuidoraDTO>>();

            try
            {
                _administrarClienteService.EliminarDistribuidorasDeCliente(Id);

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
