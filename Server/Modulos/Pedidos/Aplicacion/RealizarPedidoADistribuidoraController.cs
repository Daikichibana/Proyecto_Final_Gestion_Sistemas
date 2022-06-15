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
    [Route("api/[controller]")]
    [ApiController]
    public class RealizarPedidoADistribuidoraController : ControllerBase
    {
        IRealizarPedidoADistribuidoraService _realizarPedidoADistribuidoraService;
        IMapper _mapper;

        public RealizarPedidoADistribuidoraController(IMapper mapper, IRealizarPedidoADistribuidoraService realizarPedidoADistribuidoraService)
        {
            _realizarPedidoADistribuidoraService = realizarPedidoADistribuidoraService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult RealizarOrdenPedido(RegistroPedidoDTO registro)
        { 
            var result = new ServiceResponse<object>();

            try
            {
                OrdenPedido orden = _mapper.Map<OrdenPedido>(registro.Orden);
                List<DetalleOrdenPedido> detalle = _mapper.Map<List<DetalleOrdenPedido>>(registro.ProductoCarrito);

                _realizarPedidoADistribuidoraService.RealizarOrdenPedido(orden, detalle);

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
