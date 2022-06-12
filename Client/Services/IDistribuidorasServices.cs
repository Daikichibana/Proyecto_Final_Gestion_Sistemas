﻿using Compartido;
using Compartido.Dto.Distribuidora.General;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proyecto_Final_Gestion_Sistemas.Client.Services
{
    public interface IDistribuidorasServices
    {
        #region Rubro
        Task<ServiceResponse<List<RubroDTO>>> ObtenerTodoRubro();
        Task<ServiceResponse<RubroDTO>> CrearRubro(RubroDTO Rubro);
        Task<ServiceResponse<RubroDTO>> ActualizarRubro(RubroDTO Rubro);
        Task<ServiceResponse<RubroDTO>> EliminarRubro(RubroDTO Rubro);
        #endregion

        #region Empresa Distribuidora
        Task<ServiceResponse<EmpresaDistribuidoraDTO>> CrearEmpresaDistribuidora(EmpresaDistribuidoraDTO distribuidora);
        #endregion

        #region Empresa Cliente
        Task<ServiceResponse<EmpresaClienteDTO>> CrearEmpresaCliente(EmpresaClienteDTO cliente);
        #endregion

        #region Sucursales
        Task<ServiceResponse<List<SucursalesDTO>>> ObtenerTodasLasSucursales();
        Task<ServiceResponse<SucursalesDTO>> CrearSucursal(SucursalesDTO sucursalesDTO);
        Task<ServiceResponse<SucursalesDTO>> ActualizarSucursal(SucursalesDTO sucursalesDTO);
        Task<ServiceResponse<SucursalesDTO>> EliminarSucursal(SucursalesDTO sucursalesDTO);
        #endregion  
    }
}
