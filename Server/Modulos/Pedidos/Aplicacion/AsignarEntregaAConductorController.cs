using AutoMapper;
using Compartido;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Abstracciones;
using System;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Aplicacion
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class AsignarEntregaAConductorController : ControllerBase
    {
        IAsignarEntregaAConductorService _asignarEntregaAConductorService;
        public AsignarEntregaAConductorController(IAsignarEntregaAConductorService asignarEntregaAConductorService)
        {
            _asignarEntregaAConductorService = asignarEntregaAConductorService;
        }

        [HttpPost]
        public IActionResult AsignarEntregaAconductor(Guid IdConductorVehiculo, Guid IdPedido)
        {
            var result = new ServiceResponse<Object>();

            try
            {
                _asignarEntregaAConductorService.AsignarEntregaAconductor(IdConductorVehiculo, IdPedido);

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
