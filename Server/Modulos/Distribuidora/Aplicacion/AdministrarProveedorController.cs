using AutoMapper;
using Compartido;
using Compartido.Dto.Distribuidora.General;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Aplicacion
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdministrarProveedorController : ControllerBase
    {
        IMapper _mapper;
        IAdministrarProveedorService _administrarProveedorService;

        public AdministrarProveedorController(IMapper mapper, IAdministrarProveedorService administrarProveedorService)
        {
            _mapper = mapper;
            _administrarProveedorService = administrarProveedorService;
        }

        [HttpGet]
        public IActionResult ObtenerTodosLosProveedores()
        {
            ServiceResponse<List<EmpresaProveedorDTO>> result = new ServiceResponse<List<EmpresaProveedorDTO>>();
            try
            {
                var response = _administrarProveedorService.ObtenerTodoProveedor();

                result.Data = _mapper.Map<List<EmpresaProveedorDTO>>(response);
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
        public IActionResult InsertarProveedor(EmpresaProveedorDTO empresaProveedorDTO)
        {
            ServiceResponse<EmpresaProveedorDTO> result = new ServiceResponse<EmpresaProveedorDTO>();
            try
            {
                EmpresaProveedor nuevoProveedor = _mapper.Map<EmpresaProveedor>(empresaProveedorDTO);
                var response = _administrarProveedorService.GuardarProveedor(nuevoProveedor);

                result.Data = _mapper.Map<EmpresaProveedorDTO>(response);
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
        public IActionResult ActualizarProveedor(EmpresaProveedorDTO empresaProveedorDTO)
        {
            ServiceResponse<EmpresaProveedorDTO> result = new ServiceResponse<EmpresaProveedorDTO>();
            try
            {
                EmpresaProveedor nuevoProveedor = _mapper.Map<EmpresaProveedor>(empresaProveedorDTO);
                var response = _administrarProveedorService.ActualizarProveedor(nuevoProveedor);

                result.Data = _mapper.Map<EmpresaProveedorDTO>(response);
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
            ServiceResponse<EmpresaProveedorDTO> result = new ServiceResponse<EmpresaProveedorDTO>();
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
