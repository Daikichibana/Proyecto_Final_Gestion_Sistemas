using System;
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
        private string BasePedido = "api/RealizarPedidoAProveedor";

        public InventarioServices(HttpClient http)
        {
            _http = http;
        }

        #region Actualizar Stock Por Compra
        public async Task<ServiceResponse<List<StockDTO>>> ObtenerTodosStock()
        {
            string EnlaceStock = BaseStock + "/ObtenerTodosStock";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<StockDTO>>>(EnlaceStock);
            return result;
        }
        public async Task<ServiceResponse<StockDTO>> ObtenerPorIdStock(Guid Id)
        {
            string EnlaceStock = BaseStock + "/";
            var result = await _http.GetFromJsonAsync<ServiceResponse<StockDTO>>(EnlaceStock);
            return result;
        }
        public async Task<ServiceResponse<List<StockDTO>>> ObtenerTodoStockPorIdEmpresa(Guid Id)
        {
            string EnlaceStock = BaseStock + $"/ObtenerTodoStockPorIdEmpresa?Id={Id}";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<StockDTO>>>(EnlaceStock);
            return result;
        }
        public async Task<ServiceResponse<List<StockDTO>>> ActualizarStock(List<StockDTO> nuevoStock)
        {
            string EnlaceStock = BaseStock + "/ActualizarStock";
            var result = await _http.PutAsJsonAsync(EnlaceStock, nuevoStock);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<List<StockDTO>>>();

            return content;
        }
        #endregion

        #region Admnistrar Nota Recepcion
        #endregion

        #region Administrar Producto
        public async Task<ServiceResponse<List<ProductoDTO>>> ObtenerTodosProductos()
        {
            string EnlaceProducto = BaseProducto + "/";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<ProductoDTO>>>(EnlaceProducto);
            return result;
        }
        public async Task<ServiceResponse<List<ProductoDTO>>> InsertarProducto(List<ProductoDTO> productoDTO)
        {
            string EnlaceProducto = BaseProducto + "/InsertarProducto";
            var result = await _http.PostAsJsonAsync(EnlaceProducto, productoDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<List<ProductoDTO>>>();

            return content;
        }
        public async Task<ServiceResponse<List<ProductoDTO>>> ActualizarProducto(List<ProductoDTO> ProductoDTO)
        {
            string EnlaceProducto = BaseProducto + "/ActualizarProducto";
            var result = await _http.PutAsJsonAsync(EnlaceProducto, ProductoDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<List<ProductoDTO>>>();

            return content;
        }
        public async Task<ServiceResponse<ProductoDTO>> EliminarProducto(Guid id)
        {
            string EnlaceProducto = BaseProducto + $"/EliminarProducto?id={id}";
            var result = await _http.DeleteAsync(EnlaceProducto);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<ProductoDTO>>();

            return content;
        }
        public async Task<ServiceResponse<List<ProductoDTO>>> ObtenerTodoProductoPorIdEmpresa(Guid idEmpresa)
        {
            string EnlaceProducto = BaseProducto + "/";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<ProductoDTO>>>(EnlaceProducto);
            return result;
        }
        #endregion

        #region Gestionar Tipo Producto
        public async Task<ServiceResponse<List<TipoProductoDTO>>> ObtenerTodosLosTipoProducto()
        {
            string EnlaceTipoProducto = BaseTipoProducto + "/ObtenerTodosLosTipoProducto";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<TipoProductoDTO>>>(EnlaceTipoProducto);
            return result;
        }
        public async Task<ServiceResponse<List<TipoProductoDTO>>> InsertarTipoProducto(List<TipoProductoDTO> tipoProductoDTO)
        {
            string EnlaceTipoProducto = BaseTipoProducto + "/InsertarTipoProducto";
            var result = await _http.PostAsJsonAsync(EnlaceTipoProducto, tipoProductoDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<List<TipoProductoDTO>>>();

            return content;
        }
        public async Task<ServiceResponse<List<TipoProductoDTO>>> ActualizarTipoProducto(List<TipoProductoDTO> tipoProductoDTO)
        {
            string EnlaceTipoProducto = BaseTipoProducto + "/ActualizarTipoProducto";
            var result = await _http.PutAsJsonAsync(EnlaceTipoProducto, tipoProductoDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<List<TipoProductoDTO>>>();

            return content;
        }
        public async Task<ServiceResponse<TipoProductoDTO>> EliminarTipoProducto(List<Guid> id)
        {
            string EnlaceTipoProducto = BaseTipoProducto + $"/EliminarTipoProducto?id={id}";
            var result = await _http.DeleteAsync(EnlaceTipoProducto);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<TipoProductoDTO>>();

            return content;
        }
        #endregion

        #region Realizar Pedido A Proveedor
        public async Task<ServiceResponse<object>> RealizarPedidoProveedor(NotaRecepcionDTO registro)
        {
            string EnlaceRealizarPedidoProveedor = BasePedido + "/RealizarOrdenPedido";
            var result = await _http.PostAsJsonAsync(EnlaceRealizarPedidoProveedor, registro);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<object>>();

            return content;
        }
        #endregion
    }
}
