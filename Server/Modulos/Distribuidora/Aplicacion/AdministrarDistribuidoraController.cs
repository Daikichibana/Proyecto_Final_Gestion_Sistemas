using System;
using System.Collections.Generic;
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

        IMapper _mapper;
        IAdministrarDistribuidoraService _AdministrarDistribuidoraService;

        public AdministrarDistribuidoraController(IMapper mapper, IAdministrarDistribuidoraService administrarDistribuidoraService)
        {
            _mapper = mapper;
            _AdministrarDistribuidoraService = administrarDistribuidoraService;
        }

        [HttpGet]
        public IActionResult ObtenerTodoDistribuidora()
        {

            var result = new ServiceResponse<List<EmpresaDistribuidoraDTO>>();

            try
            {
                IList<EmpresaDistribuidora> Empresas = _AdministrarDistribuidoraService.ObtenerTodoDistribuidora();
                List<EmpresaDistribuidoraDTO> response = new List<EmpresaDistribuidoraDTO>();

                foreach (var EmpresaDistribuidora in Empresas)
                {
                    response.Add(_mapper.Map<EmpresaDistribuidoraDTO>(EmpresaDistribuidora));
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


        [HttpPost]
        public IActionResult InsertarDistribuidora(RegistroEmpresaDTO Empresa)
        {

            var result = new ServiceResponse<EmpresaDistribuidoraDTO>();

            try
            {
                NIT nit = new NIT(Empresa.NombreFacturacion,Empresa.NumeroNIT);
                Usuario usuario = new Usuario(Empresa.NombreUsuario, Empresa.ClaveUsuario);
                ResponsableEmpresa responsable = new ResponsableEmpresa(Empresa.NombreResponsable,Empresa.ApellidoResponsable,Empresa.CiResponsable, Empresa.FechaNacimientoResponsable, Empresa.EmailEmpresa, Empresa.TelefonoResponsable, usuario);
                EmpresaDistribuidora nuevaEmpresa = new EmpresaDistribuidora(Empresa.NombreEmpresa, Empresa.RazonSocialEmpresa, Empresa.EmailEmpresa, Empresa.Rubro.Id, nit, responsable);

                var response = _AdministrarDistribuidoraService.GuardarDistribuidora(nuevaEmpresa);

                result.Data = _mapper.Map<EmpresaDistribuidoraDTO>(response);
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
                EmpresaDistribuidora nuevaEmpresa = _mapper.Map<EmpresaDistribuidora>(empresaDistribuidoraDTO);
                var response = _AdministrarDistribuidoraService.ActualizarDistribuidora(nuevaEmpresa);

                result.Data = _mapper.Map<EmpresaDistribuidoraDTO>(response);
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
