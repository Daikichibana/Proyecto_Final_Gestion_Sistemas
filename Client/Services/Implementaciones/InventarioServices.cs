using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Compartido;
using Compartido.Dto.Inventario;
using Compartido.Dto.Inventario.General;

namespace Proyecto_Final_Gestion_Sistemas.Client.Services.Implementaciones
{
    public class InventarioServices : IInventarioServices
    {

        private readonly HttpClient _http;
        private string BaseTipoProducto = "api/GestionarTipoProducto";
        private string BaseProducto = "api/AdministrarProducto";
        private string BaseStock = "api/ActualizarStockPorCompra";

        public InventarioServices(HttpClient http)
        {
            _http = http;
        }

        #region Administrar Tipo Producto

        public async Task<ServiceResponse<TipoProductoDTO>> ActualizarTipoProducto(TipoProductoDTO tipoProducto)
        {
            string EnlaceTipoProducto = BaseTipoProducto + "/";
            var result = await _http.PutAsJsonAsync(EnlaceTipoProducto, tipoProducto);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<TipoProductoDTO>>();

            return content;
        }

        public async Task<ServiceResponse<TipoProductoDTO>> CrearTipoProducto(TipoProductoDTO tipoProducto)
        {
            string EnlaceTipoProducto = BaseTipoProducto + "/";
            var result = await _http.PostAsJsonAsync(EnlaceTipoProducto, tipoProducto);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<TipoProductoDTO>>();

            return content;
        }

        public async Task<ServiceResponse<TipoProductoDTO>> EliminarTipoProducto(TipoProductoDTO tipoProducto)
        {
            string EnlaceTipoProducto = BaseTipoProducto + $"/?Id={tipoProducto.Id}";
            var result = await _http.DeleteAsync(EnlaceTipoProducto);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<TipoProductoDTO>>();

            return content;
        }

        public async Task<ServiceResponse<List<TipoProductoDTO>>> ObtenerTodoTipoProducto()
        {
            string EnlaceTipoProducto = BaseTipoProducto + "/";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<TipoProductoDTO>>>(EnlaceTipoProducto);
            return result;
        }

        #endregion

        #region Administrar Producto

        public async Task<ServiceResponse<ProductoDTO>> ActualizarProducto(ProductoDTO Producto)
        {
            string EnlaceProducto = BaseProducto + "/";
            var result = await _http.PutAsJsonAsync(EnlaceProducto, Producto);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<ProductoDTO>>();

            return content;
        }

        public async Task<ServiceResponse<ProductoDTO>> CrearProducto(ProductoDTO Producto)
        {
            string EnlaceProducto = BaseProducto + "/";
            var result = await _http.PostAsJsonAsync(EnlaceProducto, Producto);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<ProductoDTO>>();

            return content;
        }

        public async Task<ServiceResponse<ProductoDTO>> EliminarProducto(ProductoDTO Producto)
        {
            string EnlaceProducto = BaseProducto + $"/?Id={Producto.Id}";
            var result = await _http.DeleteAsync(EnlaceProducto);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<ProductoDTO>>();

            return content;
        }

        public async Task<ServiceResponse<List<ProductoDTO>>> ObtenerTodoProducto()
        {
            string EnlaceProducto = BaseProducto + "/";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<ProductoDTO>>>(EnlaceProducto);
            return result;
        }

        #endregion

        #region Actualizar Stock Por Compra

        public async Task<ServiceResponse<StockDTO>> ActualizarStock(StockDTO Stock)
        {
            var EnlaceStock = BaseStock + "/";
            var result = await _http.PutAsJsonAsync(EnlaceStock, Stock);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<StockDTO>>();

            return content;
        }

        public async Task<ServiceResponse<StockDTO>> CrearStock(StockDTO Stock)
        {
            var EnlaceStock = BaseStock + "/";
            var result = await _http.PostAsJsonAsync(EnlaceStock, Stock);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<StockDTO>>();

            return content;
        }

        public async Task<ServiceResponse<StockDTO>> EliminarStock(StockDTO Stock)
        {
            var EnlaceStock = BaseStock + "/?Id={Stock.Id}";

            var result = await _http.DeleteAsync(EnlaceStock);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<StockDTO>>();

            return content;
        }

        public async Task<ServiceResponse<List<StockDTO>>> ObtenerTodoStock()
        {
            var EnlaceStock = BaseStock + "";

            var result = await _http.GetFromJsonAsync<ServiceResponse<List<StockDTO>>>(EnlaceStock);
            return result;
        }

        #endregion

        #region Realizar Pedido a Proveedor
        #endregion

        #region Administrar nota de recepcion
        #endregion
    }
}
