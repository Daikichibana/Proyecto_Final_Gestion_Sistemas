using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Entidades;
using Compartido;
using Compartido.Dto.Inventario;
using Compartido.Dto.Inventario.General;
using System.Linq;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Aplicacion
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdministrarProductoController : ControllerBase
    {
        IAdministrarProductoService _productoService;
        public AdministrarProductoController(IAdministrarProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        public IActionResult ObtenerTodosProductos()
        {
            var result = new ServiceResponse<List<ProductoDTO>>();

            try
            {
                var response = _productoService.ObtenerTodoProducto().ToList();

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
        public IActionResult InsertarProducto(List<ProductoDTO> productoDTO)
        {

            var result = new ServiceResponse<List<ProductoDTO>>();

            try
            {
                var response = _productoService.GuardarProducto(productoDTO).ToList();

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

        [HttpPut]
        public IActionResult ActualizarProducto(List<ProductoDTO> ProductoDTO)
        {
            var result = new ServiceResponse<List<ProductoDTO>>();

            try
            {
                var response = _productoService.ActualizarProducto(ProductoDTO).ToList();

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
        public IActionResult EliminarProducto(List<Guid> id)
        {
            var result = new ServiceResponse<ProductoDTO>();

            try
            {
                _productoService.EliminarProducto(id);

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
