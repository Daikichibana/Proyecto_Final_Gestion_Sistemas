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
using System.Threading.Tasks;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Aplicacion
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GestionarTipoProductoController : ControllerBase
    {
        IGestionarTipoProductoService _tipoProductoService;
        public GestionarTipoProductoController(IGestionarTipoProductoService tipoProductoService)
        {
            _tipoProductoService = tipoProductoService;
        }

        [HttpGet]
        public IActionResult ObtenerTodosLosTipoProducto() {

            var result = new ServiceResponse<List<TipoProductoDTO>>();

            try
            {
                var response = _tipoProductoService.ObtenerTodoTipoProducto().ToList();

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
        public IActionResult InsertarTipoProducto(List<TipoProductoDTO> tipoProductoDTO) {

            var result = new ServiceResponse<List<TipoProductoDTO>>();

            try
            {
                var response = _tipoProductoService.GuardarTipoProducto(tipoProductoDTO).ToList();

                result.Data = response;
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
        public IActionResult ActualizarTipoProducto(List<TipoProductoDTO> tipoProductoDTO)
        {
            var result = new ServiceResponse<List<TipoProductoDTO>>();

            try
            {
                var response = _tipoProductoService.ActualizarTipoProducto(tipoProductoDTO).ToList();

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
        public IActionResult EliminarTipoProducto(List<Guid> id)
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
