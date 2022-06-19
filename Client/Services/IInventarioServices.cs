using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Compartido;
using Compartido.Dto.Inventario;
using Compartido.Dto.Inventario.General;

namespace Proyecto_Final_Gestion_Sistemas.Client.Services
{
    public interface IInventarioServices
    {
        #region Actualizar Stock Por Compra
        Task<ServiceResponse<List<StockDTO>>> ObtenerTodosStock();
        Task<ServiceResponse<StockDTO>> ObtenerPorIdStock(Guid Id);
        Task<ServiceResponse<List<StockDTO>>> ObtenerTodoStockPorIdEmpresa(Guid Id);
        Task<ServiceResponse<List<StockDTO>>> ActualizarStock(List<StockDTO> nuevoStock);
        #endregion

        #region Admnistrar Nota Recepcion
        #endregion

        #region Administrar Producto
        Task<ServiceResponse<List<ProductoDTO>>> ObtenerTodosProductos();
        Task<ServiceResponse<List<ProductoDTO>>> InsertarProducto(List<ProductoDTO> productoDTO);
        Task<ServiceResponse<List<ProductoDTO>>> ActualizarProducto(List<ProductoDTO> ProductoDTO);
        Task<ServiceResponse<ProductoDTO>> EliminarProducto(Guid id);
        Task<ServiceResponse<List<ProductoDTO>>> ObtenerTodoProductoPorIdEmpresa(Guid idEmpresa);
        #endregion

        #region Gestionar Tipo Producto
        Task<ServiceResponse<List<TipoProductoDTO>>> ObtenerTodosLosTipoProducto();
        Task<ServiceResponse<List<TipoProductoDTO>>> InsertarTipoProducto(List<TipoProductoDTO> tipoProductoDTO);
        Task<ServiceResponse<List<TipoProductoDTO>>> ActualizarTipoProducto(List<TipoProductoDTO> tipoProductoDTO);
        Task<ServiceResponse<TipoProductoDTO>> EliminarTipoProducto(List<Guid> id);
        #endregion

        #region Realizar Pedido A Proveedor
        #endregion
    }
}
