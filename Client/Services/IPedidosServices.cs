using Compartido;
using Compartido.Dto.Pedidos.General;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proyecto_Final_Gestion_Sistemas.Client.Services
{
    public interface IPedidosServices
    {
        #region Administrar Pedidos
        Task<ServiceResponse<List<PedidoDTO>>> ObtenerTodosLosPedidos();
        Task<ServiceResponse<PedidoDTO>> CrearPedido(PedidoDTO PedidoDTO);
        Task<ServiceResponse<PedidoDTO>> ActualizarPedido(PedidoDTO PedidoDTO);
        Task<ServiceResponse<PedidoDTO>> EliminarPedido(PedidoDTO PedidoDTO);

        Task<ServiceResponse<List<OrdenPedidoDTO>>> ObtenerTodosLosOrdenPedido();
        Task<ServiceResponse<OrdenPedidoDTO>> CrearOrdenPedido(OrdenPedidoDTO OrdenPedidoDTO);
        Task<ServiceResponse<OrdenPedidoDTO>> ActualizarOrdenPedido(OrdenPedidoDTO OrdenPedidoDTO);
        Task<ServiceResponse<OrdenPedidoDTO>> EliminarOrdenPedido(OrdenPedidoDTO OrdenPedidoDTO);

        Task<ServiceResponse<List<DetalleOrdenPedidoDTO>>> ObtenerTodosLosDetalleOrdenPedido();
        Task<ServiceResponse<DetalleOrdenPedidoDTO>> CrearDetalleOrdenPedido(DetalleOrdenPedidoDTO DetalleOrdenPedidoDTO);
        Task<ServiceResponse<DetalleOrdenPedidoDTO>> ActualizarDetalleOrdenPedido(DetalleOrdenPedidoDTO DetalleOrdenPedidoDTO);
        Task<ServiceResponse<DetalleOrdenPedidoDTO>> EliminarDetalleOrdenPedido(DetalleOrdenPedidoDTO DetalleOrdenPedidoDTO);
        #endregion

        #region Asignar Entrega a conductor
        #endregion

        #region Realizar Entrega de pedido a cliente
        #endregion

        #region Realizar Entrega de pedido a conductor
        #endregion

        #region Realizar facturacion cliente
        #endregion

        #region Realizar Pedido a distribuidora
        #endregion
    }
}
