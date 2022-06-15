using AutoMapper;
using Compartido;
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
    public class AdministrarPedidoController : ControllerBase
    {
        IAdministrarPedidoService _administracionPedidoService;
        IMapper _mapper;
        public AdministrarPedidoController(IAdministrarPedidoService administracionPedidoService, IMapper mapper)
        {
            _administracionPedidoService = administracionPedidoService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ObtenerTodosPedido()
        {

            var result = new ServiceResponse<List<PedidoDTO>>();

            try
            {
                IList<Pedido> entidad = _administracionPedidoService.ObtenerTodoPedido();
                List<PedidoDTO> response = new List<PedidoDTO>();

                foreach (var item in entidad)
                {
                    response.Add(_mapper.Map<PedidoDTO>(item));
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
        public IActionResult InsertarPedido(PedidoDTO entidad)
        {

            var result = new ServiceResponse<PedidoDTO>();

            try
            {
                Pedido item = _mapper.Map<Pedido>(entidad);

                var response = _administracionPedidoService.GuardarPedido(item);

                result.Data = _mapper.Map<PedidoDTO>(response);
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
        public IActionResult ActualizarPedido(PedidoDTO entidad)
        {
            var result = new ServiceResponse<PedidoDTO>();

            try
            {
                Pedido item = _mapper.Map<Pedido>(entidad);
                var response = _administracionPedidoService.ActualizarPedido(item);

                result.Data = _mapper.Map<PedidoDTO>(response);
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

        [HttpGet]
        public IActionResult ObtenerTodosOrdenPedido()
        {

            var result = new ServiceResponse<List<OrdenPedidoDTO>>();

            try
            {
                IList<OrdenPedido> items = _administracionPedidoService.ObtenerTodoOrdenPedido();
                List<OrdenPedidoDTO> response = new List<OrdenPedidoDTO>();

                foreach (var item in items)
                {
                    response.Add(_mapper.Map<OrdenPedidoDTO>(item));
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
        public IActionResult InsertarOrdenPedido(OrdenPedidoDTO entidad)
        {

            var result = new ServiceResponse<OrdenPedidoDTO>();

            try
            {
                OrdenPedido item = _mapper.Map<OrdenPedido>(entidad);

                var response = _administracionPedidoService.GuardarOrdenPedido(item);

                result.Data = _mapper.Map<OrdenPedidoDTO>(response);
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
        public IActionResult ActualizarOrdenPedido(OrdenPedidoDTO entidad)
        {
            var result = new ServiceResponse<OrdenPedidoDTO>();

            try
            {
                OrdenPedido item = _mapper.Map<OrdenPedido>(entidad);
                var response = _administracionPedidoService.ActualizarOrdenPedido(item);

                result.Data = _mapper.Map<OrdenPedidoDTO>(response);
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
        public IActionResult ObtenerDetalleOrdenPedido()
        {

            var result = new ServiceResponse<List<DetalleOrdenPedidoDTO>>();

            try
            {
                IList<DetalleOrdenPedido> items = _administracionPedidoService.ObtenerTodoDetalleOrdenPedido();
                List<DetalleOrdenPedidoDTO> response = new List<DetalleOrdenPedidoDTO>();

                foreach (var item in items)
                {
                    response.Add(_mapper.Map<DetalleOrdenPedidoDTO>(item));
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
        public IActionResult InsertarDetalleOrdenPedido(DetalleOrdenPedidoDTO entidad)
        {

            var result = new ServiceResponse<DetalleOrdenPedidoDTO>();

            try
            {
                DetalleOrdenPedido item = _mapper.Map<DetalleOrdenPedido>(entidad);

                var response = _administracionPedidoService.GuardarDetalleOrdenPedido(item);

                result.Data = _mapper.Map<DetalleOrdenPedidoDTO>(response);
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
        public IActionResult ActualizarDetalleOrdenPedido(DetalleOrdenPedidoDTO entidad)
        {
            var result = new ServiceResponse<DetalleOrdenPedidoDTO>();

            try
            {
                DetalleOrdenPedido item = _mapper.Map<DetalleOrdenPedido>(entidad);
                var response = _administracionPedidoService.ActualizarDetalleOrdenPedido(item);

                result.Data = _mapper.Map<DetalleOrdenPedidoDTO>(response);
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
        public IActionResult EliminarDetalleOrdenPedido(Guid id)
        {
            var result = new ServiceResponse<DetalleOrdenPedidoDTO>();

            try
            {
                _administracionPedidoService.EliminarDetalleOrdenPedido(id);

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

                result.Data = _mapper.Map<List<OrdenPedidoDTO>>(response);
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

            var result = new ServiceResponse<OrdenPedidoDTO>();

            try
            {
                var response = _administracionPedidoService.ObtenerOrdenesPedidosClientePorId(Id);

                result.Data = _mapper.Map<OrdenPedidoDTO>(response);
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

            var result = new ServiceResponse<PedidoDTO>();

            try
            {
                var response = _administracionPedidoService.ObtenerPedidosDistribuidoraPorId(Id);

                result.Data = _mapper.Map<PedidoDTO>(response);
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

            var result = new ServiceResponse<PedidoDTO>();

            try
            {
                var response = _administracionPedidoService.ObtenerPedidosClientePorId(Id);

                result.Data = _mapper.Map<PedidoDTO>(response);
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
        public IActionResult ConfirmarOrdenPedido(Guid Id, bool aceptado)
        {

            var result = new ServiceResponse<PedidoDTO>();

            try
            {
                _administracionPedidoService.ConfirmarOrdenPedido(Id, aceptado);

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
