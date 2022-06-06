﻿using AutoMapper;
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
    public class AdministrarResponsableAlmacenController : ControllerBase
    {
        IMapper _mapper;
        IAdministrarResponsableAlmacenService _responsableAlmacenService;
        /// <summary>
        ///  
        /// </summary>
        public AdministrarResponsableAlmacenController(IMapper mapper, IAdministrarResponsableAlmacenService responsableAlmacenService)
        {
            _mapper = mapper;
            _responsableAlmacenService = responsableAlmacenService;
        }
        [HttpGet]
        public IActionResult ObtenerTodLosResponsablesDeAlmacen()
        {

            var result = new ServiceResponse<List<ResponsableAlmacenDTO>>();

            try
            {
                IList<ResponsableAlmacen> Responsables = _responsableAlmacenService.ObtenerTodo();
                List<ResponsableAlmacenDTO> response = new List<ResponsableAlmacenDTO>();

                foreach (var ResponsableAlmacen in Responsables)
                {
                    response.Add(_mapper.Map<ResponsableAlmacenDTO>(ResponsableAlmacen));
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
        public IActionResult InsertarResponsableAlmacen(ResponsableAlmacenDTO responsableAlmacenDTO)
        {

            var result = new ServiceResponse<ResponsableAlmacenDTO>();

            try
            {
                ResponsableAlmacen nuevoResponsableAlmacen = _mapper.Map<ResponsableAlmacen>(responsableAlmacenDTO);

                var response = _responsableAlmacenService.Guardar(nuevoResponsableAlmacen);

                result.Data = _mapper.Map<ResponsableAlmacenDTO>(response);
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
        public IActionResult ActualizarSucursal(ResponsableAlmacenDTO responsableAlmacenDTO)
        {
            var result = new ServiceResponse<ResponsableAlmacenDTO>();

            try
            {
                ResponsableAlmacen nuevoResponsableAlmacen = _mapper.Map<ResponsableAlmacen>(responsableAlmacenDTO);
                var response = _responsableAlmacenService.Actualizar(nuevoResponsableAlmacen);

                result.Data = _mapper.Map<ResponsableAlmacenDTO>(response);
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
        public IActionResult EliminarResponsableAlmacen(Guid id)
        {
            var result = new ServiceResponse<ResponsableAlmacenDTO>();

            try
            {
                _responsableAlmacenService.Eliminar(id);

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
