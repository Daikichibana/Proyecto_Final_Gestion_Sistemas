using Compartido;
using Compartido.Dto.Distribuidora;
using Compartido.Dto.Distribuidora.General;
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
        private string EnlaceRubro = "api/AdministrarRubro";
        private string EnlaceEmpresaDistribuidora = "api/AdministrarDistribuidora";
        private string EnlaceEmpresaCliente = "api/AdministrarCliente";
        private string EnlaceSucursal = "api/AdministrarSucursales";
        private string EnlaceVehiculo = "api/AdministrarVechiculo";
        private string EnlaceTarjetaCliente = "api/AdministrarTarjetaCliente";
        private string EnlaceProveedor = "api/AdministrarProveedor";

        public DistribuidorasServices(HttpClient http)
        {
            _http = http;
        }

        #region Rubro

        public async Task<ServiceResponse<RubroDTO>> ActualizarRubro(RubroDTO Rubro)
        {
            var result = await _http.PutAsJsonAsync(EnlaceRubro, Rubro);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<RubroDTO>>();

            return content;
        }

        public async Task<ServiceResponse<RubroDTO>> CrearRubro(RubroDTO Rubro)
        {
            var result = await _http.PostAsJsonAsync(EnlaceRubro, Rubro);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<RubroDTO>>();

            return content;
        }

        public async Task<ServiceResponse<RubroDTO>> EliminarRubro(RubroDTO Rubro)
        {
            var result = await _http.DeleteAsync($"{EnlaceRubro}/?Id={Rubro.Id}");
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<RubroDTO>>();

            return content;
        }

        public async Task<ServiceResponse<List<RubroDTO>>> ObtenerTodoRubro()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<RubroDTO>>>(EnlaceRubro);
            return result;
        }

        #endregion

        #region Empresa Distribuidora
        public async Task<ServiceResponse<EmpresaDistribuidoraDTO>> CrearEmpresaDistribuidora(RegistroEmpresaDTO distribuidora)
        {
            var result = await _http.PostAsJsonAsync(EnlaceEmpresaDistribuidora, distribuidora);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<EmpresaDistribuidoraDTO>>();

            return content;
        }

        public async Task<ServiceResponse<List<EmpresaDistribuidoraDTO>>> ObtenerTodoDistribuidora()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<EmpresaDistribuidoraDTO>>>(EnlaceEmpresaDistribuidora);
            return result;
        }
        #endregion

        #region Empresa Cliente
        public async Task<ServiceResponse<EmpresaClienteDTO>> CrearEmpresaCliente(RegistroEmpresaDTO cliente)
        {
            var EnlaceArmado = EnlaceEmpresaCliente + "/InsertarEmpresa";
            var result = await _http.PostAsJsonAsync(EnlaceArmado, cliente);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<EmpresaClienteDTO>>();

            return content;
        }
        public async Task<ServiceResponse<List<EmpresaClienteDTO>>> ObtenerTodoEmpresaCliente()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<EmpresaClienteDTO>>>(EnlaceEmpresaCliente);
            return result;
        }

        #endregion

        #region Tarjeta Cliente

        public async Task<ServiceResponse<TarjetaClienteDTO>> ActualizarTarjetaCliente(TarjetaClienteDTO TarjetaCliente)
        {
            var result = await _http.PutAsJsonAsync(EnlaceTarjetaCliente, TarjetaCliente);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<TarjetaClienteDTO>>();

            return content;
        }

        public async Task<ServiceResponse<TarjetaClienteDTO>> CrearTarjetaCliente(TarjetaClienteDTO TarjetaCliente)
        {
            var result = await _http.PostAsJsonAsync(EnlaceTarjetaCliente, TarjetaCliente);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<TarjetaClienteDTO>>();

            return content;
        }

        public async Task<ServiceResponse<TarjetaClienteDTO>> EliminarTarjetaCliente(TarjetaClienteDTO TarjetaCliente)
        {
            var result = await _http.DeleteAsync($"{EnlaceTarjetaCliente}/?Id={TarjetaCliente.Id}");
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<TarjetaClienteDTO>>();

            return content;
        }

        public async Task<ServiceResponse<List<TarjetaClienteDTO>>> ObtenerTodoTarjetaCliente()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<TarjetaClienteDTO>>>(EnlaceTarjetaCliente);
            return result;
        }


        public async Task<ServiceResponse<ClientesDistribuidoraDTO>> InsertarDistribuidorasDeCliente(ClientesDistribuidoraDTO ClienteDistribuidora)
        {
            var EnlaceArmado = EnlaceEmpresaCliente + "/InsertarDistribuidorasDeCliente";
            var result = await _http.PostAsJsonAsync(EnlaceArmado, ClienteDistribuidora);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<ClientesDistribuidoraDTO>>();

            return content;
        }
        public async Task<ServiceResponse<List<ClientesDistribuidoraDTO>>> ObtenerDistribuidorasDeCliente()
        {
            var EnlaceArmado = EnlaceEmpresaCliente + "/ObtenerDistribuidorasDeCliente";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<ClientesDistribuidoraDTO>>>(EnlaceArmado);
            return result;
        }

        public async Task<ServiceResponse<ClientesDistribuidoraDTO>> EliminarDistribuidorasDeCliente(Guid Id)
        {
            var EnlaceArmado = EnlaceEmpresaCliente + "/EliminarDistribuidorasDeCliente";
            var result = await _http.DeleteAsync($"{EnlaceArmado}?Id={Id}");
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<ClientesDistribuidoraDTO>>();

            return content;
        }

        #endregion

        #region Sucursales
        public async Task<ServiceResponse<SucursalesDTO>> ActualizarSucursal(SucursalesDTO sucursalesDTO)
        {
            var result = await _http.PutAsJsonAsync(EnlaceSucursal, sucursalesDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<SucursalesDTO>>();

            return content;
        }

        public async Task<ServiceResponse<SucursalesDTO>> CrearSucursal(SucursalesDTO sucursalesDTO)
        {
            var result = await _http.PostAsJsonAsync(EnlaceSucursal, sucursalesDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<SucursalesDTO>>();

            return content;
        }

        public async Task<ServiceResponse<SucursalesDTO>> EliminarSucursal(SucursalesDTO sucursalesDTO)
        {
            var result = await _http.DeleteAsync($"{EnlaceSucursal}?Id={sucursalesDTO.Id}");
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<SucursalesDTO>>();

            return content;
        }

        public async Task<ServiceResponse<List<SucursalesDTO>>> ObtenerTodasLasSucursales()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<SucursalesDTO>>>(EnlaceSucursal);
            return result;
        }
        #endregion

        #region Vehiculo
        public async Task<ServiceResponse<VehiculoDTO>> ActualizarVehiculo(VehiculoDTO vehiculoDTO)
        {
            var result = await _http.PutAsJsonAsync(EnlaceVehiculo, vehiculoDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<VehiculoDTO>>();

            return content;
        }

        public async Task<ServiceResponse<VehiculoDTO>> CrearVehiculo(VehiculoDTO vehiculoDTO)
        {
            var result = await _http.PostAsJsonAsync(EnlaceVehiculo, vehiculoDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<VehiculoDTO>>();

            return content;
        }

        public async Task<ServiceResponse<VehiculoDTO>> EliminarVehiculo(VehiculoDTO vehiculoDTO)
        {
            var result = await _http.DeleteAsync($"{EnlaceVehiculo}?Id={vehiculoDTO.Id}");
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<VehiculoDTO>>();

            return content;
        }

        public async Task<ServiceResponse<List<VehiculoDTO>>> ObtenerTodosLosVehiculos()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<VehiculoDTO>>>(EnlaceVehiculo);
            return result;
        }
        #endregion

        #region Proveedor
        public async Task<ServiceResponse<EmpresaProveedorDTO>> ActualizarProveedor(EmpresaProveedorDTO empresaProveedorDTO)
        {
            var result = await _http.PutAsJsonAsync(EnlaceProveedor, empresaProveedorDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<EmpresaProveedorDTO>>();

            return content;
        }

        public async Task<ServiceResponse<EmpresaProveedorDTO>> CrearProveedor(EmpresaProveedorDTO empresaProveedorDTO)
        {
            var result = await _http.PostAsJsonAsync(EnlaceProveedor, empresaProveedorDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<EmpresaProveedorDTO>>();

            return content;
        }

        public async Task<ServiceResponse<EmpresaProveedorDTO>> EliminarProveedor(EmpresaProveedorDTO empresaProveedorDTO)
        {
            var result = await _http.DeleteAsync($"{EnlaceProveedor}?Id={empresaProveedorDTO.Id}");
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<EmpresaProveedorDTO>>();

            return content;
        }

        public async Task<ServiceResponse<List<EmpresaProveedorDTO>>> ObtenerTodosLosProveedores()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<EmpresaProveedorDTO>>>(EnlaceProveedor);
            return result;
        }
        #endregion
    }
}
