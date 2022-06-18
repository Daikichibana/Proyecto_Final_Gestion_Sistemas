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

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Aplicacion
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdministrarSucursalesController : ControllerBase
    {
        
        IAdministrarSucursalesService _AdministrarSucursalesService;
        public AdministrarSucursalesController(IAdministrarSucursalesService administrarSucursalesService)
        {
            _AdministrarSucursalesService = administrarSucursalesService;
        }
        [HttpGet]
        public IActionResult ObtenerTodasLasSucursales()
        {

            ServiceResponse<List<SucursalesDTO>> result = new ServiceResponse<List<SucursalesDTO>>();

            try
            {
                var response = _AdministrarSucursalesService.ObtenerTodoSucursales().ToList();


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
        public IActionResult InsertarSucursal(IList<SucursalesDTO> sucursalesDTO)
        {

            ServiceResponse<IList<SucursalesDTO>> result = new ServiceResponse<IList<SucursalesDTO>>();

            try
            {
                var response = _AdministrarSucursalesService.GuardarSucursales(sucursalesDTO).ToList();


                result.Data =response;
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
        public IActionResult ActualizarSucursal(IList<SucursalesDTO> sucursalesDTO)
        {
            ServiceResponse<IList<SucursalesDTO>> result = new ServiceResponse<IList<SucursalesDTO>>();

            try
            {
                var response = _AdministrarSucursalesService.ActualizarSucursales(sucursalesDTO);


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
        public IActionResult EliminarSucursal(Guid id)
        {
            ServiceResponse<IList<SucursalesDTO>> result = new ServiceResponse<IList<SucursalesDTO>>();

            try
            {
                _AdministrarSucursalesService.EliminarSucursales(id);

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
