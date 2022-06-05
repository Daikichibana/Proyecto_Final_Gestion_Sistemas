using AutoMapper;
using CAPAS.CAPA.DOMINIO;
using CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.ABSTRACCIONES;
using CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.DTO;
using CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.ENTIDADES;
using CAPAS.CAPA.DOMINIO.INVENTARIO.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CAPA.APLICACION.Controllers.Distribuidoras
{
    /// <summary>
    ///  
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AdministrarDistribuidoraController : ControllerBase
    {
        /// <summary>
        ///  
        /// </summary>
        IMapper _mapper;
        IAdministrarDistribuidoraService _AdministrarDistribuidoraService;

        /// <summary>
        ///  
        /// </summary>
        public AdministrarDistribuidoraController(IMapper mapper, IAdministrarDistribuidoraService administrarDistribuidoraService)
        {
            _mapper = mapper;
            _AdministrarDistribuidoraService = administrarDistribuidoraService;
        }
        /// <summary>
        ///  
        /// </summary>
        [HttpGet]
        public IActionResult ObtenerTodos()
        {

            var result = new ServiceResponse<List<EmpresaDistribuidoraDTO>>();

            try
            {
                IList<EmpresaDistribuidora> Empresas = _AdministrarDistribuidoraService.ObtenerTodo();
                List<EmpresaDistribuidoraDTO> response = new List<EmpresaDistribuidoraDTO>();

                foreach (var EmpresaDistribuidora in Empresas)
                {
                    response.Add(_mapper.Map<EmpresaDistribuidoraDTO>(EmpresaDistribuidora));
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
        public IActionResult InsertarEmpresa(EmpresaDistribuidoraDTO _empresaDistribuidoraDTO )
        {

            var result = new ServiceResponse<EmpresaDistribuidoraDTO>();

            try
            {
                EmpresaDistribuidora nuevaEmpresa = _mapper.Map<EmpresaDistribuidora>(_empresaDistribuidoraDTO);

                var response = _AdministrarDistribuidoraService.Guardar(nuevaEmpresa);

                result.Data = _mapper.Map<EmpresaDistribuidoraDTO>(response);
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
        [HttpPut]
        public IActionResult ActualizarEmpresao(EmpresaDistribuidoraDTO empresaDistribuidoraDTO)
        {
            var result = new ServiceResponse<EmpresaDistribuidoraDTO>();

            try
            {
                EmpresaDistribuidora nuevaEmpresa = _mapper.Map<EmpresaDistribuidora>(empresaDistribuidoraDTO);
                var response = _AdministrarDistribuidoraService.Actualizar(nuevaEmpresa);

                result.Data = _mapper.Map<EmpresaDistribuidoraDTO>(response);
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
        public IActionResult EliminarEmpresa(Guid id)
        {
            var result = new ServiceResponse<EmpresaDistribuidoraDTO>();

            try
            {
                _AdministrarDistribuidoraService.Eliminar(id);

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
