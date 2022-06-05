﻿using AutoMapper;
using CAPAS.CAPA.DOMINIO;
using CAPAS.CAPA.DOMINIO.BASICO.ABSTRACCIONES;
using CAPAS.CAPA.DOMINIO.BASICO.DTO;
using CAPAS.CAPA.DOMINIO.BASICO.ENTIDADES;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Proyecto_Final_Gestion_Sistemas.Server.Controllers.Basico
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministrarResponsableEmpresaController : ControllerBase
    {
        IMapper _mapper;
        IResponsableEmpresaService _responsableEmpresaService;

        public AdministrarResponsableEmpresaController(IMapper mapper, IResponsableEmpresaService responsableEmpresaService)
        {
            _mapper = mapper;
            _responsableEmpresaService = responsableEmpresaService;
        }

        [HttpGet]
        public IActionResult ObtenerTodosLosResponsables()
        {
            ServiceResponse<List<ResponsableEmpresaDTO>> result = new ServiceResponse<List<ResponsableEmpresaDTO>>();
            try
            {
                var response = _responsableEmpresaService.ObtenerTodo();

                result.Data = _mapper.Map<List<ResponsableEmpresaDTO>>(response);
                result.Message = "Ok";
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
        public IActionResult InsertarNIT(ResponsableEmpresaDTO _responsableDTO)
        {
            ServiceResponse<ResponsableEmpresaDTO> result = new ServiceResponse<ResponsableEmpresaDTO>();
            try
            {
                ResponsableEmpresa nuevoResponsable = _mapper.Map<ResponsableEmpresa>(_responsableDTO);
                var response = _responsableEmpresaService.Guardar(nuevoResponsable);

                result.Data = _mapper.Map<ResponsableEmpresaDTO>(response);
                result.Message = "Ok";
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
        public IActionResult ActualizarResponsableEmpresa(ResponsableEmpresaDTO responsableDTO)
        {
            ServiceResponse<ResponsableEmpresaDTO> result = new ServiceResponse<ResponsableEmpresaDTO>();
            try
            {
                ResponsableEmpresa nuevoResponsable = _mapper.Map<ResponsableEmpresa>(responsableDTO);
                var response = _responsableEmpresaService.Actualizar(nuevoResponsable);

                result.Data = _mapper.Map<ResponsableEmpresaDTO>(response);
                result.Message = "Ok";
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
        public IActionResult EliminarResponsableEmpresa(Guid id)
        {
            ServiceResponse<ResponsableEmpresaDTO> result = new ServiceResponse<ResponsableEmpresaDTO>();
            try
            {
                _responsableEmpresaService.Eliminar(id);

                result.Data = null;
                result.Message = "Ok";
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
