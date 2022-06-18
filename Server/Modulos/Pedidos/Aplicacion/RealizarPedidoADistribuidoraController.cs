using AutoMapper;
using Compartido;
using Compartido.Dto.Pedidos;
using Compartido.Dto.Pedidos.General;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Aplicacion
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RealizarPedidoADistribuidoraController : ControllerBase
    {
        IRealizarPedidoADistribuidoraService _realizarPedidoADistribuidoraService;

        public RealizarPedidoADistribuidoraController(IRealizarPedidoADistribuidoraService realizarPedidoADistribuidoraService)
        {
            _realizarPedidoADistribuidoraService = realizarPedidoADistribuidoraService;
        }

        [HttpPost]
        public IActionResult RealizarOrdenPedido(RegistroPedidoDTO registro)
        { 
            var result = new ServiceResponse<object>();

            try
            {

                _realizarPedidoADistribuidoraService.RealizarOrdenPedido(registro);

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
