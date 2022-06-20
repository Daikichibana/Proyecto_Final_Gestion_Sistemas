using Compartido;
using Compartido.Dto.Distribuidora;
using Compartido.Dto.Distribuidora.General;
using Compartido.Dto.Pedidos.General;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Proyecto_Final_Gestion_Sistemas.Client.Services.Implementaciones
{
    public class DistribuidorasServices : IDistribuidorasServices
    {

        private readonly HttpClient _http;
        private string BaseRubro = "api/AdministrarRubro";
        private string BaseEmpresaDistribuidora = "api/AdministrarDistribuidora";
        private string BaseEmpresaCliente = "api/AdministrarCliente";
        private string BaseSucursal = "api/AdministrarSucursales";
        private string BaseVehiculo = "api/AdministrarVechiculo";
        private string BaseTarjetaCliente = "api/AdministrarTarjetaCliente";
        private string BaseProveedor = "api/AdministrarProveedor";

        public DistribuidorasServices(HttpClient http)
        {
            _http = http;
        }

        #region Administrar Rubro
        public async Task<ServiceResponse<List<RubroDTO>>> ObtenerTodosLosRubros()
        {
            string EnlaceRubro = BaseRubro + "/";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<RubroDTO>>>(EnlaceRubro);
            return result;
        }
        public async Task<ServiceResponse<List<RubroDTO>>> InsertarRubro(IList<RubroDTO> rubroDTO)
        {
            string EnlaceRubro = BaseRubro + "/";
            var result = await _http.PostAsJsonAsync(EnlaceRubro, rubroDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<List<RubroDTO>>>();

            return content;
        }
        public async Task<ServiceResponse<List<RubroDTO>>> ActualizarRubro(IList<RubroDTO> rubroDTO)
        {
            string EnlaceRubro = BaseRubro + "/";
            var result = await _http.PutAsJsonAsync(EnlaceRubro, rubroDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<List<RubroDTO>>>();

            return content;
        }
        public async Task<ServiceResponse<RubroDTO>> EliminarRubro(Guid Id)
        {
            string EnlaceRubro = BaseRubro + "/";
            var result = await _http.DeleteAsync(EnlaceRubro);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<RubroDTO>>();

            return content;
        }
        #endregion

        #region Administrar Empresa Distribuidora
        public async Task<ServiceResponse<List<EmpresaDistribuidoraDTO>>> ObtenerTodoDistribuidora()
        {
            string EnlaceEmpresaDistribuidora = BaseEmpresaDistribuidora + "/ObtenerTodoDistribuidora";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<EmpresaDistribuidoraDTO>>>(EnlaceEmpresaDistribuidora);
            return result;
        }
        public async Task<ServiceResponse<EmpresaDistribuidoraDTO>> InsertarDistribuidora(EmpresaDistribuidoraDTO Empresa)
        {
            string EnlaceEmpresaDistribuidora = BaseEmpresaDistribuidora + "/";
            var result = await _http.PostAsJsonAsync(EnlaceEmpresaDistribuidora, Empresa);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<EmpresaDistribuidoraDTO>>();

            return content;
        }
        public async Task<ServiceResponse<EmpresaDistribuidoraDTO>> ActualizarDistribuidora(EmpresaDistribuidoraDTO Empresa)
        {
            string EnlaceEmpresaDistribuidora = BaseEmpresaDistribuidora + "/";
            var result = await _http.PutAsJsonAsync(EnlaceEmpresaDistribuidora, Empresa);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<EmpresaDistribuidoraDTO>>();

            return content;
        }
        public async Task<ServiceResponse<EmpresaDistribuidoraDTO>> EliminarDistribuidora(Guid Id)
        {
            string EnlaceEmpresaDistribuidora = BaseEmpresaDistribuidora + "/";
            var result = await _http.DeleteAsync(EnlaceEmpresaDistribuidora);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<EmpresaDistribuidoraDTO>>();

            return content;
        }
        #endregion

        #region Administrar Empresa Cliente
        public async Task<ServiceResponse<List<EmpresaClienteDTO>>> ObtenerTodasLasEmpresaClientes()
        {
            string EnlaceEmpresaCliente = BaseEmpresaCliente + "/";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<EmpresaClienteDTO>>>(EnlaceEmpresaCliente);
            return result;
        }
        public async Task<ServiceResponse<EmpresaClienteDTO>> InsertarEmpresaCliente(EmpresaClienteDTO empresaClienteDTO)
        {
            string EnlaceEmpresaCliente = BaseEmpresaCliente + "/";
            var result = await _http.PostAsJsonAsync(EnlaceEmpresaCliente, empresaClienteDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<EmpresaClienteDTO>>();

            return content;
        }
        public async Task<ServiceResponse<EmpresaClienteDTO>> ActualizarEmpresaCliente(EmpresaClienteDTO empresaClienteDTO)
        {
            string EnlaceEmpresaCliente = BaseEmpresaCliente + "/";
            var result = await _http.PutAsJsonAsync(EnlaceEmpresaCliente, empresaClienteDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<EmpresaClienteDTO>>();

            return content;
        }
        public async Task<ServiceResponse<EmpresaClienteDTO>> EliminarEmpresaCliente(Guid Id)
        {
            string EnlaceEmpresaCliente = BaseEmpresaCliente + "/";
            var result = await _http.DeleteAsync(EnlaceEmpresaCliente);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<EmpresaClienteDTO>>();

            return content;
        }
        public async Task<ServiceResponse<List<ClientesDistribuidoraDTO>>> ObtenerDistribuidorasDeCliente(Guid Id)
        {
            string EnlaceEmpresaCliente = BaseEmpresaCliente + $"/ObtenerDistribuidorasDeCliente?Id={Id}";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<ClientesDistribuidoraDTO>>>(EnlaceEmpresaCliente);
            return result;
        }
        public async Task<ServiceResponse<ClientesDistribuidoraDTO>> InsertarDistribuidorasDeCliente(ClientesDistribuidoraDTO clienteDistribuidora)
        {
            string EnlaceEmpresaCliente = BaseEmpresaCliente + "/InsertarDistribuidorasDeCliente";
            var result = await _http.PostAsJsonAsync(EnlaceEmpresaCliente, clienteDistribuidora);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<ClientesDistribuidoraDTO>>();

            return content;
        }
        public async Task<ServiceResponse<List<ClientesDistribuidoraDTO>>> EliminarDistribuidorasDeCliente(Guid Id)
        {
            string EnlaceEmpresaCliente = BaseEmpresaCliente + $"/EliminarDistribuidorasDeCliente?Id={Id}";
            var result = await _http.DeleteAsync(EnlaceEmpresaCliente);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<List<ClientesDistribuidoraDTO>>>();

            return content;
        }
        #endregion

        #region Administrar Tarjeta Cliente
        public async Task<ServiceResponse<List<TarjetaClienteDTO>>> ObtenerTodasLasTarjetaClientes()
        {
            string EnlaceTarjetaCliente = BaseTarjetaCliente + "/";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<TarjetaClienteDTO>>>(EnlaceTarjetaCliente);
            return result;
        }
        public async Task<ServiceResponse<List<TarjetaClienteDTO>>> InsertarTarjetaCliente(IList<TarjetaClienteDTO> tarjetaClienteDTO)
        {
            string EnlaceTarjetaCliente = BaseTarjetaCliente + "/";
            var result = await _http.PostAsJsonAsync(EnlaceTarjetaCliente, tarjetaClienteDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<List<TarjetaClienteDTO>>>();

            return content;
        }
        public async Task<ServiceResponse<List<TarjetaClienteDTO>>> ActualizarTarjetaCliente(IList<TarjetaClienteDTO> tarjetaClienteDTO)
        {
            string EnlaceTarjetaCliente = BaseTarjetaCliente + "/";
            var result = await _http.PutAsJsonAsync(EnlaceTarjetaCliente, tarjetaClienteDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<List<TarjetaClienteDTO>>>();

            return content;
        }
        public async Task<ServiceResponse<TarjetaClienteDTO>> EliminarTarjetaCliente(Guid id)
        {
            string EnlaceTarjetaCliente = BaseTarjetaCliente + "/";
            var result = await _http.DeleteAsync(EnlaceTarjetaCliente);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<TarjetaClienteDTO>>();

            return content;
        }
        #endregion

        #region Administrar Sucursales
        public async Task<ServiceResponse<List<SucursalesDTO>>> ObtenerTodasLasSucursales()
        {
            string EnlaceSucursal = BaseSucursal + "/";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<SucursalesDTO>>>(EnlaceSucursal);
            return result;
        }
        public async Task<ServiceResponse<List<SucursalesDTO>>> InsertarSucursal(IList<SucursalesDTO> sucursalesDTO)
        {
            string EnlaceSucursal = BaseSucursal + "/";
            var result = await _http.PostAsJsonAsync(EnlaceSucursal, sucursalesDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<List<SucursalesDTO>>>();

            return content;
        }
        public async Task<ServiceResponse<List<SucursalesDTO>>> ActualizarSucursal(IList<SucursalesDTO> sucursalesDTO)
        {
            string EnlaceSucursal = BaseSucursal + "/";
            var result = await _http.PutAsJsonAsync(EnlaceSucursal, sucursalesDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<List<SucursalesDTO>>>();

            return content;
        }
        public async Task<ServiceResponse<List<SucursalesDTO>>> EliminarSucursal(Guid Id)
        {
            string EnlaceSucursal = BaseSucursal + "/";
            var result = await _http.DeleteAsync(EnlaceSucursal);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<List<SucursalesDTO>>>();

            return content;
        }
        #endregion

        #region Administrar Vehiculo
        public async Task<ServiceResponse<List<VehiculoDTO>>> ObtenerTodosLosVehiculos()
        {
            string EnlaceVehiculo = BaseVehiculo + "/";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<VehiculoDTO>>>(EnlaceVehiculo);
            return result;
        }
        public async Task<ServiceResponse<List<VehiculoDTO>>> CrearVehiculo(IList<VehiculoDTO> vehiculoDTO)
        {
            string EnlaceVehiculo = BaseVehiculo + "/";
            var result = await _http.PostAsJsonAsync(EnlaceVehiculo, vehiculoDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<List<VehiculoDTO>>>();

            return content;
        }
        public async Task<ServiceResponse<List<VehiculoDTO>>> ActualizarVehiculo(IList<VehiculoDTO> vehiculoDTO)
        {
            string EnlaceVehiculo = BaseVehiculo + "/";
            var result = await _http.PutAsJsonAsync(EnlaceVehiculo, vehiculoDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<List<VehiculoDTO>>>();

            return content;
        }
        public async Task<ServiceResponse<List<VehiculoDTO>>> EliminarVehiculo(Guid id)
        {
            string EnlaceVehiculo = BaseVehiculo + "/";
            var result = await _http.DeleteAsync(EnlaceVehiculo);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<List<VehiculoDTO>>>();

            return content;
        }
        public async Task<ServiceResponse<List<AsignacionVechiculoConductorDTO>>> AsignarVehiculoAConductor(AsignacionVechiculoConductorDTO vehiculoDTO)
        {
            string EnlaceVehiculo = BaseVehiculo + "/";
            var result = await _http.PostAsJsonAsync(EnlaceVehiculo, vehiculoDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<List<AsignacionVechiculoConductorDTO>>>();

            return content;
        }
        public async Task<ServiceResponse<List<AsignacionVechiculoConductorDTO>>> ObtenerTodoVehiculoConductor()
        {
            string EnlaceVehiculo = BaseVehiculo + "/";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<AsignacionVechiculoConductorDTO>>>(EnlaceVehiculo);
            return result;
        }
        #endregion

        #region Administrar Proveedor
        public async Task<ServiceResponse<List<EmpresaProveedorDTO>>> ObtenerTodosLosProveedores()
        {
            string EnlaceProveedor = BaseProveedor + "/";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<EmpresaProveedorDTO>>>(EnlaceProveedor);
            return result;
        }
        public async Task<ServiceResponse<List<EmpresaProveedorDTO>>> CrearProveedor(List<EmpresaProveedorDTO> empresaProveedorDTO)
        {
            string EnlaceProveedor = BaseProveedor + "/";
            var result = await _http.PostAsJsonAsync(EnlaceProveedor, empresaProveedorDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<List<EmpresaProveedorDTO>>>();

            return content;
        }
        public async Task<ServiceResponse<List<EmpresaProveedorDTO>>> ActualizarProveedor(List<EmpresaProveedorDTO> empresaProveedorDTO)
        {
            string EnlaceProveedor = BaseProveedor + "/";
            var result = await _http.PutAsJsonAsync(EnlaceProveedor, empresaProveedorDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<List<EmpresaProveedorDTO>>>();

            return content;
        }
        public async Task<ServiceResponse<EmpresaProveedorDTO>> EliminarProveedor(Guid Id)
        {
            string EnlaceProveedor = BaseProveedor + "/";
            var result = await _http.DeleteAsync(EnlaceProveedor);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<EmpresaProveedorDTO>>();

            return content;
        }
        #endregion
    }
}
