using AutoMapper;
using Compartido;
using Compartido.Dto.Distribuidora.General;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Aplicacion
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdministrarProveedorController : ControllerBase
    {
        IAdministrarProveedorService _administrarProveedorService;

        public AdministrarProveedorController( IAdministrarProveedorService administrarProveedorService)
        {
            _administrarProveedorService = administrarProveedorService;
        }

        [HttpGet]
        public IActionResult ObtenerTodosLosProveedores()
        {
            var result = new ServiceResponse<List<EmpresaProveedorDTO>>();
            try
            {
                var response = _administrarProveedorService.ObtenerTodoProveedor().ToList();

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
        public IActionResult InsertarProveedor(List<EmpresaProveedorDTO> empresaProveedorDTO)
        {
            var result = new ServiceResponse<List<EmpresaProveedorDTO>>();
            try
            {
                var response = _administrarProveedorService.GuardarProveedor(empresaProveedorDTO);
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
        public IActionResult ActualizarProveedor(List<EmpresaProveedorDTO> empresaProveedorDTO)
        {
            var result = new ServiceResponse<List<EmpresaProveedorDTO>>();
            try
            {
                var response = _administrarProveedorService.ActualizarProveedor(empresaProveedorDTO).ToList();

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
        public IActionResult EliminarProveedor(Guid id)
        {
            var result = new ServiceResponse<EmpresaProveedorDTO>();
            try
            {
                _administrarProveedorService.EliminarProveedor(id);

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
