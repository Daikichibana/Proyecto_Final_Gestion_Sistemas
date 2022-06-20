using Compartido;
using Compartido.Dto.Inventario.General;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Abstracciones;
using System;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Aplicacion
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RealizarPedidoAProveedorController : ControllerBase
    {
        IRealizarPedidoAProveedorService _realizarPedidoAProveedorService;
        public RealizarPedidoAProveedorController(IRealizarPedidoAProveedorService realizarPedidoAProveedorService)
        {
            _realizarPedidoAProveedorService = realizarPedidoAProveedorService;
        }

        [HttpGet]
         public IActionResult registrarCompraAProveedor(NotaRecepcionDTO notaRecepcionDTO)
        {
            var result = new ServiceResponse<NotaRecepcionDTO>();

            try
            {
                _realizarPedidoAProveedorService.realizarPedidoProveedor(notaRecepcionDTO);

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
