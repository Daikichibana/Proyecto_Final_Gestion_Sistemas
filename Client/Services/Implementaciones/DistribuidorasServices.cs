﻿using Compartido;
using Compartido.Dto.Distribuidora.General;
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
        public async Task<ServiceResponse<EmpresaDistribuidoraDTO>> CrearEmpresaDistribuidora(EmpresaDistribuidoraDTO distribuidora)
        {
            var result = await _http.PostAsJsonAsync(EnlaceEmpresaDistribuidora, distribuidora);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<EmpresaDistribuidoraDTO>>();

            return content;
        }
        #endregion

        #region Empresa Cliente
        public async Task<ServiceResponse<EmpresaClienteDTO>> CrearEmpresaCliente(EmpresaClienteDTO cliente)
        {
            var result = await _http.PostAsJsonAsync(EnlaceEmpresaCliente, cliente);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<EmpresaClienteDTO>>();

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
            var result = await _http.DeleteAsync($"{EnlaceRubro}/?Id={sucursalesDTO.Id}");
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<SucursalesDTO>>();

            return content;
        }

        public async Task<ServiceResponse<List<SucursalesDTO>>> ObtenerTodasLasSucursales()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<SucursalesDTO>>>(EnlaceSucursal);
            return result;
        }
        #endregion
    }
}
