using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Abstracciones
{
    public interface IAdministrarPedidoService
    {
        //Pedido
        void Eliminar(Guid id);
        IList<Pedido> ObtenerTodo();
        Pedido ObtenerPorId(Guid id);
        Pedido Guardar(Pedido entity);
        Pedido Actualizar(Pedido entity);

        //Orden Pedido
        void EliminarOrdenPedido(Guid id);
        IList<OrdenPedido> ObtenerTodoOrdenPedido();
        OrdenPedido ObtenerPorIdOrdenPedido(Guid id);
        OrdenPedido GuardarOrdenPedido(OrdenPedido entity);
        OrdenPedido ActualizarOrdenPedido(OrdenPedido entity);


        //Detalle Orden Pedido
        void EliminarDetalleOrdenPedido(Guid id);
        IList<DetalleOrdenPedido> ObtenerTodoDetalleOrdenPedido();
        DetalleOrdenPedido ObtenerPorIdDetalleOrdenPedido(Guid id);
        DetalleOrdenPedido GuardarDetalleOrdenPedido(DetalleOrdenPedido entity);
        DetalleOrdenPedido ActualizarDetalleOrdenPedido(DetalleOrdenPedido entity);
    }
}
