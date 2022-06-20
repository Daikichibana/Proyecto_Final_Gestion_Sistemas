using Compartido;
using Compartido.Dto.Pedidos;
using Compartido.Dto.Pedidos.General;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proyecto_Final_Gestion_Sistemas.Client.Services
{
    public interface IPedidosServices
    {
        #region Administrar Pedidos
        Task<ServiceResponse<PedidoDTO>> ObtenerPorIdPedido(Guid Id);
        Task<ServiceResponse<PedidoDTO>> EliminarPedido(Guid Id);
        Task<ServiceResponse<OrdenPedidoDTO>> EliminarOrdenPedido(Guid Id);
        Task<ServiceResponse<List<OrdenPedidoDTO>>> ObtenerOrdenesPedidosDistribuidoraPorId(Guid Id);
        Task<ServiceResponse<List<OrdenPedidoDTO>>> ObtenerOrdenesPedidosClientePorId(Guid Id);
        Task<ServiceResponse<List<PedidoDTO>>> ObtenerPedidosDistribuidoraPorId(Guid Id);
        Task<ServiceResponse<List<PedidoDTO>>> ObtenerPedidosClientePorId(Guid Id);
        Task<ServiceResponse<PedidoDTO>> ConfirmarOrdenPedido(ConfirmarPedidoDTO confirmarPedidoDTO);
        Task<ServiceResponse<List<DetalleOrdenPedidoDTO>>> ObtenerDetalleOrdenPedidoPorIdOrden(Guid Id);
        #endregion

        #region Asignar Entrega a conductor
        Task<ServiceResponse<object>> AsignarEntregaAconductor(AsignacionEntregaConductorDTO Asignacion);
        #endregion

        #region Realizar Entrega de pedido a cliente
        Task<ServiceResponse<object>> ConfirmarEntregaCliente(Guid IdPedido);
        #endregion

        #region Realizar Entrega de pedido a conductor
        Task<ServiceResponse<object>> ConfirmarEntregaPedido(Guid IdPedido);
        #endregion

        #region Realizar facturacion cliente
        Task<ServiceResponse<object>> EliminarFactura(Guid Id);
        Task<ServiceResponse<List<FacturaDTO>>> ObtenerTodoFactura();
        Task<ServiceResponse<FacturaDTO>> ObtenerPorIdFactura(Guid Id);
        Task<ServiceResponse<object>> ConfirmarPago(Guid Id);

        #endregion

        #region Realizar Pedido a distribuidora
        Task<ServiceResponse<object>> RealizarOrdenPedido(RegistroPedidoDTO registro);
        #endregion
    }
}
