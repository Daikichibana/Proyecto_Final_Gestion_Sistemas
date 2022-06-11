using System;
using Compartido.Dto.Distribuidora.General;

namespace Compartido.Dto.Pedidos.General
{
    public class OrdenPedidoDTO
    {
        public Guid Id { get; set; }
        public EmpresaClienteDTO EmpresaCliente { get; set; }
        public bool DeseaFactura { get; set; }
        public bool PedidoConfirmado { get; set; }
        public string AclaracionCliente { get; set; }
        public string AclaracionDistribuidor { get; set; }
        public string MetodoPago { get; set; }
        public byte[] CodigoQR { get; set; }

        public Guid EmpresaClienteId { get; set; }
    }
}