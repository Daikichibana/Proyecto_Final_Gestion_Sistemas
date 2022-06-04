using AutoMapper;
using CAPAS.CAPA.DOMINIO;
using CAPAS.CAPA.DOMINIO.INVENTARIO.ABSTRACCIONES;
using CAPAS.CAPA.DOMINIO.INVENTARIO.DTO;
using CAPAS.CAPA.DOMINIO.INVENTARIO.ENTIDADES;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CAPA.APLICACION.Controllers.Inventario
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministrarProductoController : ControllerBase
    {
        IMapper _mapper;
        IAdministrarProductoService _productoService;
        public AdministrarProductoController(IMapper mapper, IAdministrarProductoService productoService)
        {
            _mapper = mapper;
            _productoService = productoService;
        }

        [HttpGet]
        public IActionResult ObtenerTodosProductos()
        {

            var result = new ServiceResponse<List<ProductoDTO>>();

            try
            {
                IList<Producto> Productos = _productoService.ObtenerTodo();
                List<ProductoDTO> response = new List<ProductoDTO>();

                foreach (var Producto in Productos)
                {
                    response.Add(_mapper.Map<ProductoDTO>(Producto));
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

        public IActionResult InsertarProducto(ProductoDTO _productoDTO)
        {

            var result = new ServiceResponse<ProductoDTO>();

            try
            {
                Producto nuevoProducto = _mapper.Map<Producto>(_productoDTO);

                var response = _productoService.Guardar(nuevoProducto);

                result.Data = _mapper.Map<ProductoDTO>(response);
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
        public IActionResult ActualizarProducto(ProductoDTO ProductoDTO)
        {
            var result = new ServiceResponse<ProductoDTO>();

            try
            {
                Producto nuevoProducto = _mapper.Map<Producto>(ProductoDTO);
                var response = _productoService.Actualizar(nuevoProducto);

                result.Data = _mapper.Map<ProductoDTO>(response);
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
        public IActionResult EliminarProducto(Guid id)
        {
            var result = new ServiceResponse<ProductoDTO>();

            try
            {
                _productoService.Eliminar(id);

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
