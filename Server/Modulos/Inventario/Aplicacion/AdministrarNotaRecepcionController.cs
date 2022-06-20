using Compartido;
using Compartido.Dto.Inventario.General;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Abstracciones;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Aplicacion
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdministrarNotaRecepcionController : ControllerBase
    {
        IAdministrarNotaRecepcionService _administrarNotaRecepcionService;
        public AdministrarNotaRecepcionController(IAdministrarNotaRecepcionService administrarNotaRecepcionService)
        {
            _administrarNotaRecepcionService = administrarNotaRecepcionService;
        }

        [HttpGet]
        public IActionResult obtenerTodasNotasRecepcion()
        {
            var result = new ServiceResponse<List<NotaRecepcionDTO>>();
            try
            {
                var response = _administrarNotaRecepcionService.ObtenerTodoNotaRecepcion().ToList();

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
        public IActionResult InsertarNotaRecepcion(NotaRecepcionDTO notaRecepcionDTO)
        {

            var result = new ServiceResponse<NotaRecepcionDTO>();

            try
            {
                var response = _administrarNotaRecepcionService.GuardarNotaRecepcion(notaRecepcionDTO);

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
    }
}
