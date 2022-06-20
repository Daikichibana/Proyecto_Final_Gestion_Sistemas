using Compartido;
using Compartido.Dto.Distribuidora;
using Compartido.Dto.Distribuidora.General;
using Compartido.Dto.Pedidos.General;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proyecto_Final_Gestion_Sistemas.Client.Services
{
    public interface IDistribuidorasServices
    {
        #region Administrar Rubro
        Task<ServiceResponse<List<RubroDTO>>> ObtenerTodosLosRubros();
        Task<ServiceResponse<List<RubroDTO>>> InsertarRubro(IList<RubroDTO> rubroDTO);
        Task<ServiceResponse<List<RubroDTO>>> ActualizarRubro(IList<RubroDTO> rubroDTO);
        Task<ServiceResponse<RubroDTO>> EliminarRubro(Guid Id);
        #endregion

        #region Administrar Empresa Distribuidora
        Task<ServiceResponse<List<EmpresaDistribuidoraDTO>>> ObtenerTodoDistribuidora();
        Task<ServiceResponse<EmpresaDistribuidoraDTO>> InsertarDistribuidora(EmpresaDistribuidoraDTO Empresa);
        Task<ServiceResponse<EmpresaDistribuidoraDTO>> ActualizarDistribuidora(EmpresaDistribuidoraDTO Empresa);
        Task<ServiceResponse<EmpresaDistribuidoraDTO>> EliminarDistribuidora(Guid Id);
        #endregion

        #region Administrar Empresa Cliente
        Task<ServiceResponse<List<EmpresaClienteDTO>>> ObtenerTodasLasEmpresaClientes();
        Task<ServiceResponse<EmpresaClienteDTO>> InsertarEmpresaCliente(EmpresaClienteDTO empresaClienteDTO);
        Task<ServiceResponse<EmpresaClienteDTO>> ActualizarEmpresaCliente(EmpresaClienteDTO empresaClienteDTO);
        Task<ServiceResponse<EmpresaClienteDTO>> EliminarEmpresaCliente(Guid Id);
        Task<ServiceResponse<List<ClientesDistribuidoraDTO>>> ObtenerDistribuidorasDeCliente(Guid Id);
        Task<ServiceResponse<ClientesDistribuidoraDTO>> InsertarDistribuidorasDeCliente(ClientesDistribuidoraDTO clienteDistribuidora);
        Task<ServiceResponse<List<ClientesDistribuidoraDTO>>> EliminarDistribuidorasDeCliente(Guid Id);
        #endregion

        #region Administrar Tarjeta Cliente
        Task<ServiceResponse<List<TarjetaClienteDTO>>> ObtenerTodasLasTarjetaClientes();
        Task<ServiceResponse<List<TarjetaClienteDTO>>> InsertarTarjetaCliente(IList<TarjetaClienteDTO> tarjetaClienteDTO);
        Task<ServiceResponse<List<TarjetaClienteDTO>>> ActualizarTarjetaCliente(IList<TarjetaClienteDTO> tarjetaClienteDTO);
        Task<ServiceResponse<TarjetaClienteDTO>> EliminarTarjetaCliente(Guid id);
        #endregion

        #region Administrar Sucursales
        Task<ServiceResponse<List<SucursalesDTO>>> ObtenerTodasLasSucursales();
        Task<ServiceResponse<List<SucursalesDTO>>> InsertarSucursal(IList<SucursalesDTO> sucursalesDTO);
        Task<ServiceResponse<List<SucursalesDTO>>> ActualizarSucursal(IList<SucursalesDTO> sucursalesDTO);
        Task<ServiceResponse<List<SucursalesDTO>>> EliminarSucursal(Guid Id);
        #endregion

        #region Administrar Vehiculo
        Task<ServiceResponse<List<VehiculoDTO>>> ObtenerTodosLosVehiculos();
        Task<ServiceResponse<List<VehiculoDTO>>> CrearVehiculo(IList<VehiculoDTO> vehiculoDTO);
        Task<ServiceResponse<List<VehiculoDTO>>> ActualizarVehiculo(IList<VehiculoDTO> vehiculoDTO);
        Task<ServiceResponse<List<VehiculoDTO>>> EliminarVehiculo(Guid id);
        Task<ServiceResponse<List<AsignacionVechiculoConductorDTO>>> AsignarVehiculoAConductor(AsignacionVechiculoConductorDTO vehiculoDTO);
        Task<ServiceResponse<List<AsignacionVechiculoConductorDTO>>> ObtenerTodoVehiculoConductor();
        #endregion

        #region Administrar Proveedor
        Task<ServiceResponse<List<EmpresaProveedorDTO>>> ObtenerTodosLosProveedores();
        Task<ServiceResponse<List<EmpresaProveedorDTO>>> CrearProveedor(List<EmpresaProveedorDTO> empresaProveedorDTO);
        Task<ServiceResponse<List<EmpresaProveedorDTO>>> ActualizarProveedor(List<EmpresaProveedorDTO> empresaProveedorDTO);
        Task<ServiceResponse<EmpresaProveedorDTO>> EliminarProveedor(Guid Id);
        #endregion

    }
}
