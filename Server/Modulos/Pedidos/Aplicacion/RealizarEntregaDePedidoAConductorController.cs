using Compartido;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Tecnica;
using System;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Aplicacion
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealizarEntregaDePedidoAConductorController : ControllerBase
    {
        IRealizarEntregaDePedidoAConductorService _realizarEntregaDePedidoAConductorService;
        public RealizarEntregaDePedidoAConductorController(IRealizarEntregaDePedidoAConductorService realizarEntregaDePedidoAConductorService)
        {
            _realizarEntregaDePedidoAConductorService = realizarEntregaDePedidoAConductorService;
        }

        [HttpGet]
        public IActionResult ConfirmarEntregaPedido(Guid IdPedido)
        {
            var result = new ServiceResponse<Object>();

            try
            {
                _realizarEntregaDePedidoAConductorService.ConfirmarEntregaPedido(IdPedido);

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
