using System;
using Compartido.Dto.Inventario.General;

namespace Compartido.Dto.Pedidos.General
{
    public class DetalleOrdenPedidoDTO
    {
        public Guid Id { get; set; }
        public OrdenPedidoDTO OrdenPedido { get; set; }
        public StockDTO Stock{ get; set; }
        public int CantidadOrdenada { get; set; }

        public Guid OrdenPedidoId { get; set; }
        public Guid StockId { get; set; }
    }
}
