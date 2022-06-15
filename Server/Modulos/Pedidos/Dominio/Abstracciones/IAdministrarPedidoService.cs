using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Abstracciones
{
    public interface IAdministrarPedidoService
    {
        //Pedido
        void EliminarPedido(Guid id);
        IList<Pedido> ObtenerTodoPedido();
        Pedido ObtenerPorIdPedido(Guid id);
        Pedido GuardarPedido(Pedido entity);
        Pedido ActualizarPedido(Pedido entity);
        
        List<Pedido> ObtenerPedidosDistribuidoraPorId(Guid Id);
        List<Pedido> ObtenerPedidosClientePorId(Guid Id);



        //Orden Pedido
        void EliminarOrdenPedido(Guid id);
        IList<OrdenPedido> ObtenerTodoOrdenPedido();
        OrdenPedido ObtenerPorIdOrdenPedido(Guid id);
        OrdenPedido GuardarOrdenPedido(OrdenPedido entity);
        OrdenPedido ActualizarOrdenPedido(OrdenPedido entity);
        OrdenPedido ObtenerOrdenesPedidosPorId(Guid Id);

        List<OrdenPedido> ObtenerOrdenesPedidosDistribuidoraPorId(Guid Id);
        List<OrdenPedido> ObtenerOrdenesPedidosClientePorId(Guid Id);
        void ConfirmarOrdenPedido(Guid Id, bool aceptado);


        //Detalle Orden Pedido
        void EliminarDetalleOrdenPedido(Guid id);
        IList<DetalleOrdenPedido> ObtenerTodoDetalleOrdenPedido();
        DetalleOrdenPedido ObtenerPorIdDetalleOrdenPedido(Guid id);
        DetalleOrdenPedido GuardarDetalleOrdenPedido(DetalleOrdenPedido entity);
        DetalleOrdenPedido ActualizarDetalleOrdenPedido(DetalleOrdenPedido entity);
    }
}
