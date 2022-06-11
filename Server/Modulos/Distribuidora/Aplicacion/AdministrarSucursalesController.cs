using System;
using System.Collections.Generic;
using AutoMapper;
using Compartido;
using Compartido.Dto.Distribuidora;
using Compartido.Dto.Distribuidora.General;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Aplicacion
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
