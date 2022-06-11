using System;

namespace Compartido.Dto.Pedidos.General
{
    public class FacturaDTO
    {
        public Guid Id { get; set; }
        public PedidoDTO Pedido { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public int NroComprobante { get; set; }
        
        public Guid PedidoId { get; set; }
    }
}
