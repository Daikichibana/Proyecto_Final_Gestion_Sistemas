using AutoMapper;
using Compartido;
using Compartido.Dto.Distribuidora;
using Compartido.Dto.Distribuidora.General;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Entidades;
using System;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Aplicacion
{
    [Route("api/[controller]")]
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

    }
}
