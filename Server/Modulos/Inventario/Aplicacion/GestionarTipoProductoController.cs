using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Entidades;
using Compartido;
using Compartido.Dto.Inventario;
using Compartido.Dto.Inventario.General;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Aplicacion
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GestionarTipoProductoController : ControllerBase
    {
        IMapper _mapper;
        IGestionarTipoProductoService _tipoProductoService;
        public GestionarTipoProductoController(IMapper mapper, IGestionarTipoProductoService tipoProductoService)
        {
            _mapper = mapper;
            _tipoProductoService = tipoProductoService;
        }

        [HttpGet]
        public IActionResult ObtenerTodosLosTipoProducto() {

            var result = new ServiceResponse<List<TipoProductoDTO>>();

            try
            {
                IList<TipoProducto> TiposProductos = _tipoProductoService.ObtenerTodoTipoProducto();
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

        [HttpPost]
        public IActionResult InsertarTipoProducto(TipoProductoDTO _tipoProductoDTO) {

            var result = new ServiceResponse<TipoProductoDTO>();

            try
            {
                TipoProducto nuevoTipoProducto = _mapper.Map<TipoProducto>(_tipoProductoDTO);

                var response = _tipoProductoService.GuardarTipoProducto(nuevoTipoProducto);

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

        [HttpPut]
        public IActionResult ActualizarTipoProducto(TipoProductoDTO tipoProductoDTO)
        {
            var result = new ServiceResponse<TipoProductoDTO>();

            try
            {
                TipoProducto nuevoTipoProducto = _mapper.Map<TipoProducto>(tipoProductoDTO);
                var response = _tipoProductoService.ActualizarTipoProducto(nuevoTipoProducto);

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

        [HttpDelete]
        public IActionResult EliminarTipoProducto(Guid id)
        {
            var result = new ServiceResponse<TipoProductoDTO>();

            try
            {
                _tipoProductoService.EliminarTipoProducto(id);

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
