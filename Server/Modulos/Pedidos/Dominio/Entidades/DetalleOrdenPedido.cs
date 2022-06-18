using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Entidades;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Entidades
{
    public class DetalleOrdenPedido : Entity
    {
        public OrdenPedido OrdenPedido { get; set; }
        public Stock Stock{ get; set; }
        public int CantidadOrdenada { get; set; }


        [ForeignKey("OrdenPedido")]
        public Guid OrdenPedidoId { get; set; }

        [ForeignKey("Distribuidora")]
        public Guid StockId { get; set; }

        public DetalleOrdenPedido()
        {

        }
        public DetalleOrdenPedido(OrdenPedido ordenPedido, Stock stock, int cantidadOrdenada, Guid ordenPedidoId, Guid stockId)
        {
            OrdenPedido = ordenPedido;
            Stock = stock;
            CantidadOrdenada = cantidadOrdenada;
            OrdenPedidoId = ordenPedidoId;
            StockId = stockId;
        }
    }
}
