using CAPAS.CAPA.DOMINIO;
using CAPAS.CAPA.DOMINIO.INVENTARIO.DTO;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Proyecto_Final_Gestion_Sistemas.Client.Services
{
    public interface IInventarioServices
    {
        
        Task<ServiceResponse<List<TipoProductoDTO>>> ObtenerTodoTipoProducto();
        Task<ServiceResponse<TipoProductoDTO>> CrearTipoProducto(TipoProductoDTO tipoProducto);
        Task<ServiceResponse<TipoProductoDTO>> ActualizarTipoProducto(TipoProductoDTO tipoProducto);
        Task<ServiceResponse<TipoProductoDTO>> EliminarTipoProducto(TipoProductoDTO tipoProducto);
        
    }
    public class InventarioServices : IInventarioServices
    {
        
        private readonly HttpClient _http;

        public InventarioServices(HttpClient http)
        {
            _http = http;
        }

        public async Task<ServiceResponse<TipoProductoDTO>> ActualizarTipoProducto(TipoProductoDTO tipoProducto)
        {
            var result = await _http.PutAsJsonAsync("api/GestionarTipoProducto",tipoProducto);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<TipoProductoDTO>>();

            return content;
        }

        public async Task<ServiceResponse<TipoProductoDTO>> CrearTipoProducto(TipoProductoDTO tipoProducto)
        {
            var result = await _http.PostAsJsonAsync("api/GestionarTipoProducto", tipoProducto);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<TipoProductoDTO>>();

            return content;
        }

        public async Task<ServiceResponse<TipoProductoDTO>> EliminarTipoProducto(TipoProductoDTO tipoProducto)
        {
            var result = await _http.DeleteAsync($"api/GestionarTipoProducto/{tipoProducto.Id}");
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<TipoProductoDTO>>();

            return content;
        }

        public async Task<ServiceResponse<List<TipoProductoDTO>>> ObtenerTodoTipoProducto()
        {
            var result = await _http.GetFromJsonAsync <ServiceResponse<List<TipoProductoDTO>>>("api/GestionarTipoProducto");
            return result;
        }
    }
}
