using Compartido;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Abstracciones;
using System;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Aplicacion
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RealizarEntregaDePedidoAClienteController : ControllerBase
    {
        IRealizarEntregaDePedidoAClienteService _realizarEntregaService;
        public RealizarEntregaDePedidoAClienteController(IRealizarEntregaDePedidoAClienteService realizarEntregaService)
        {
            _realizarEntregaService = realizarEntregaService;
        }

        [HttpGet]
        public IActionResult ConfirmarEntregaCliente(Guid IdPedido)
        {
            var result = new ServiceResponse<object>();

            try
            {
                _realizarEntregaService.ConfirmarEntregaCliente(IdPedido);

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
