using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Compartido;
using Compartido.Modulos.Inventario.Dto;

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
}
