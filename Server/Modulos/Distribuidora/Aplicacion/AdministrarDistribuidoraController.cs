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
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Aplicacion
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdministrarDistribuidoraController : ControllerBase
    {
        IAdministrarDistribuidoraService _AdministrarDistribuidoraService;

        public AdministrarDistribuidoraController( IAdministrarDistribuidoraService administrarDistribuidoraService)
        {
            _AdministrarDistribuidoraService = administrarDistribuidoraService;
        }

        [HttpGet]
        public IActionResult ObtenerTodoDistribuidora()
        {

            var result = new ServiceResponse<List<EmpresaDistribuidoraDTO>>();

            try
            {
                var response = _AdministrarDistribuidoraService.ObtenerTodoDistribuidora().ToList();

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
        public IActionResult InsertarDistribuidora(EmpresaDistribuidoraDTO Empresa)
        {

            var result = new ServiceResponse<EmpresaDistribuidoraDTO>();

            try
            {
                /*NIT nit = new NIT(Empresa.NombreFacturacion,Empresa.NumeroNIT);
                Usuario usuario = new Usuario(Empresa.NombreUsuario, Empresa.ClaveUsuario);
                ResponsableEmpresa responsable = new ResponsableEmpresa(Empresa.NombreResponsable,Empresa.ApellidoResponsable,Empresa.CiResponsable, Empresa.FechaNacimientoResponsable, Empresa.EmailEmpresa, Empresa.TelefonoResponsable, usuario);
                EmpresaDistribuidora nuevaEmpresa = new EmpresaDistribuidora(Empresa.NombreEmpresa, Empresa.RazonSocialEmpresa, Empresa.EmailEmpresa, Empresa.Rubro.Id, nit, responsable);
                */
                var response = _AdministrarDistribuidoraService.GuardarDistribuidora(Empresa);

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
        public IActionResult ActualizarDistribuidora(EmpresaDistribuidoraDTO empresaDistribuidoraDTO)
        {
            var result = new ServiceResponse<EmpresaDistribuidoraDTO>();

            try
            {
                var response = _AdministrarDistribuidoraService.ActualizarDistribuidora(empresaDistribuidoraDTO);

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
        public IActionResult EliminarDistribuidora(Guid id)
        {
            var result = new ServiceResponse<EmpresaDistribuidoraDTO>();

            try
            {
                _AdministrarDistribuidoraService.EliminarDistribuidora(id);

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
