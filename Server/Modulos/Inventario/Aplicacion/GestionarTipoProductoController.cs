using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Entidades;
using Compartido;
using Compartido.Modulos.Inventario.Dto;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Aplicacion
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
