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

        #region Adminsitrar Rubro

        public async Task<ServiceResponse<RubroDTO>> ActualizarRubro(RubroDTO Rubro)
        {
            string EnlaceRubro = BaseRubro + "";
            var result = await _http.PutAsJsonAsync(EnlaceRubro, Rubro);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<RubroDTO>>();

            return content;
        }

        public async Task<ServiceResponse<RubroDTO>> CrearRubro(RubroDTO Rubro)
        {
            string EnlaceRubro = BaseRubro + "";
            var result = await _http.PostAsJsonAsync(EnlaceRubro, Rubro);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<RubroDTO>>();

            return content;
        }

        public async Task<ServiceResponse<RubroDTO>> EliminarRubro(RubroDTO Rubro)
        {
            string EnlaceRubro = $"{BaseRubro}/?Id={Rubro.Id}";
            var result = await _http.DeleteAsync(EnlaceRubro);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<RubroDTO>>();

            return content;
        }

        public async Task<ServiceResponse<List<RubroDTO>>> ObtenerTodoRubro()
        {
            string EnlaceRubro = BaseRubro + "";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<RubroDTO>>>(EnlaceRubro);
            return result;
        }

        #endregion

        #region Adminsitrar Empresa Distribuidora
        public async Task<ServiceResponse<EmpresaDistribuidoraDTO>> CrearEmpresaDistribuidora(RegistroEmpresaDTO distribuidora)
        {
            string EnlaceEmpresaDistribuidora = BaseEmpresaDistribuidora + "";
            var result = await _http.PostAsJsonAsync(EnlaceEmpresaDistribuidora, distribuidora);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<EmpresaDistribuidoraDTO>>();

            return content;
        }

        public async Task<ServiceResponse<List<EmpresaDistribuidoraDTO>>> ObtenerTodoDistribuidora()
        {
            string EnlaceEmpresaDistribuidora = BaseEmpresaDistribuidora + "";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<EmpresaDistribuidoraDTO>>>(EnlaceEmpresaDistribuidora);
            return result;
        }
        #endregion

        #region Administrar Empresa Cliente
        public async Task<ServiceResponse<EmpresaClienteDTO>> CrearEmpresaCliente(RegistroEmpresaDTO cliente)
        {
            var EnlaceEmpresaCliente = BaseEmpresaCliente + "/InsertarEmpresa";
            var result = await _http.PostAsJsonAsync(EnlaceEmpresaCliente, cliente);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<EmpresaClienteDTO>>();

            return content;
        }
        public async Task<ServiceResponse<List<EmpresaClienteDTO>>> ObtenerTodoEmpresaCliente()
        {
            var EnlaceEmpresaCliente = BaseEmpresaCliente + "/ObtenerTodasLasEmpresaClientes";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<EmpresaClienteDTO>>>(EnlaceEmpresaCliente);
            return result;
        }

        #endregion

        #region Adminsitrar Tarjeta Cliente

        public async Task<ServiceResponse<TarjetaClienteDTO>> ActualizarTarjetaCliente(TarjetaClienteDTO TarjetaCliente)
        {
            string EnlaceTarjetaCliente = BaseTarjetaCliente + "";
            var result = await _http.PutAsJsonAsync(EnlaceTarjetaCliente, TarjetaCliente);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<TarjetaClienteDTO>>();

            return content;
        }

        public async Task<ServiceResponse<TarjetaClienteDTO>> CrearTarjetaCliente(TarjetaClienteDTO TarjetaCliente)
        {
            string EnlaceTarjetaCliente = BaseTarjetaCliente + "";
            var result = await _http.PostAsJsonAsync(EnlaceTarjetaCliente, TarjetaCliente);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<TarjetaClienteDTO>>();

            return content;
        }

        public async Task<ServiceResponse<TarjetaClienteDTO>> EliminarTarjetaCliente(TarjetaClienteDTO TarjetaCliente)
        {
            string EnlaceTarjetaCliente = $"{BaseTarjetaCliente}/?Id={TarjetaCliente.Id}";
            var result = await _http.DeleteAsync(EnlaceTarjetaCliente);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<TarjetaClienteDTO>>();

            return content;
        }

        public async Task<ServiceResponse<List<TarjetaClienteDTO>>> ObtenerTodoTarjetaCliente()
        {
            string EnlaceTarjetaCliente = BaseTarjetaCliente + "";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<TarjetaClienteDTO>>>(EnlaceTarjetaCliente);
            return result;
        }


        public async Task<ServiceResponse<ClientesDistribuidoraDTO>> InsertarDistribuidorasDeCliente(ClientesDistribuidoraDTO ClienteDistribuidora)
        {
            string EnlaceEmpresaCliente = BaseEmpresaCliente + "";
            var EnlaceArmado = EnlaceEmpresaCliente + "/InsertarDistribuidorasDeCliente";
            var result = await _http.PostAsJsonAsync(EnlaceArmado, ClienteDistribuidora);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<ClientesDistribuidoraDTO>>();

            return content;
        }
        public async Task<ServiceResponse<List<ClientesDistribuidoraDTO>>> ObtenerDistribuidorasDeCliente()
        {
            var EnlaceEmpresaCliente = BaseEmpresaCliente + "/ObtenerDistribuidorasDeCliente";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<ClientesDistribuidoraDTO>>>(EnlaceEmpresaCliente);
            return result;
        }

        public async Task<ServiceResponse<ClientesDistribuidoraDTO>> EliminarDistribuidorasDeCliente(Guid Id)
        {
            var EnlaceEmpresaCliente = BaseEmpresaCliente + $"/EliminarDistribuidorasDeCliente?Id={Id}";
            var result = await _http.DeleteAsync(EnlaceEmpresaCliente);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<ClientesDistribuidoraDTO>>();

            return content;
        }

        #endregion

        #region Administrar Sucursales
        public async Task<ServiceResponse<SucursalesDTO>> ActualizarSucursal(SucursalesDTO sucursalesDTO)
        {
            string EnlaceSucursal = BaseSucursal + "";
            var result = await _http.PutAsJsonAsync(EnlaceSucursal, sucursalesDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<SucursalesDTO>>();

            return content;
        }

        public async Task<ServiceResponse<SucursalesDTO>> CrearSucursal(SucursalesDTO sucursalesDTO)
        {
            string EnlaceSucursal = BaseSucursal + "";
            var result = await _http.PostAsJsonAsync(EnlaceSucursal, sucursalesDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<SucursalesDTO>>();

            return content;
        }

        public async Task<ServiceResponse<SucursalesDTO>> EliminarSucursal(SucursalesDTO sucursalesDTO)
        {
            string EnlaceSucursal = BaseSucursal + $"/?Id={sucursalesDTO.Id}";
            var result = await _http.DeleteAsync(EnlaceSucursal);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<SucursalesDTO>>();

            return content;
        }

        public async Task<ServiceResponse<List<SucursalesDTO>>> ObtenerTodasLasSucursales()
        {
            string EnlaceSucursal = BaseSucursal + "";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<SucursalesDTO>>>(EnlaceSucursal);
            return result;
        }
        #endregion

        #region Administrar Vehiculo
        public async Task<ServiceResponse<VehiculoDTO>> ActualizarVehiculo(VehiculoDTO vehiculoDTO)
        {
            var EnlaceVehiculo = BaseVehiculo + "/ActualizarVehiculo";
            var result = await _http.PutAsJsonAsync(EnlaceVehiculo, vehiculoDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<VehiculoDTO>>();

            return content;
        }

        public async Task<ServiceResponse<VehiculoDTO>> CrearVehiculo(VehiculoDTO vehiculoDTO)
        {
            var EnlaceVehiculo = BaseVehiculo + "/CrearVehiculo";
            var result = await _http.PostAsJsonAsync(EnlaceVehiculo, vehiculoDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<VehiculoDTO>>();

            return content;
        }

        public async Task<ServiceResponse<VehiculoDTO>> EliminarVehiculo(VehiculoDTO vehiculoDTO)
        {
            var EnlaceVehiculo = BaseVehiculo + $"/EliminarVehiculo?Id={vehiculoDTO.Id}";
            var result = await _http.DeleteAsync(EnlaceVehiculo);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<VehiculoDTO>>();

            return content;
        }

        public async Task<ServiceResponse<AsignacionVechiculoConductorDTO>> AsignarVehiculoAConductor(AsignacionVechiculoConductorDTO vhconductor)
        {
            var EnlaceVehiculo = BaseVehiculo + "/AsignarVehiculoAConductor";
            var result = await _http.PostAsJsonAsync(EnlaceVehiculo, vhconductor);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<AsignacionVechiculoConductorDTO>>();

            return content;
        }

        public async Task<ServiceResponse<List<AsignacionVechiculoConductorDTO>>> ObtenerTodoVehiculoConductor()
        {
            var EnlaceVehiculo = BaseVehiculo + "/ObtenerTodoVehiculoConductor";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<AsignacionVechiculoConductorDTO>>>(EnlaceVehiculo);
            return result;
        }
        public async Task<ServiceResponse<List<VehiculoDTO>>> ObtenerTodosLosVehiculos()
        {
            var EnlaceVehiculo = BaseVehiculo + "/ObtenerTodosLosVehiculos";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<VehiculoDTO>>>(EnlaceVehiculo);
            return result;
        }
        #endregion

        #region Adminsitrar Proveedor
        public async Task<ServiceResponse<EmpresaProveedorDTO>> ActualizarProveedor(EmpresaProveedorDTO empresaProveedorDTO)
        {
            string EnlaceProveedor = BaseProveedor + "";
            var result = await _http.PutAsJsonAsync(EnlaceProveedor, empresaProveedorDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<EmpresaProveedorDTO>>();

            return content;
        }

        public async Task<ServiceResponse<EmpresaProveedorDTO>> CrearProveedor(EmpresaProveedorDTO empresaProveedorDTO)
        {
            string EnlaceProveedor = BaseProveedor + "";
            var result = await _http.PostAsJsonAsync(EnlaceProveedor, empresaProveedorDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<EmpresaProveedorDTO>>();

            return content;
        }

        public async Task<ServiceResponse<EmpresaProveedorDTO>> EliminarProveedor(EmpresaProveedorDTO empresaProveedorDTO)
        {
            string EnlaceProveedor = BaseProveedor + $"/?Id={empresaProveedorDTO.Id}";
            var result = await _http.DeleteAsync(EnlaceProveedor);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<EmpresaProveedorDTO>>();

            return content;
        }

        public async Task<ServiceResponse<List<EmpresaProveedorDTO>>> ObtenerTodosLosProveedores()
        {
            string EnlaceProveedor = BaseProveedor + "/";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<EmpresaProveedorDTO>>>(EnlaceProveedor);
            return result;
        }
        #endregion

        #region Administrar NIT
        #endregion
    }
}
