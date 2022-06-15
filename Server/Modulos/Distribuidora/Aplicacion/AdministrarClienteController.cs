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

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Aplicacion
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdministrarClienteController : ControllerBase
    {
        IMapper _mapper;
        IAdministrarEmpresaClienteService _administrarClienteService;

        public AdministrarClienteController(IMapper mapper, IAdministrarEmpresaClienteService administrarClienteService)
        {
            _mapper = mapper;
            _administrarClienteService = administrarClienteService;
        }
        
        [HttpGet]
        public IActionResult ObtenerTodasLasEmpresaClientes()
        {
            ServiceResponse<List<EmpresaClienteDTO>> result = new ServiceResponse<List<EmpresaClienteDTO>>();
            try
            {
                var response = _administrarClienteService.ObtenerTodo();

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
                var response = _administrarClienteService.Guardar(nuevoEmpresaCliente);

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
                var response = _administrarClienteService.Actualizar(nuevoEmpresaCliente);

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
                _administrarClienteService.Eliminar(id);

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
        
        [HttpPost]
        public IActionResult InsertarEmpresa(RegistroEmpresaDTO Empresa)
        {

            var result = new ServiceResponse<EmpresaClienteDTO>();

            try
            {
                NIT nit = new NIT(Empresa.NombreFacturacion, Empresa.NumeroNIT);
                Usuario usuario = new Usuario(Empresa.NombreUsuario, Empresa.ClaveUsuario);
                ResponsableEmpresa responsable = new ResponsableEmpresa(Empresa.NombreResponsable, Empresa.ApellidoResponsable, Empresa.CiResponsable, Empresa.FechaNacimientoResponsable, Empresa.EmailEmpresa, Empresa.TelefonoResponsable, usuario);
                EmpresaCliente nuevaEmpresa = new EmpresaCliente(Empresa.NombreEmpresa, Empresa.RazonSocialEmpresa, Empresa.EmailEmpresa, Empresa.Rubro.Id, nit, responsable);

                var response = _administrarClienteService.Guardar(nuevaEmpresa);

                result.Data = _mapper.Map<EmpresaClienteDTO>(response);
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
        public IActionResult ObtenerDistribuidorasDeCliente()
        {

            var result = new ServiceResponse<List<ClientesDistribuidoraDTO>>();

            try
            {
                var response = _administrarClienteService.ObtenerDistribuidorasDeCliente();

                result.Data = _mapper.Map<List<ClientesDistribuidoraDTO>>(response);
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
                var ClienteDist = _mapper.Map<ClientesDistribuidora>(clienteDistribuidora);
                var response = _administrarClienteService.InsertarDistribuidorasDeCliente(ClienteDist);

                result.Data = _mapper.Map<ClientesDistribuidoraDTO>(response);
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
