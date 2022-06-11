using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Entidades
{
    public class Factura : Entity
    {
        public Pedido Pedido { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public int NroComprobante { get; set; }

        [ForeignKey("Pedido")]
        public Guid PedidoId { get; set; }

        public Factura()
        {

        }

        public Factura(Pedido pedido, DateTime fecha, decimal total, int nroComprobante, Guid pedidoId)
        {
            Pedido = pedido;
            Fecha = fecha;
            Total = total;
            NroComprobante = nroComprobante;
            PedidoId = pedidoId;
        }
    }
}
