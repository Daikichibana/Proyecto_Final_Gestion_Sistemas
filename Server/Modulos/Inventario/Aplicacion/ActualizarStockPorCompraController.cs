using AutoMapper;
using Compartido;
using Compartido.Dto.Inventario.General;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Aplicacion
{ 
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ActualizarStockPorCompraController : ControllerBase
    {
        IActualizarStockPorCompraService _StockService;
        IMapper _mapper;
        public ActualizarStockPorCompraController(IActualizarStockPorCompraService StockService, IMapper mapper)
        {
            _StockService = StockService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ObtenerTodosStock()
        {

            var result = new ServiceResponse<List<StockDTO>>();

            try
            {
                var response = _StockService.ObtenerTodoStock().ToList();

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
        public IActionResult ObtenerPorIdStock(Guid Id)
        {

            var result = new ServiceResponse<StockDTO>();

            try
            {
                var response = _StockService.ObtenerPorIdStock(Id);

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
        public IActionResult ActualizarStock(List<StockDTO> nuevoStock)
        {
            var result = new ServiceResponse<List<StockDTO>>();

            try
            {
                var response = _StockService.ActualizarStock(nuevoStock).ToList();

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

    }
}
