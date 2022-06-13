using Compartido;
using Compartido.Dto.Distribuidora;
using Compartido.Dto.Distribuidora.General;
using System;
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
        Task<ServiceResponse<EmpresaDistribuidoraDTO>> CrearEmpresaDistribuidora(RegistroEmpresaDTO distribuidora);
        Task<ServiceResponse<List<EmpresaDistribuidoraDTO>>> ObtenerTodoDistribuidora();
        #endregion

        #region Empresa Cliente
        Task<ServiceResponse<EmpresaClienteDTO>> CrearEmpresaCliente(RegistroEmpresaDTO cliente);

        Task<ServiceResponse<List<ClientesDistribuidoraDTO>>> ObtenerDistribuidorasDeCliente();
        Task<ServiceResponse<ClientesDistribuidoraDTO>> InsertarDistribuidorasDeCliente(ClientesDistribuidoraDTO ClienteDistribuidora);
        Task<ServiceResponse<ClientesDistribuidoraDTO>> EliminarDistribuidorasDeCliente(Guid Id);
        Task<ServiceResponse<List<EmpresaClienteDTO>>> ObtenerTodoEmpresaCliente();
        #endregion

        #region TarjetaCliente
        Task<ServiceResponse<List<TarjetaClienteDTO>>> ObtenerTodoTarjetaCliente();
        Task<ServiceResponse<TarjetaClienteDTO>> CrearTarjetaCliente(TarjetaClienteDTO TarjetaCliente);
        Task<ServiceResponse<TarjetaClienteDTO>> ActualizarTarjetaCliente(TarjetaClienteDTO TarjetaCliente);
        Task<ServiceResponse<TarjetaClienteDTO>> EliminarTarjetaCliente(TarjetaClienteDTO TarjetaCliente);
        #endregion

        #region Sucursales
        Task<ServiceResponse<List<SucursalesDTO>>> ObtenerTodasLasSucursales();
        Task<ServiceResponse<SucursalesDTO>> CrearSucursal(SucursalesDTO sucursalesDTO);
        Task<ServiceResponse<SucursalesDTO>> ActualizarSucursal(SucursalesDTO sucursalesDTO);
        Task<ServiceResponse<SucursalesDTO>> EliminarSucursal(SucursalesDTO sucursalesDTO);
        #endregion

        #region Vehiculo
        Task<ServiceResponse<List<VehiculoDTO>>> ObtenerTodosLosVehiculos();
        Task<ServiceResponse<VehiculoDTO>> CrearVehiculo(VehiculoDTO vehiculoDTO);
        Task<ServiceResponse<VehiculoDTO>> ActualizarVehiculo(VehiculoDTO vehiculoDTO);
        Task<ServiceResponse<VehiculoDTO>> EliminarVehiculo(VehiculoDTO vehiculoDTO);
        #endregion

        #region Proveedor
        Task<ServiceResponse<List<EmpresaProveedorDTO>>> ObtenerTodosLosProveedores();
        Task<ServiceResponse<EmpresaProveedorDTO>> CrearProveedor(EmpresaProveedorDTO empresaProveedorDTO);
        Task<ServiceResponse<EmpresaProveedorDTO>> ActualizarProveedor(EmpresaProveedorDTO empresaProveedorDTO);
        Task<ServiceResponse<EmpresaProveedorDTO>> EliminarProveedor(EmpresaProveedorDTO empresaProveedorDTO);
        #endregion
    }
}
