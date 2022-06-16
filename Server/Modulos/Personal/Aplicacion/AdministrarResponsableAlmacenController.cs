using System;
using System.Collections.Generic;
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
                IList<ResponsableAlmacen> Responsables = _responsableAlmacenService.ObtenerTodoResponsableAlmacen();
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

        [HttpPost]
        public IActionResult InsertarResponsableAlmacen(ResponsableAlmacenDTO responsableAlmacenDTO)
        {

            var result = new ServiceResponse<ResponsableAlmacenDTO>();

            try
            {
                ResponsableAlmacen nuevoResponsableAlmacen = _mapper.Map<ResponsableAlmacen>(responsableAlmacenDTO);

                var response = _responsableAlmacenService.GuardarResponsableAlmacen(nuevoResponsableAlmacen);

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

        [HttpPut]
        public IActionResult ActualizarSucursal(ResponsableAlmacenDTO responsableAlmacenDTO)
        {
            var result = new ServiceResponse<ResponsableAlmacenDTO>();

            try
            {
                ResponsableAlmacen nuevoResponsableAlmacen = _mapper.Map<ResponsableAlmacen>(responsableAlmacenDTO);
                var response = _responsableAlmacenService.ActualizarResponsableAlmacen(nuevoResponsableAlmacen);

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
