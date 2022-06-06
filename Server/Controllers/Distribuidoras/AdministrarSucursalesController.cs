using AutoMapper;
using CAPAS.CAPA.DOMINIO;
using CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.ABSTRACCIONES;
using CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.DTO;
using CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.ENTIDADES;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CAPA.APLICACION.Controllers.Distribuidoras
{
    /// <summary>
    ///  
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AdministrarSucursalesController : ControllerBase
    {
        IMapper _mapper;
        IAdministrarSucursalesService _AdministrarSucursalesService;
        /// <summary>
        ///  
        /// </summary>
        public AdministrarSucursalesController(IMapper mapper, IAdministrarSucursalesService administrarSucursalesService)
        {
            _mapper = mapper;
            _AdministrarSucursalesService = administrarSucursalesService;
        }
        [HttpGet]
        public IActionResult ObtenerTodasLasSucursales()
        {

            var result = new ServiceResponse<List<SucursalesDTO>>();

            try
            {
                IList<Sucursales> Sucursal = _AdministrarSucursalesService.ObtenerTodo();
                List<SucursalesDTO> response = new List<SucursalesDTO>();

                foreach (var Sucursales in Sucursal)
                {
                    response.Add(_mapper.Map<SucursalesDTO>(Sucursales));
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
        /// <summary>
        ///  
        /// </summary>
        [HttpPost]
        public IActionResult InsertarSucursal(SucursalesDTO sucursalesDTO)
        {

            var result = new ServiceResponse<SucursalesDTO>();

            try
            {
                Sucursales nuevaSucursal = _mapper.Map<Sucursales>(sucursalesDTO);

                var response = _AdministrarSucursalesService.Guardar(nuevaSucursal);

                result.Data = _mapper.Map<SucursalesDTO>(response);
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
        /// <summary>
        ///  
        /// </summary>
        [HttpPut]
        public IActionResult ActualizarSucursal(SucursalesDTO sucursalesDTO)
        {
            var result = new ServiceResponse<SucursalesDTO>();

            try
            {
                Sucursales nuevaSucursal = _mapper.Map<Sucursales>(sucursalesDTO);
                var response = _AdministrarSucursalesService.Actualizar(nuevaSucursal);

                result.Data = _mapper.Map<SucursalesDTO>(response);
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
        public IActionResult EliminarSucursal(Guid id)
        {
            var result = new ServiceResponse<SucursalesDTO>();

            try
            {
                _AdministrarSucursalesService.Eliminar(id);

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
