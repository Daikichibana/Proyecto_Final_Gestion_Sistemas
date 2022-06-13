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
    /// <summary>
    ///  
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AdministrarProveedorController : ControllerBase
    {
        IMapper _mapper;
        IAdministrarProveedorService _administrarProveedorService;
        /// <summary>
        ///  
        /// </summary>
        public AdministrarProveedorController(IMapper mapper, IAdministrarProveedorService administrarProveedorService)
        {
            _mapper = mapper;
            _administrarProveedorService = administrarProveedorService;
        }
        /// <summary>
        ///  
        /// </summary>
        [HttpGet]
        public IActionResult ObtenerTodosLosProveedores()
        {
            ServiceResponse<List<EmpresaProveedorDTO>> result = new ServiceResponse<List<EmpresaProveedorDTO>>();
            try
            {
                var response = _administrarProveedorService.ObtenerTodo();

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
        /// <summary>
        ///  
        /// </summary>
        [HttpPost]
        public IActionResult InsertarProveedor(EmpresaProveedorDTO empresaProveedorDTO)
        {
            ServiceResponse<EmpresaProveedorDTO> result = new ServiceResponse<EmpresaProveedorDTO>();
            try
            {
                EmpresaProveedor nuevoProveedor = _mapper.Map<EmpresaProveedor>(empresaProveedorDTO);
                var response = _administrarProveedorService.Guardar(nuevoProveedor);

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
        /// <summary>
        ///  
        /// </summary>
        [HttpPut]
        public IActionResult ActualizarProveedor(EmpresaProveedorDTO empresaProveedorDTO)
        {
            ServiceResponse<EmpresaProveedorDTO> result = new ServiceResponse<EmpresaProveedorDTO>();
            try
            {
                EmpresaProveedor nuevoProveedor = _mapper.Map<EmpresaProveedor>(empresaProveedorDTO);
                var response = _administrarProveedorService.Actualizar(nuevoProveedor);

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
        /// <summary>
        ///  
        /// </summary>
        [HttpDelete]
        public IActionResult EliminarProveedor(Guid id)
        {
            ServiceResponse<EmpresaProveedorDTO> result = new ServiceResponse<EmpresaProveedorDTO>();
            try
            {
                _administrarProveedorService.Eliminar(id);

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
