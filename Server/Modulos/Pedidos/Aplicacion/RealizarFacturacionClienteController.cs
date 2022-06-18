using Compartido;
using Compartido.Dto.Pedidos.General;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Abstracciones;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Aplicacion
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RealizarFacturacionClienteController : ControllerBase
    {
        IRealizarFacturacionClienteService _facturacionService;
        public RealizarFacturacionClienteController(IRealizarFacturacionClienteService facturacionService)
        {
            _facturacionService = facturacionService;
        }

        [HttpDelete]
        public IActionResult EliminarFactura(Guid id) 
        {
            var result = new ServiceResponse<Object>();

            try
            {
                _facturacionService.EliminarFactura(id);

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

        [HttpGet]
        public IActionResult ObtenerTodoFactura() 
        {
            var result = new ServiceResponse<List<FacturaDTO>>();

            try
            {
                var response = _facturacionService.ObtenerTodoFactura().ToList();

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

        [HttpGet]
        public IActionResult ObtenerPorIdFactura(Guid id) 
        {
            var result = new ServiceResponse<FacturaDTO>();

            try
            {
                var response = _facturacionService.ObtenerPorIdFactura(id);

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
        public IActionResult ConfirmarPago(Guid IdPedido) 
        {
            var result = new ServiceResponse<Object>();

            try
            {
                _facturacionService.ConfirmarPago(IdPedido);

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
