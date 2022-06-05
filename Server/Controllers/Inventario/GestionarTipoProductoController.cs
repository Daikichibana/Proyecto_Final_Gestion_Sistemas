using AutoMapper;
using CAPAS.CAPA.DOMINIO;
using CAPAS.CAPA.DOMINIO.INVENTARIO.ABSTRACCIONES;
using CAPAS.CAPA.DOMINIO.INVENTARIO.DTO;
using CAPAS.CAPA.DOMINIO.INVENTARIO.ENTIDADES;
using CAPAS.CAPA.TECNICA.INVENTARIO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CAPA.APLICACION.Controllers.Inventario
{
    /// <summary>
    ///  
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class GestionarTipoProductoController : ControllerBase
    {
        IMapper _mapper;
        IGestionarTipoProductoService _tipoProductoService;
        /// <summary>
        ///  
        /// </summary>
        public GestionarTipoProductoController(IMapper mapper, IGestionarTipoProductoService tipoProductoService)
        {
            _mapper = mapper;
            _tipoProductoService = tipoProductoService;
        }

        /// <summary>
        ///  
        /// </summary>
        [HttpGet]
        public IActionResult ObtenerTodosLosTipoProducto() {

            var result = new ServiceResponse<List<TipoProductoDTO>>();

            try
            {
                IList<TipoProducto> TiposProductos = _tipoProductoService.ObtenerTodo();
                List<TipoProductoDTO> response = new List<TipoProductoDTO>();

                foreach (var TipoProducto in TiposProductos)
                {
                    response.Add(_mapper.Map<TipoProductoDTO>(TipoProducto));
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

        /// <summary>
        ///  
        /// </summary>
        [HttpPost]
        public IActionResult InsertarTipoProducto(TipoProductoDTO _tipoProductoDTO) {

            var result = new ServiceResponse<TipoProductoDTO>();

            try
            {
                TipoProducto nuevoTipoProducto = _mapper.Map<TipoProducto>(_tipoProductoDTO);

                var response = _tipoProductoService.Guardar(nuevoTipoProducto);

                result.Data = _mapper.Map<TipoProductoDTO>(response);
                result.Message = "Se ha realizado la operacion correctamente.";
                result.Success = true;

                return Ok(result);
            }
            catch (Exception error){
                result.Data = null;
                result.Message = error.Message;
                result.Success = false;

                return BadRequest(result);
            }
        }

        /// <summary>
        ///  
        /// </summary>
        [HttpPut]
        public IActionResult ActualizarTipoProducto(TipoProductoDTO tipoProductoDTO)
        {
            var result = new ServiceResponse<TipoProductoDTO>();

            try
            {
                TipoProducto nuevoTipoProducto = _mapper.Map<TipoProducto>(tipoProductoDTO);
                var response = _tipoProductoService.Actualizar(nuevoTipoProducto);

                result.Data = _mapper.Map<TipoProductoDTO>(response);
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

        /// <summary>
        ///  
        /// </summary>
        [HttpDelete]
        public IActionResult EliminarTipoProducto(Guid id)
        {
            var result = new ServiceResponse<TipoProductoDTO>();

            try
            {
                _tipoProductoService.Eliminar(id);

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
