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
    public class AdministrarResponsableAlmacenController : ControllerBase
    {
        IMapper _mapper;
        IAdministrarResponsableAlmacenService _responsableAlmacenService;

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
                var response = _responsableAlmacenService.ObtenerTodoResponsableAlmacen().ToList();

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
        public IActionResult InsertarResponsableAlmacen(List<ResponsableAlmacenDTO> responsableAlmacenDTO)
        {

            var result = new ServiceResponse<List<ResponsableAlmacenDTO>>();

            try
            {
                var response = _responsableAlmacenService.GuardarResponsableAlmacen(responsableAlmacenDTO).ToList();

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

        [HttpPut]
        public IActionResult ActualizarResponsableAlmacen(List<ResponsableAlmacenDTO> responsableAlmacenDTO)
        {
            var result = new ServiceResponse<List<ResponsableAlmacenDTO>>();

            try
            {
                var response = _responsableAlmacenService.ActualizarResponsableAlmacen(responsableAlmacenDTO).ToList();

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
        public IActionResult EliminarResponsableAlmacen(Guid id)
        {
            var result = new ServiceResponse<ResponsableAlmacenDTO>();

            try
            {
                _responsableAlmacenService.EliminarResponsableAlmacen(id);

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
