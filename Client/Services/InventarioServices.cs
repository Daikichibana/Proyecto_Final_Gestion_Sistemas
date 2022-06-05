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
        #region Tipo Producto
        Task<ServiceResponse<List<TipoProductoDTO>>> ObtenerTodoTipoProducto();
        Task<ServiceResponse<TipoProductoDTO>> CrearTipoProducto(TipoProductoDTO tipoProducto);
        Task<ServiceResponse<TipoProductoDTO>> ActualizarTipoProducto(TipoProductoDTO tipoProducto);
        Task<ServiceResponse<TipoProductoDTO>> EliminarTipoProducto(TipoProductoDTO tipoProducto);
        #endregion

        #region Producto
        Task<ServiceResponse<List<ProductoDTO>>> ObtenerTodoProducto();
        Task<ServiceResponse<ProductoDTO>> CrearProducto(ProductoDTO Producto);
        Task<ServiceResponse<ProductoDTO>> ActualizarProducto(ProductoDTO Producto);
        Task<ServiceResponse<ProductoDTO>> EliminarProducto(ProductoDTO Producto);
        #endregion
    }
    public class InventarioServices : IInventarioServices
    {
        
        private readonly HttpClient _http;
        private string EnlaceTipoProducto = "api/GestionarTipoProducto";
        private string EnlaceProducto = "api/AdministrarProducto";
        public InventarioServices(HttpClient http)
        {
            _http = http;
        }

        #region Tipo Producto
        public async Task<ServiceResponse<TipoProductoDTO>> ActualizarTipoProducto(TipoProductoDTO tipoProducto)
        {
            var result = await _http.PutAsJsonAsync(EnlaceTipoProducto, tipoProducto);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<TipoProductoDTO>>();

            return content;
        }

        public async Task<ServiceResponse<TipoProductoDTO>> CrearTipoProducto(TipoProductoDTO tipoProducto)
        {
            var result = await _http.PostAsJsonAsync(EnlaceTipoProducto, tipoProducto);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<TipoProductoDTO>>();

            return content;
        }

        public async Task<ServiceResponse<TipoProductoDTO>> EliminarTipoProducto(TipoProductoDTO tipoProducto)
        {
            var result = await _http.DeleteAsync($"{EnlaceTipoProducto}?Id={tipoProducto.Id}");
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<TipoProductoDTO>>();

            return content;
        }

        public async Task<ServiceResponse<List<TipoProductoDTO>>> ObtenerTodoTipoProducto()
        {
            var result = await _http.GetFromJsonAsync <ServiceResponse<List<TipoProductoDTO>>>(EnlaceTipoProducto);
            return result;
        }
        #endregion
        
        #region Producto
        public async Task<ServiceResponse<ProductoDTO>> ActualizarProducto(ProductoDTO Producto)
        {
            var result = await _http.PutAsJsonAsync(EnlaceProducto, Producto);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<ProductoDTO>>();

            return content;
        }

        public async Task<ServiceResponse<ProductoDTO>> CrearProducto(ProductoDTO Producto)
        {
            var result = await _http.PostAsJsonAsync(EnlaceProducto, Producto);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<ProductoDTO>>();

            return content;
        }

        public async Task<ServiceResponse<ProductoDTO>> EliminarProducto(ProductoDTO Producto)
        {
            var result = await _http.DeleteAsync($"{EnlaceProducto}/?Id={Producto.Id}");
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<ProductoDTO>>();

            return content;
        }

        public async Task<ServiceResponse<List<ProductoDTO>>> ObtenerTodoProducto()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<ProductoDTO>>>(EnlaceProducto);
            return result;
        }
        #endregion
    }
}
