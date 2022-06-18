using Compartido;
using Compartido.Dto.Pedidos;
using Compartido.Dto.Pedidos.General;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Abstracciones;
using System;
using System.Collections.Generic;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Aplicacion
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdministrarPedidoController : ControllerBase
    {
        IAdministrarPedidoService _administracionPedidoService;
        public AdministrarPedidoController(IAdministrarPedidoService administracionPedidoService)
        {
            _administracionPedidoService = administracionPedidoService;
        }

        [HttpGet]
        public IActionResult ObtenerPorIdPedido(Guid Id)
        {

            var result = new ServiceResponse<PedidoDTO>();

            try
            {
                var response = _administracionPedidoService.ObtenerPorIdPedido(Id);

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
        public IActionResult EliminarPedido(Guid id)
        {
            var result = new ServiceResponse<PedidoDTO>();

            try
            {
                _administracionPedidoService.EliminarPedido(id);

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

        [HttpDelete]
        public IActionResult EliminarOrdenPedido(Guid id)
        {
            var result = new ServiceResponse<OrdenPedidoDTO>();

            try
            {
                _administracionPedidoService.EliminarOrdenPedido(id);

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
        public IActionResult ObtenerOrdenesPedidosDistribuidoraPorId(Guid Id)
        {

            var result = new ServiceResponse<List<OrdenPedidoDTO>>();

            try
            {
                var response = _administracionPedidoService.ObtenerOrdenesPedidosDistribuidoraPorId(Id);

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
        public IActionResult ObtenerOrdenesPedidosClientePorId(Guid Id)
        {

            var result = new ServiceResponse<List<OrdenPedidoDTO>>();

            try
            {
                var response = _administracionPedidoService.ObtenerOrdenesPedidosClientePorId(Id);

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
        public IActionResult ObtenerPedidosDistribuidoraPorId(Guid Id)
        {

            var result = new ServiceResponse<List<PedidoDTO>>();

            try
            {
                var response = _administracionPedidoService.ObtenerPedidosDistribuidoraPorId(Id);

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
        public IActionResult ObtenerPedidosClientePorId(Guid Id)
        {

            var result = new ServiceResponse<List<PedidoDTO>>();

            try
            {
                var response = _administracionPedidoService.ObtenerPedidosClientePorId(Id);

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
        public IActionResult ConfirmarOrdenPedido(ConfirmarPedidoDTO confirmarPedidoDTO)
        {

            var result = new ServiceResponse<PedidoDTO>();

            try
            {
                _administracionPedidoService.ConfirmarOrdenPedido(confirmarPedidoDTO);

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
