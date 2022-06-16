﻿using AutoMapper;
using Compartido;
using Compartido.Dto.Inventario.General;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Entidades;
using System;
using System.Collections.Generic;

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
                IList<Stock> Stock = _StockService.ObtenerTodoStock();
                List<StockDTO> response = new List<StockDTO>();

                foreach (var st in Stock)
                {
                    response.Add(_mapper.Map<StockDTO>(st));
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
        public IActionResult InsertarStock(StockDTO _StockDTO)
        {

            var result = new ServiceResponse<StockDTO>();

            try
            {
                var nuevoProducto = _mapper.Map<Stock>(_StockDTO);

                var response = _StockService.GuardarStock(nuevoProducto);

                result.Data = _mapper.Map<StockDTO>(response);
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
        public IActionResult ActualizarStock(StockDTO _StockDTO)
        {
            var result = new ServiceResponse<StockDTO>();

            try
            {
                var nuevoProducto = _mapper.Map<Stock>(_StockDTO);
                var response = _StockService.ActualizarStock(nuevoProducto);

                result.Data = _mapper.Map<StockDTO>(response);
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
        public IActionResult EliminarStock(Guid id)
        {
            var result = new ServiceResponse<StockDTO>();

            try
            {
                _StockService.EliminarStock(id);

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
