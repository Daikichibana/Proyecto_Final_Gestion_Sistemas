using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Compartido;
using Compartido.Dto.Personal;
using Compartido.Dto.Personal.General;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Aplicacion
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdministrarResponsableEmpresaController : ControllerBase
    {
        IResponsableEmpresaService _responsableEmpresaService;

        public AdministrarResponsableEmpresaController(IResponsableEmpresaService responsableEmpresaService)
        {
            _responsableEmpresaService = responsableEmpresaService;
        }

        [HttpGet]
        public IActionResult ObtenerTodosLosResponsables()
        {
            var result = new ServiceResponse<List<ResponsableEmpresaDTO>>();
            try
            {
                var response = _responsableEmpresaService.ObtenerTodoResponsableEmpresa().ToList();

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
        public IActionResult InsertarResponsableEmpresa(ResponsableEmpresaDTO _responsableDTO)
        {
            var result = new ServiceResponse<ResponsableEmpresaDTO>();
            try
            {
                var response = _responsableEmpresaService.GuardarResponsableEmpresa(_responsableDTO);

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
        public IActionResult ActualizarResponsableEmpresa(ResponsableEmpresaDTO responsableDTO)
        {
            var result = new ServiceResponse<ResponsableEmpresaDTO>();
            try
            {
                var response = _responsableEmpresaService.ActualizarResponsableEmpresa(responsableDTO);

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
        public IActionResult EliminarResponsableEmpresa(Guid id)
        {
            var result = new ServiceResponse<ResponsableEmpresaDTO>();
            try
            {
                _responsableEmpresaService.EliminarResponsableEmpresa(id);

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
